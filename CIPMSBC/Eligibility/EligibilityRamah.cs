using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    class EligibilityRamah : EligibilityBase
    {
        public EligibilityRamah(FederationEnum fed): base(fed)
        {
        }
        public override bool checkEligibilityforStep2(string FJCID, out int StatusValue)
        {
            bool PendingSchool = false;
            if (checkEligibilityCommon(FJCID, out StatusValue))
            {
                return true;
            }

            //StatusBasedOnCamperTimeInCampWithOutCamp(FJCID, out StatusValue);
            //if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            //{
            //    return true;
            //}
            StatusValue = CheckOnTimeInCamp(FJCID);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                return true;
            }

            StatusValue = StatusBasedOnGrade(FJCID, StatusValue);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                return true;
            }

            StatusValue = StatusBasedOnSchool(FJCID, StatusValue, out PendingSchool);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                return true;
            }

            return true;
        }

        private int CheckOnTimeInCamp(string FJCID)
        {
            int iStatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
            var oCA = new CamperApplication();
            var dsAnswers = oCA.getCamperAnswers(FJCID, "1", "1", "3,10,13,33");
            var timeInCamp = Convert.ToInt32(dsAnswers.Tables[0].Select("QuestionID = 3")[0]["OptionID"]);
            var campId = dsAnswers.Tables[0].Select("QuestionID = 10")[0]["Answer"].ToString();
            var last3Digits = campId.Substring(campId.Length - 3);

            var list = new List<string>
            {
                "079", "083", "150"
            };

            if (timeInCamp == 1)
                iStatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
            else if (list.Contains(last3Digits))
            {
                var isSecondTime = Convert.ToInt32(dsAnswers.Tables[0].Select("QuestionID = 13")[0]["OptionID"]);
                var drs = dsAnswers.Tables[0].Select("QuestionID = 33");
                if (drs.Length > 0)
                {
                    if (!DBNull.Value.Equals(drs[0]["OptionID"]))
                    {
                        var lastSummer = Convert.ToInt32(drs[0]["OptionID"]);
                        // allow second time camper if both are true
                        if (isSecondTime == 1 && lastSummer == 1)
                            iStatusValue = Convert.ToInt32(StatusInfo.SystemEligible);                        
                    }
                }
            }

            return iStatusValue;
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
            var dsAnswers = oCA.getCamperAnswers(FJCID, "1", "1", "6,10");
            var campId = dsAnswers.Tables[0].Select("QuestionID = 10")[0]["Answer"].ToString();
            int grade = Convert.ToInt32(dsAnswers.Tables[0].Select("QuestionID = 6")[0]["Answer"]);
            string last3Digits = campId.Substring(campId.Length - 3);

            int iStatusValue = Convert.ToInt32(StatusInfo.SystemInEligible); ;

            if (last3Digits == "079") // California
            {
                if (grade > 2 && grade < 11)
                    iStatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
            }
            else
            {
                var objGeneral = new General();
                if (objGeneral.GetEligiblityForGrades(FJCID, grade.ToString()) == "1")
                {
                    iStatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
                }                
            }
 
            return iStatusValue;
        }

        private int StatusBasedOnSchool(string FJCID, int StatusValue, out bool PendingSchool)
        {
            PendingSchool = false;
            return (int)StatusInfo.SystemEligible;
            //var oCA = new CamperApplication();
            //var dsSchoolOption = oCA.getCamperAnswers(FJCID, "1", "1", "7,10");
            //int iStatusValue = (int)StatusInfo.SystemInEligible;
            //PendingSchool = false;

            //if (dsSchoolOption.Tables[0].Rows.Count > 0)
            //{
            //    var schoolTypeId = dsSchoolOption.Tables[0].Select("QuestionID = 7")[0]["OptionID"].ToString();
            //    var campId = dsSchoolOption.Tables[0].Select("QuestionID = 10")[0]["Answer"].ToString();
            //    string last3digits = campId.Substring(campId.Length - 3);

            //    if (schoolTypeId == "4")
            //    {
            //        if (last3digits == "082")
            //        {
            //            iStatusValue = (int)StatusInfo.SystemEligible;
            //        }
            //    }
            //    else
            //    {
            //        iStatusValue = (int)StatusInfo.SystemEligible;
            //    }
            //}

            //return iStatusValue;
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

            StatusValue = StatusBasedOnSchool(FJCID, StatusValue, out PendingSchool);
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
            double Amount = 0;
            if (daysInCamp > 0)
            {
                var dsSchoolOption = oCA.getCamperAnswers(FJCID, "1", "1", "3,7,10");

                var timeInCamp = dsSchoolOption.Tables[0].Select("QuestionID = 3")[0]["OptionID"].ToString();
                var schoolTypeId = dsSchoolOption.Tables[0].Select("QuestionID = 7")[0]["OptionID"].ToString();
                var campId = dsSchoolOption.Tables[0].Select("QuestionID = 10")[0]["Answer"].ToString();
                string last3Digits = campId.Substring(campId.Length - 3);

                if (last3Digits == "082") // Berkshires
                {
                    if (daysInCamp >= 19 && schoolTypeId == "4")
                        Amount = 500;
                    else if (daysInCamp >= 19)
                        Amount = 1000;
                }
                else if (last3Digits == "079") // California
                {
                    if (timeInCamp == "1" && daysInCamp >= 19)
                        Amount = 1000;
                    else if (timeInCamp == "1" && daysInCamp >= 12)
                        Amount = 700;
                    else if (timeInCamp == "2" && daysInCamp >= 19)
                        Amount = 750;
                    else if (timeInCamp == "2" && daysInCamp >= 12)
                        Amount = 500;
                }
                else if (last3Digits == "080" || last3Digits == "084") // Canada, Wisconsin
                {
                    if (daysInCamp >= 19)
                        Amount = 1000;
                }
                else if (last3Digits == "083") // Poconos
                {
                    if (timeInCamp == "1" && daysInCamp >= 19)
                        Amount = 1000;
                    else if (timeInCamp == "2" && daysInCamp >= 19)
                        Amount = 750;
                }
                else if (last3Digits == "150") // Outdoor Adventure
                {
                    if (timeInCamp == "1" && daysInCamp >= 19)
                        Amount = 1000;
                    else if (timeInCamp == "1" && daysInCamp >= 12)
                        Amount = 700;
                    else if (timeInCamp == "2" && daysInCamp >= 19)
                        Amount = 700;
                    else if (timeInCamp == "2" && daysInCamp >= 12)
                        Amount = 500;
                }
                else // all other camps
                    Amount = getCamperGrant(FJCID, daysInCamp, out StatusValue);
            }
            else
            {
                StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
            }

            oCA.UpdateAmount(FJCID, Amount, 0, "");

            if (Amount == 0.00)
                StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);

            return true;

            
        }
    }
}
