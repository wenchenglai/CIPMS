using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    class EligibilityURJ:EligibilityBase
    {
        public EligibilityURJ(FederationEnum fed) : base(fed)
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

        private int StatusBasedOnSchool(string FJCID, int StatusValue, string specialCode = "None")
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsJewishSchool = oCA.getCamperAnswers(FJCID, "", "", "7, 10");

            int iStatusValue = -1;

            if (dsJewishSchool.Tables[0].Rows.Count > 0)
            {
                DataRow drJewishSchool = dsJewishSchool.Tables[0].Select("QuestionID = 7")[0];
                // 2013-09-08 URJ Six Points Sci-Tech is the only camp allows day school
                string CampID = dsJewishSchool.Tables[0].Select("QuestionID = 10")[0]["Answer"].ToString();
                string last3digits = CampID.Substring(CampID.Length - 3);

                if (!string.IsNullOrEmpty(drJewishSchool["OptionID"].ToString()))
                {
                    int JewishSchoolOption = Convert.ToInt32(drJewishSchool["OptionID"]);

                    if (JewishSchoolOption == 4)
                    {
                        if (specialCode == "PJGTC2015")
                            iStatusValue = (int)StatusInfo.PendingPJLottery;
                        else
                            iStatusValue = (int)StatusInfo.SystemInEligible;
                    }
                    else
                    {
                        iStatusValue = (int)StatusInfo.SystemEligible;
                    }

                    if (last3digits == "190") // URJ Six Points Sci-Tech
                    {
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
        }
    }
}
