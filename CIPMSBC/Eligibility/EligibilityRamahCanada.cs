using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    class EligibilityRamahCanada : EligibilityBase
    {
        public EligibilityRamahCanada(FederationEnum fed)
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

            StatusValue = StatusBasedOnSchool(FJCID, StatusValue, out PendingSchool);
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
            double amount = 0.00;
            if (daysInCamp > 0)
            {
                amount = getCamperGrant(FJCID, daysInCamp, out StatusValue);
            }

            if (amount > 0)
            {
                // 2015 Kibbutz Bob Waldorf or Camp Gesher is always $250
                if (amount != 250)
                {
                    double originalAmount = amount;
                    // 2015-09-27 Sibling Rule - if this camper has sibling attended before, no matter how many days
                    // of camping, the amount is only 500.
                    amount = 500;
                    DataSet dsSchoolOption = oCA.getCamperAnswers(FJCID, "1032", "1032", "N");
                    if (dsSchoolOption.Tables[0].Rows.Count > 0)
                    {
                        DataRow drSchoolOption = dsSchoolOption.Tables[0].Rows[0];
                        if (!string.IsNullOrEmpty(drSchoolOption["OptionID"].ToString()))
                        {
                            if ("2" == drSchoolOption["OptionID"].ToString())
                            {
                                amount = originalAmount;
                            }
                        }
                    }
                }
            }

            oCA.UpdateAmount(FJCID, amount, 0, "");

            if (amount == 0.00)
                StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);

            return true;
        }
    }
}
