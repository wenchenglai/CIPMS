using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    class EligibilityBaltimore:EligibilityBase
    {
        public EligibilityBaltimore(FederationEnum fed)
            : base(fed)
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
            StatusValue = StatusBasedOnGrade(FJCID, StatusValue);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                return true;
            }
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

        private int StatusBasedOnSchool(string FJCID, int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();
            int iStatusValue = -1;

            DataSet dsSchoolOption;
            dsSchoolOption = oCA.getCamperAnswers(FJCID, "7", "7", "N");
            DataRow drSchoolOption;
            int SchoolOption;

            if (dsSchoolOption.Tables[0].Rows.Count > 0)
            {
                drSchoolOption = dsSchoolOption.Tables[0].Rows[0];
                if (!string.IsNullOrEmpty(drSchoolOption["OptionID"].ToString()))
                {
                    SchoolOption = Convert.ToInt32(drSchoolOption["OptionID"]);
                    if (TimeInCamp(FJCID) <= 1)
                    {
                        if (SchoolOption == 4)
                        {
                            iStatusValue = (int)AllowDaySchool(FJCID);
                        }
                        else
                        {
                            iStatusValue = (int)StatusInfo.SystemEligible;
                        }
                    }
                    else if (TimeInCamp(FJCID) == 2)
                    {
                        if (SchoolOption >= 1 && SchoolOption <= 4)
                            iStatusValue = (int)StatusInfo.SystemEligible;
                    }
                }
            }
            if (iStatusValue == -1)
                iStatusValue = StatusValue;

            return iStatusValue;
        }

        private int StatusBasedOnGrade(string FJCID, int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsGrade;
            dsGrade = oCA.getCamperAnswers(FJCID, "6", "6", "N");
            DataRow drGrade;
            int iStatusValue = -1;
            int Grade;

            if (dsGrade.Tables[0].Rows.Count > 0)
            {
                drGrade = dsGrade.Tables[0].Rows[0];
                if (DBNull.Value.Equals(drGrade["Answer"]))
                {
                    iStatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
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

            StatusValue = StatusBasedOnGrade(FJCID, StatusValue);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                oCA.UpdateAmount(FJCID, 0.00, 0, "");
                return true;
            }

            StatusValue = StatusBasedOnSchool(FJCID, StatusValue);
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

            //int SchoolOption = 0;
            ////int JewishSchool = 0;
            //int Grade = 0;
            //StatusValue = 0;
            //int FirstTimeCamperOption = 0;
            //int SecondTimeCamperOption = 0;
            //int IncentiveOption = 0;
            //Boolean FirstTimeCamper = false;
            //Boolean SecondTimeCamper = false;
            ////Boolean PendingSchool = false;
            //double Amount = 0.00;

            //if (checkEligibilityCommon(FJCID, out StatusValue))
            //{
            //    return true;
            //}
            
            //CamperApplication oCA = new CamperApplication();

            /////*******************************************************************************************
            /////Is this your first time to attend a Non-profit Jewish overnight camp, for 3 weeks or longer:
            /////*******************************************************************************************                    
            //DataSet dsFirstTimeCamper;
            //dsFirstTimeCamper = oCA.getCamperAnswers(FJCID, "3", "3", "N");
            //DataRow drFTC;

            //if (dsFirstTimeCamper.Tables[0].Rows.Count > 0)
            //{
            //    drFTC = dsFirstTimeCamper.Tables[0].Rows[0];
            //    FirstTimeCamperOption = Convert.ToInt32(drFTC["OptionID"]);

            //    if (FirstTimeCamperOption == 2)//no
            //    {
            //        ///*************************
            //        ///Is this your second time?
            //        ///*************************
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
            //                    //*****************************************************************************************
            //                    //Did the camper receive an incentive grant through the Jewish Federation of Greater Dallas’ 
            //                    //Campership Incentive Program last summer?
            //                    //*****************************************************************************************
            //                    DataSet dsThirdTimeCamper;
            //                    dsThirdTimeCamper = oCA.getCamperAnswers(FJCID, "39", "39", "N");
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
            //        return true;
            //    }
            //    else
            //    {
            //        // Camper grade value must be between 3 - 10
            //        Grade = Convert.ToInt32(drGrade["Answer"]);
            //        if ((Grade >= 3) && (Grade <= 10))
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

            //// set the amount value

            //if (FirstTimeCamper)
            //{
            //    Amount = 1000.00;
            //}
            //else if (SecondTimeCamper)
            //{
            //    Amount = 1000.00;
            //}
            //else
            //{
            //    Amount = 0.00;
            //}

            //oCA.UpdateAmount(FJCID, Amount, 0, "");


            ////******************************************************************
            ////What kind of the school the camper go to
            ////If Jewish Day School is selected then a dropdown with 2 day school 
            ////******************************************************************

            //DataSet dsSchoolOption;
            //dsSchoolOption = oCA.getCamperAnswers(FJCID, "7", "7", "N");
            //DataRow drSchoolOption;

            //if (dsSchoolOption.Tables[0].Rows.Count > 0)
            //{
            //    drSchoolOption = dsSchoolOption.Tables[0].Rows[0];
            //    if (!string.IsNullOrEmpty(drSchoolOption["OptionID"].ToString()))
            //    {
            //        SchoolOption = Convert.ToInt32(drSchoolOption["OptionID"]);
            //        if (SchoolOption == 4)
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

            ////***********************************
            ////Camp check
            ////Have you registered for a camp yet?
            ////***********************************
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

            ////************************************************************
            ////Camp Session check - Eligible only if registered for 21 days 
            ////************************************************************
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
            //            oCA.UpdateAmount(FJCID, 0.00, 0, "");
            //            return true;
            //        }
            //        else
            //        {
            //            StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
            //        }

            //        oCA.UpdateAmount(FJCID, Amount, 0, "");
            //    }
            //}

            //return true;
        }
    }
}
