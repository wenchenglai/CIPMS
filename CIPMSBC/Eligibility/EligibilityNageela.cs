using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    class EligibilityNageelaMidwest:EligibilityBase
    {
        public EligibilityNageelaMidwest(FederationEnum fed)
            : base(fed)
        {
        }

        public override EligibilityResult checkEligibilityforStep2(string FJCID, out int StatusValue, string specialCode)
        {
            var result = new EligibilityResult();

            checkEligibilityCommon(FJCID, out StatusValue);
            result.CurrentUserStatusFromDB = (StatusInfo)StatusValue;

            StatusBasedOnCamperTimeInCampWithOutCamp(FJCID, out StatusValue);
            result.TimeInCamp = (StatusInfo)StatusValue;

            StatusBasedOnGrade(FJCID, out StatusValue);
            result.Grade = (StatusInfo)StatusValue;

            StatusBasedOnSchool(FJCID, out StatusValue, specialCode);
            result.SchoolType = (StatusInfo)StatusValue;

            return result;
        }

        private int StatusBasedOnCamp(string FJCID, int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsCamp;
            dsCamp = oCA.getCamperAnswers(FJCID, "10", "10", "N");
            DataRow drCamp;
            int CampID = 0;
            int CampOption = 0;
            int iStatusValue = -1;

            if (dsCamp.Tables[0].Rows.Count > 0)
            {

                int i;
                for (i = 0; i < dsCamp.Tables[0].Rows.Count; i++)
                {
                    drCamp = dsCamp.Tables[0].Rows[i];
                    if (!DBNull.Value.Equals(drCamp["OptionID"]))
                    {
                        CampOption = Convert.ToInt32(drCamp["OptionID"]);
                    }
                    if (CampOption == 2)
                    {
                        CampID = Convert.ToInt32(drCamp["Answer"]);
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
            }
            if (iStatusValue == -1)
            {
                iStatusValue = StatusValue;
            }
            return iStatusValue;
        }

        private void StatusBasedOnSchool(string FJCID, out int StatusValue, string specialCode = "None")
        {
            //StatusValue = (int)StatusInfo.SystemEligible;

            var oCA = new CamperApplication();
            DataSet dsJewishSchool;
            dsJewishSchool = oCA.getCamperAnswers(FJCID, "7", "7", "N");
            DataRow drJewishSchool;
            int JewishSchoolOption = 0;

            if (dsJewishSchool.Tables[0].Rows.Count > 0)
            {
                drJewishSchool = dsJewishSchool.Tables[0].Rows[0];
                if (!string.IsNullOrEmpty(drJewishSchool["OptionID"].ToString()))
                {
                    JewishSchoolOption = Convert.ToInt32(drJewishSchool["OptionID"]);

                    if (JewishSchoolOption == 4)
                    {
                        if (specialCode == "PJGTC2017")
                            StatusValue = (int)StatusInfo.SystemInEligible;
                        else
                            StatusValue = (int)StatusInfo.SystemInEligible;
                    }
                    else
                    {
                        StatusValue = (int)StatusInfo.SystemEligible;
                    }
                }
                else
                {
                    StatusValue = (int)StatusInfo.SystemInEligible;
                }
            }
            else
            {
                StatusValue = (int)StatusInfo.SystemInEligible;
            }
        }

        private void StatusBasedOnGrade(string FJCID, out int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsGrade;
            dsGrade = oCA.getCamperAnswers(FJCID, "6", "6", "N");
            DataRow drGrade;
            int Grade = 0;

            if (dsGrade.Tables[0].Rows.Count > 0)
            {
                drGrade = dsGrade.Tables[0].Rows[0];
                if (DBNull.Value.Equals(drGrade["Answer"]))
                {
                    StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
                }
                else
                {
                    General objGeneral = new General();
                    Grade = Convert.ToInt32(drGrade["Answer"]);
                    if (objGeneral.GetEligiblityForGrades(FJCID, Grade.ToString()) == "1")
                    {
                        StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
                    }
                    else
                    {
                        StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
                    }
                }
            }
            else
            {
                StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
            }
            return;
        }

        public override bool checkEligibility(string FJCID, out int StatusValue)
        {

            int daysInCamp;
            double Amount = 0.00;

            if (checkEligibilityCommon(FJCID, out StatusValue))
            {
                return true;
            }

            CamperApplication oCA = new CamperApplication();

            StatusBasedOnGrade(FJCID, out StatusValue);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                oCA.UpdateAmount(FJCID, 0.00, 0, "");
                return true;
            }
            
            StatusBasedOnSchool(FJCID, out StatusValue);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                oCA.UpdateAmount(FJCID, 0.00, 0, "");
                return true;
            }

            StatusValue = StatusBasedOnCamp(FJCID, StatusValue);
            if (StatusValue != Convert.ToInt32(StatusInfo.SystemEligible))
            {
                oCA.UpdateAmount(FJCID, 0.00, 0, "");
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

            //////////////////////////

            //int Age = 0;
            //DateTime dBirthDate;
            //int FirstTimeCamperOption = 0;
            //int JewishSchoolOption = 0;
            //StatusValue = 0;
            //int Grade = 0;

            //Boolean FirstTimeCamper = false;
            //Boolean SecondTimeCamper = false;

            //if (checkEligibilityCommon(FJCID, out StatusValue))
            //{
            //    return true;
            //}
            
            //CamperApplication oCA = new CamperApplication();

            ////Grade check

            //DataSet dsGrade;
            //dsGrade = oCA.getCamperAnswers(FJCID, "6", "6", "N");
            //DataRow drGrade;

            //if (dsGrade.Tables[0].Rows.Count > 0)
            //{
            //    drGrade = dsGrade.Tables[0].Rows[0];
            //    if (DBNull.Value.Equals(drGrade["Answer"]))
            //    {
            //        StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
            //        oCA.UpdateAmount(FJCID, 0.00, 0, "");
            //        return true;
            //    }
            //    else
            //    {
            //        // Camper grade value must be between 4 - 11
            //        Grade = Convert.ToInt32(drGrade["Answer"]);
            //        if ((Grade > 3) && (Grade < 12))
            //        {
            //            StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
            //        }
            //        else
            //        {
            //            StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
            //            oCA.UpdateAmount(FJCID, 0.00, 0, "");
            //            return true;
            //        }
            //    }
            //}

            //Is this your first time to attend a Non-profit Jewish overnight camp, for 3 weeks or longer:

            //DataSet dsFirstTimeCamper;
            //dsFirstTimeCamper = oCA.getCamperAnswers(FJCID, "3", "3", "N");
            //DataRow drFTC;

            //if (dsFirstTimeCamper.Tables[0].Rows.Count > 0)
            //{
            //    drFTC = dsFirstTimeCamper.Tables[0].Rows[0];
            //    FirstTimeCamperOption = Convert.ToInt32(drFTC["OptionID"]);

            //    if (FirstTimeCamperOption == 2)
            //    {
            //        StatusValue = (int)StatusInfo.SystemInEligible;
            //        oCA.UpdateAmount(FJCID, 0.00, 0, "");
            //        return true;
            //    }
            //    else
            //    {
            //        StatusValue = (int)StatusInfo.SystemEligible;
            //        oCA.UpdateAmount(FJCID, 1000.00, 0, "");
            //        FirstTimeCamper = true;
            //    }
            //}

            //What kind of the school the camper go to

            //DataSet dsJewishSchool;
            //dsJewishSchool = oCA.getCamperAnswers(FJCID, "7", "7", "N");
            //DataRow drJewishSchool;

            //if (dsJewishSchool.Tables[0].Rows.Count > 0)
            //{
            //    drJewishSchool = dsJewishSchool.Tables[0].Rows[0];
            //    if (!string.IsNullOrEmpty(drJewishSchool["OptionID"].ToString()))
            //    {
            //        JewishSchoolOption = Convert.ToInt32(drJewishSchool["OptionID"]);

            //        if (JewishSchoolOption == 4)
            //        {
            //            StatusValue = (int)StatusInfo.SystemInEligible;
            //            oCA.UpdateAmount(FJCID, 0.00, 0, "");
            //            return true;
            //        }
            //        else
            //        {
            //            StatusValue = (int)StatusInfo.SystemEligible;
            //        }
            //    }
            //}

            //Camp check

            //DataSet dsCamp;
            //dsCamp = oCA.getCamperAnswers(FJCID, "10", "10", "N");
            //DataRow drCamp;
            //int CampID = 0;
            //int CampOption = 0;

            //if (dsCamp.Tables[0].Rows.Count > 0)
            //{

            //    int i;
            //    for (i = 0; i < dsCamp.Tables[0].Rows.Count; i++)
            //    {
            //        drCamp = dsCamp.Tables[0].Rows[i];
            //        if (!DBNull.Value.Equals(drCamp["OptionID"]))
            //        {
            //            CampOption = Convert.ToInt32(drCamp["OptionID"]);
            //        }
            //        if (CampOption == 2)
            //        {
            //            CampID = Convert.ToInt32(drCamp["Answer"]);
            //            if (CampID == 0)
            //            {
            //                StatusValue = Convert.ToInt32(StatusInfo.EligibleNoCamp);
            //                return true;
            //            }
            //            else
            //            {
            //                StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
            //            }
            //        }
            //    }

            //}

            //Camp Session check - Eligible only if registered for 21 days 

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
            //        double Amount = 0;

            //        if (iDays < 20)
            //        {
            //            StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
            //            oCA.UpdateAmount(FJCID, 0.00, 0, "");
            //            return true;
            //        }
            //        else
            //        {
            //            StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
            //        }

            //    }
            //}
            //return true;
        }
    }
}
