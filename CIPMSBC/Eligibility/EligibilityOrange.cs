using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    class EligibilityOrange : EligibilityBase
    {
        public EligibilityOrange(FederationEnum fed) : base(fed)
        {
        }
        public override bool checkEligibilityforStep2(string FJCID, out int StatusValue)
        {
            if (checkEligibilityCommon(FJCID, out StatusValue))
            {
                return true;
            }
            StatusBasedOnCamperTimeInCampWithOutCamp(FJCID, out StatusValue);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                return true;
            } 
            //StatusValue = StatusBasedOnGrade(FJCID, StatusValue);
            //if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            //{
            //    return true;
            //}
            StatusValue = StatusBasedOnSchool(FJCID, StatusValue);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                return true;
            }
            return true;
        }
        private int StatusBasedOnCamp(string FJCID, int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsCamp;
            dsCamp = oCA.getCamperAnswers(FJCID, "10", "10", "N");
            DataRow drCamp;
            int CampID = 0;
            int iStatusValue = -1;

            if (dsCamp.Tables[0].Rows.Count > 0)
            {
                drCamp = dsCamp.Tables[0].Rows[0];
                // Camper Camp value is null 
                if (DBNull.Value.Equals(drCamp["OptionID"]))
                {
                    iStatusValue = Convert.ToInt32(StatusInfo.EligibleNoCamp);
                }
                else
                {
                    CampID = Convert.ToInt32(drCamp["OptionID"]);
                    if (CampID == 0)
                    {
                        iStatusValue = Convert.ToInt32(StatusInfo.EligibleNoCamp);
                    }
                    else
                    {
                        iStatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
                    }
                }
            }
            
            if (iStatusValue == -1)
            {
                iStatusValue = StatusValue;
            }
            return iStatusValue;
        }

        private int StatusBasedOnSchool(string FJCID, int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();
            int iStatusValue = -1;

            DataSet dsJewishSchool;
            dsJewishSchool = oCA.getCamperAnswers(FJCID, "7", "7", "N");
            DataRow drJewishSchool;
            int JewishSchool;

            if (dsJewishSchool.Tables[0].Rows.Count > 0)
            {
                drJewishSchool = dsJewishSchool.Tables[0].Rows[0];
                JewishSchool = Convert.ToInt32(drJewishSchool["OptionID"]);

                if (JewishSchool == 4)
                {
                    iStatusValue = (int)StatusInfo.SystemInEligible;
                }
                else
                {
                    iStatusValue = (int)StatusInfo.SystemEligible;
                }
            }

            if (iStatusValue == -1)
                iStatusValue = StatusValue;

            return iStatusValue;
        }

        public override bool checkEligibility(string FJCID, out int StatusValue)
        {
            StatusValue = 0;
            int daysInCamp;
            double Amount = 0.00;

            if (checkEligibilityCommon(FJCID, out StatusValue))
            {
                return true;
            }

            CamperApplication oCA = new CamperApplication();

            StatusValue = StatusBasedOnSchool(FJCID, StatusValue);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                oCA.UpdateAmount(FJCID, 0.00, 0, "");
                return true;
            }

            StatusValue = StatusBasedOnCamp(FJCID, StatusValue);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                oCA.UpdateAmount(FJCID, 0.00, 0, "");
                return true;
            }
            else if (StatusValue == Convert.ToInt32(StatusInfo.EligibleNoCamp))
            {
                if (TimeInCamp(FJCID) == 1)
                {
                    Amount = 1000.00;
                }
                else if (TimeInCamp(FJCID) == 2)
                {
                    Amount = 750.00;
                }
                oCA.UpdateAmount(FJCID, Amount, 0, "");
                return true;
            }

            daysInCamp = DaysInCamp(FJCID);
            if (daysInCamp > 0)
            {
                Amount = getCamperGrant(FJCID, daysInCamp, out StatusValue);
            }
            else
            {
                StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
                Amount = 0;
            }

            oCA.UpdateAmount(FJCID, Amount, 0, "");
            return true;


            //int FirstTimeCamperOption = 0;
            //int SecondTimeCamperOption = 0;

            //Boolean FirstTimeCamper = false;
            //Boolean SecondTimeCamper = false;
            //int JewishSchool = 0;
            ////int Grade = 0;
            //StatusValue = 0;
            //double Amount = 0.00;
            //int IncentiveOption = 0;

            //if (checkEligibilityCommon(FJCID, out StatusValue))
            //{
            //    return true;
            //}
            
            //CamperApplication oCA = new CamperApplication();


            ////What kind of the school the camper go to
            ////Jewish day school ineligible

            //DataSet dsJewishSchool;
            //dsJewishSchool = oCA.getCamperAnswers(FJCID, "7", "7", "N");
            //DataRow drJewishSchool;

            //if (dsJewishSchool.Tables[0].Rows.Count > 0)
            //{
            //    drJewishSchool = dsJewishSchool.Tables[0].Rows[0];
            //    JewishSchool = Convert.ToInt32(drJewishSchool["OptionID"]);

            //    if (JewishSchool == 4)
            //    {
            //        StatusValue = (int)StatusInfo.SystemInEligible;
            //        oCA.UpdateAmount(FJCID, Amount, 0, "");
            //        return true;
            //    }
            //    else
            //    {
            //        StatusValue = (int)StatusInfo.SystemEligible;

            //    }
            //}

            ////Is this your first time to attend a Non-profit Jewish overnight camp, for 3 weeks or longer:

            //DataSet dsFirstTimeCamper;
            //dsFirstTimeCamper = oCA.getCamperAnswers(FJCID, "3", "3", "N");
            //DataRow drFTC;

            //if (dsFirstTimeCamper.Tables[0].Rows.Count > 0)
            //{
            //    drFTC = dsFirstTimeCamper.Tables[0].Rows[0];
            //    FirstTimeCamperOption = Convert.ToInt32(drFTC["OptionID"]);

            //    if (FirstTimeCamperOption == 2)
            //    {
            //        DataSet dsSecondTimeCamper;
            //        dsSecondTimeCamper = oCA.getCamperAnswers(FJCID, "13", "13", "N");
            //        DataRow drSTC;

            //        if (dsSecondTimeCamper.Tables[0].Rows.Count > 0)
            //        {
            //            drSTC = dsSecondTimeCamper.Tables[0].Rows[0];
            //            if (!string.IsNullOrEmpty(drSTC["OptionID"].ToString()))
            //            {
            //                SecondTimeCamperOption = Convert.ToInt32(drSTC["OptionID"]);

            //                if (SecondTimeCamperOption == 2)
            //                {
            //                    StatusValue = (int)StatusInfo.SystemInEligible;
            //                    oCA.UpdateAmount(FJCID, Amount, 0, "");
            //                    return true;
            //                }
            //                else
            //                {
            //                    DataSet dsThirdTimeCamper;
            //                    dsThirdTimeCamper = oCA.getCamperAnswers(FJCID, "20", "20", "N");
            //                    DataRow drTTC;

            //                    if (dsThirdTimeCamper.Tables[0].Rows.Count > 0)
            //                    {
            //                        drTTC = dsThirdTimeCamper.Tables[0].Rows[0];
            //                        IncentiveOption = Convert.ToInt32(drTTC["OptionID"]);
            //                        if (IncentiveOption == 2)
            //                        {
            //                            StatusValue = (int)StatusInfo.SystemInEligible;
            //                            oCA.UpdateAmount(FJCID, 0.00, 0, "");
            //                            return true;
            //                        }
            //                        else
            //                        {
            //                            StatusValue = (int)StatusInfo.SystemEligible;
            //                            SecondTimeCamper = true;
            //                        }
            //                    }
            //                }

            //            }
            //        }

            //    }
            //    else
            //    {
            //        FirstTimeCamper = true;
            //        StatusValue = (int)StatusInfo.SystemEligible;
            //    }
            //}

            ////Camp check

            //DataSet dsCamp;
            //dsCamp = oCA.getCamperAnswers(FJCID, "10", "10", "N");
            //DataRow drCamp;
            //int CampID = 0;

            //if (dsCamp.Tables[0].Rows.Count > 0)
            //{
            //    drCamp = dsCamp.Tables[0].Rows[0];
            //    // Camper Camp value is null 
            //    if (DBNull.Value.Equals(drCamp["OptionID"]))
            //    {
            //        StatusValue = Convert.ToInt32(StatusInfo.EligibleNoCamp);
            //        if (FirstTimeCamper)
            //        {
            //            Amount = 1000.00;
            //        }
            //        if (SecondTimeCamper)
            //        {
            //            Amount = 750.00;
            //        }
            //        oCA.UpdateAmount(FJCID, Amount, 0, "");
            //        return true;
            //    }
            //    else
            //    {

            //        CampID = Convert.ToInt32(drCamp["OptionID"]);
            //        if (CampID == 0)
            //        {
            //            StatusValue = Convert.ToInt32(StatusInfo.EligibleNoCamp);
            //            if (FirstTimeCamper)
            //            {
            //                Amount = 1000.00;
            //            }
            //            if (SecondTimeCamper)
            //            {
            //                Amount = 750.00;
            //            }
            //            oCA.UpdateAmount(FJCID, Amount, 0, "");
            //            return true;
            //        }
            //        else
            //        {
            //            StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
            //        }
            //    }
            //}

            ////Camp Session check - Eligible only if registered for 21 days 

            //DataSet dsCampSession;
            //dsCampSession = oCA.getCamperAnswers(FJCID, "12", "12", "N");
            //DataRow drStartDate;
            //DataRow drEndDate;

            //if (dsCampSession.Tables[0].Rows.Count > 1)
            //{
            //    drStartDate = dsCampSession.Tables[0].Rows[0];
            //    drEndDate = dsCampSession.Tables[0].Rows[1];
            //    if (!string.IsNullOrEmpty(drStartDate["Answer"].ToString()))
            //    {
            //        string strStartDate = Convert.ToString(drStartDate["Answer"]);
            //        string strEndDate = Convert.ToString(drEndDate["Answer"]);

            //        DateTime dtStartDate = Convert.ToDateTime(strStartDate);
            //        DateTime dtEndDate = Convert.ToDateTime(strEndDate);
            //        //int iDays = DateTime.
            //        TimeSpan span = dtEndDate.Subtract(dtStartDate);
            //        int iDays = span.Days + 1;

            //        if (iDays < 21)
            //        {
            //            StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
            //            oCA.UpdateAmount(FJCID, Amount, 0, "");
            //            return true;
            //        }
            //        else
            //        {
            //            StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
            //            if (FirstTimeCamper)
            //            {
            //                Amount = 1000.00;
            //            }
            //            if (SecondTimeCamper)
            //            {
            //                Amount = 750.00;
            //            }
            //        }
            //    }
            //    // update amount in the database
            //    oCA.UpdateAmount(FJCID, Amount, 0, "");
            //}

            //return true;
        }
    }
}
