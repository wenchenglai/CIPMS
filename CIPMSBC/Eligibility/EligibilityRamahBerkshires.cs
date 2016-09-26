using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    class EligibilityRamahBerkshires : EligibilityBase
    {
        public EligibilityRamahBerkshires(FederationEnum fed)
            : base(fed)
        {
        }
        public override bool checkEligibilityforStep2(string FJCID, out int StatusValue)
        {
            bool PendingSchool = false;
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

            StatusBasedOnSchool(FJCID, out StatusValue);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                return true;
            }

            return true;
        }

        private int StatusBasedOnCamp(string FJCID, int StatusValue, bool PendingSchool)
        {
            var oCA = new CamperApplication();
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
                            if (PendingSchool)
                            {
                                iStatusValue = Convert.ToInt32(StatusInfo.PendingSchoolAndCamp);
                            }
                            else
                            {
                                iStatusValue = Convert.ToInt32(StatusInfo.EligibleNoCamp);
                            }
                        }
                        else
                        {
                            if (PendingSchool)
                            {
                                iStatusValue = (int)StatusInfo.EligiblePendingSchool;
                            }
                            else
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

        private int StatusBasedOnGrade(string FJCID, int StatusValue)
        {
            var oCA = new CamperApplication();
            var dsAnswers = oCA.getCamperAnswers(FJCID, "1", "1", "6");
            int grade = Convert.ToInt32(dsAnswers.Tables[0].Select("QuestionID = 6")[0]["Answer"]);

            int iStatusValue = Convert.ToInt32(StatusInfo.SystemInEligible); ;

            var objGeneral = new General();
            if (objGeneral.GetEligiblityForGrades(FJCID, grade.ToString()) == "1")
            {
                iStatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
            }   
 
            return iStatusValue;
        }

        private void StatusBasedOnSchool(string FJCID, out int StatusValue, string specialCode = "None")
        {
            CamperApplication oCA = new CamperApplication();
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
                        StatusValue = (int)AllowDaySchool(FJCID);
                        if (StatusValue == (int)StatusInfo.SystemInEligible)
                        {
                            if (specialCode == "PJGTC2017")
                                StatusValue = (int)StatusInfo.EligiblePJLottery;
                        }
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

        public override bool checkEligibility(string FJCID, out int StatusValue)
        {
            StatusValue = 0;
            bool PendingSchool = false;

            if (checkEligibilityCommon(FJCID, out StatusValue))
            {
                return true;
            }

            var oCA = new CamperApplication();

            StatusValue = StatusBasedOnGrade(FJCID, StatusValue);
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

            StatusValue = StatusBasedOnCamp(FJCID, StatusValue, PendingSchool);
            if (StatusValue != Convert.ToInt32(StatusInfo.SystemEligible))
            {
                oCA.UpdateAmount(FJCID, 0.00, 0, "");
                return true;
            }

            int daysInCamp = DaysInCamp(FJCID);
            double amount = 0.00;
            if (daysInCamp > 0)
            {
                var dsSchoolOption = oCA.getCamperAnswers(FJCID, "1", "1", "7");
                var schoolTypeId = dsSchoolOption.Tables[0].Select("QuestionID = 7")[0]["OptionID"].ToString();

                // Berkshires has special rule that allow Jewish Day School, 19+ days camper for $500
                if (daysInCamp >= 19 && schoolTypeId == "4")
                    amount = 500;
                else if (schoolTypeId != "4")
                    amount = getCamperGrant(FJCID, daysInCamp, out StatusValue);
            }

            oCA.UpdateAmount(FJCID, amount, 0, "");

            if (amount == 0.00)
                StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);

            return true;
        }
    }
}
