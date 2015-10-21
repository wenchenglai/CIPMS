using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    class EligibilityLACIP:EligibilityBase
    {
        public EligibilityLACIP(FederationEnum fed) : base(fed)
        {
        }

        public override EligibilityResult checkEligibilityforStep2(string FJCID, out int StatusValue, string specialCode)
        {
            var result = new EligibilityResult();

            checkEligibilityCommon(FJCID, out StatusValue);
            result.CurrentUserStatusFromDB = (StatusInfo)StatusValue;

            StatusBasedOnCamperTimeInCampWithOutCamp(FJCID, out StatusValue);
            result.TimeInCamp = (StatusInfo)StatusValue;

            StatusValue = StatusBasedOnGrade(FJCID, StatusValue);
            result.Grade = (StatusInfo)StatusValue;

            StatusValue = StatusBasedOnSchool(FJCID, StatusValue, specialCode);
            result.SchoolType = (StatusInfo)StatusValue;

            return result;
        }

        private int StatusBasedOnGrade(string FJCID, int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsGrade;
            dsGrade = oCA.getCamperAnswers(FJCID, "6", "6", "N");
            DataRow drGrade;
            int iStatusValue = -1;
            int Grade;
            DataSet dsLAHist = new DataSet();
            bool isinLALookup = false;
            bool firstTimeCamper, secondTimeCamper;

            if (dsGrade.Tables[0].Rows.Count > 0)
            {
                drGrade = dsGrade.Tables[0].Rows[0];
                if (DBNull.Value.Equals(drGrade["Answer"]))
                {
                    iStatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
                }
                else
                {
                    // Eligible grades for LA CIP 1st time camper: 3-5, 9 & 11 (6-8 goes to Jwest)
                    //changes made by Ram  
                    UserDetails UserInfo = oCA.getCamperInfo(FJCID);
                    firstTimeCamper = secondTimeCamper = false;
                    if(UserInfo.FirstName != null && UserInfo.LastName != null)
                        dsLAHist = new General().GetLAFederationForCamper(UserInfo.FirstName, UserInfo.LastName,UserInfo.DateofBirth);
                    if (dsLAHist.Tables[0].Rows.Count > 0)
                    {
                        secondTimeCamper = true;
                    }
                    if (!secondTimeCamper)
                    {
                        if (TimeInCamp(FJCID) == 1)
                            firstTimeCamper = true;
                        else if (TimeInCamp(FJCID) >= 2)
                            secondTimeCamper = true;
                    }
                    General objGeneral = new General();
                    Grade = Convert.ToInt32(drGrade["Answer"]);
                    if (firstTimeCamper)
                    {
                       
                        if (objGeneral.GetEligiblityForGrades(FJCID, Grade.ToString()) == "1")
                        {
                            StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
                        }
                        else
                        {
                            StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
                        }
                    }
                    else if (secondTimeCamper)
                    {
                        if (objGeneral.GetEligiblityForGrades(FJCID, Grade.ToString()) == "1")
                        {
                            StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
                        }
                        else
                        {
                            StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
                        }
                    }
                    //// Eligible grades for LA CIP: 3-5, 9-11 (6-8 goes to Jwest)
                    //Grade = Convert.ToInt32(drGrade["Answer"]);
                    //if ( ((Grade >= 3) && (Grade <= 5)) || ((Grade >= 9) && (Grade <= 11)) ) 
                    //{
                    //    iStatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
                    //}
                    //else
                    //{
                    //    iStatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
                    //}
                }
            }
            if (iStatusValue == -1)
                iStatusValue = StatusValue;

            return iStatusValue;
        }


        private int StatusBasedOnSchool(string FJCID, int StatusValue, string specialCode = "None")
        {
            CamperApplication oCA = new CamperApplication();
            int iStatusValue = -1;

            DataSet dsSchoolOption;
            dsSchoolOption = oCA.getCamperAnswers(FJCID, "7", "7", "N");
            DataRow drSchoolOption;
            int SchoolOption;
            bool IsRepitingCamper = false;

            IsRepitingCamper = IsCamperRepiting(FJCID);

            if (dsSchoolOption.Tables[0].Rows.Count > 0)
            {
                drSchoolOption = dsSchoolOption.Tables[0].Rows[0];
                if (!string.IsNullOrEmpty(drSchoolOption["OptionID"].ToString()))
                {
                    SchoolOption = Convert.ToInt32(drSchoolOption["OptionID"]);
                                       
                   
                        if (SchoolOption == 4) 
                        {
                        iStatusValue = (int)AllowDaySchool(FJCID);
                        if (iStatusValue == (int)StatusInfo.SystemInEligible)
                        {
                            if (specialCode == "PJGTC2016")
                                iStatusValue = (int)StatusInfo.EligiblePJLottery;
                        }
                    }
                        else
                        {
                            iStatusValue = (int)StatusInfo.SystemEligible;
                        }
                   
                }
            }
            if (iStatusValue == -1)
                iStatusValue = StatusValue;

            return iStatusValue;
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

        private int StatusBasedOnSibling(string FJCID, int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();
            int iStatusValue = -1;

            DataSet dsIncentiveGrant;
            dsIncentiveGrant = oCA.getCamperAnswers(FJCID, "22", "22", "N");
            DataRow drIncentiveGrant;
            int SiblingIncentiveOption = 0;

            if (TimeInCamp(FJCID) == 1)
            {
                if (dsIncentiveGrant.Tables[0].Rows.Count > 0)
                {
                    drIncentiveGrant = dsIncentiveGrant.Tables[0].Rows[0];
                    SiblingIncentiveOption = Convert.ToInt32(drIncentiveGrant["OptionID"]);
                    if (SiblingIncentiveOption == 1)
                    {
                        iStatusValue = (int)StatusInfo.SystemInEligible;
                    }
                    else
                    {
                        iStatusValue = (int)StatusInfo.SystemEligible;
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

            daysInCamp = DaysInCamp(FJCID);

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

            StatusValue = StatusBasedOnSibling(FJCID, StatusValue);
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
            //actually we should not have this status - the UI does not allow NEXT 
            //if a camp was not selected
            else if (StatusValue == Convert.ToInt32(StatusInfo.EligibleNoCamp))
            {
                if (TimeInCamp(FJCID) == 1)
                {
                    Amount = 1500.00;
                    oCA.UpdateAmount(FJCID, Amount, 0, "");
                    return true;
                }
                else if (TimeInCamp(FJCID) == 2)
                {
                    Amount = 500.00;
                    oCA.UpdateAmount(FJCID, Amount, 0, "");
                    return true;
                }
            }

            //daysInCamp = DaysInCamp(FJCID);
            if (daysInCamp > 0)
            {
                Amount = getCamperGrant(FJCID, daysInCamp, out StatusValue);
            }
            oCA.UpdateAmount(FJCID, Amount, 0, "");
            return true;

            //int FirstTimeCamperOption = 0;
            //int SecondTimeCamperOption = 0;
            //int IncentiveOption = 0;

            //Boolean FirstTimeCamper = false;
            //Boolean SecondTimeCamper = false;
            ////int JewishSchool = 0;
            ////int Grade = 0;
            //StatusValue = 0;
            //double Amount = 0.00;

            //if (checkEligibilityCommon(FJCID, out StatusValue))
            //{
            //    return true;
            //}
            
            //CamperApplication oCA = new CamperApplication();


            ////Is this your first time to attend a Non-profit Jewish overnight camp, for 3 weeks or longer:

            //DataSet dsFirstTimeCamper;
            //dsFirstTimeCamper = oCA.getCamperAnswers(FJCID, "23", "23", "N");
            //DataRow drFTC;

            //if (dsFirstTimeCamper.Tables[0].Rows.Count > 0)
            //{
            //    drFTC = dsFirstTimeCamper.Tables[0].Rows[0];
            //    FirstTimeCamperOption = Convert.ToInt32(drFTC["OptionID"]);

            //    if (FirstTimeCamperOption == 2)
            //    {
            //        DataSet dsSecondTimeCamper;
            //        dsSecondTimeCamper = oCA.getCamperAnswers(FJCID, "24", "24", "N");
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
            //                    oCA.UpdateAmount(FJCID, 0.00, 0, "");
            //                    return true;
            //                }
            //                else
            //                {
            //                    DataSet dsThirdTimeCamper;
            //                    dsThirdTimeCamper = oCA.getCamperAnswers(FJCID, "21", "21", "N");
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

            //DataSet dsIncentiveGrant;
            //dsIncentiveGrant = oCA.getCamperAnswers(FJCID, "22", "22", "N");
            //DataRow drIncentiveGrant;
            //int SiblingIncentiveOption = 0;

            //if (FirstTimeCamper)
            //{
            //    if (dsIncentiveGrant.Tables[0].Rows.Count > 0)
            //    {
            //        drIncentiveGrant = dsIncentiveGrant.Tables[0].Rows[0];
            //        SiblingIncentiveOption = Convert.ToInt32(drIncentiveGrant["OptionID"]);
            //        if (SiblingIncentiveOption == 1)
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
            //            Amount = 1500.00;
            //        }
            //        if (SecondTimeCamper)
            //        {
            //            Amount = 500.00;
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
            //                Amount = 1500.00;
            //            }
            //            if (SecondTimeCamper)
            //            {
            //                Amount = 500.00;
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

            //        if (iDays < 19)
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
            //                Amount = 1500.00;
            //            }
            //            if (SecondTimeCamper)
            //            {
            //                Amount = 500.00;
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
