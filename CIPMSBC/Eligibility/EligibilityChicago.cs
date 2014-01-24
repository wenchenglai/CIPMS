using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    class EligibilityChicago:EligibilityBase
    {
        public EligibilityChicago(FederationEnum fed) : base(fed)
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

        private int StatusBasedOnSchool(string FJCID, int StatusValue, out bool PendingSchool)
        {
            CamperApplication oCA = new CamperApplication();
            int iStatusValue = -1;
            int JewishSchool;
            int SchoolOption = 0;
            DataSet dsSchoolOption;
            dsSchoolOption = oCA.getCamperAnswers(FJCID, "1", "1", "7,17");
            DataRow drSchoolOption;
            DataRow drJewishSchool;
            PendingSchool = false;

            if (dsSchoolOption.Tables[0].Rows.Count > 0)
            {
                drSchoolOption = dsSchoolOption.Tables[0].Rows[0];
                if (!string.IsNullOrEmpty(drSchoolOption["OptionID"].ToString()))
                {
                    SchoolOption = Convert.ToInt32(drSchoolOption["OptionID"]);
                    drJewishSchool = dsSchoolOption.Tables[0].Rows[1];
                    JewishSchool = Convert.ToInt32(drJewishSchool["OptionID"]);
                    if (SchoolOption == 4)
                    {
						// 2012-06-23 Allow Days School to rgister now
						//iStatusValue = (int)StatusInfo.SystemEligible;
						//iStatusValue = (int)StatusInfo.SystemInEligible;

						// 2012-09-23 Chicago allows certain days schools to register
						//if (JewishSchool == 3)
						//{
						//    iStatusValue = (int)StatusInfo.EligiblePendingSchool;
						//    PendingSchool = true;
						//}
						if ((JewishSchool == 1) || (JewishSchool == 4) || (JewishSchool == 5) || (JewishSchool == 6) || (JewishSchool == 9))
						{
						    iStatusValue = (int)StatusInfo.SystemEligible;
						}
						//else if (JewishSchool == 7 || JewishSchool == 10)
						//{
						//    iStatusValue = (int)StatusInfo.SystemInEligible;
						//}
						else
						{
						    //iStatusValue = (int)StatusInfo.SystemInEligible;
                            // 2013-12-12 Now even other Jewish schools will be eligible for Chicago Coupons
                            iStatusValue = (int)StatusInfo.SystemEligible;
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

        public override bool checkEligibility(string FJCID, out int StatusValue)
        {
            StatusValue = 0;
            int daysInCamp;
            double Amount = 0.00;
            bool PendingSchool = false;

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

            daysInCamp = DaysInCamp(FJCID);
            if (daysInCamp > 0)
            {
                Amount = getCamperGrant(FJCID, daysInCamp, out StatusValue);
            }
            else
            {
                StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
                Amount = 0;
                return true;
            }

            if (Amount > 0)
            {
                double OriginalAmount = Amount;
                // 2013-07-23 Chicago Sibling Rule - if this camper has sibling attended before, no matter how many days
                // of camping, the amount is only 500.
                Amount = 500;
                DataSet dsSchoolOption = oCA.getCamperAnswers(FJCID, "1032", "1032", "N");
                if (dsSchoolOption.Tables[0].Rows.Count > 0)
                {
                    DataRow drSchoolOption = dsSchoolOption.Tables[0].Rows[0];
                    if (!string.IsNullOrEmpty(drSchoolOption["OptionID"].ToString()))
                    {
                        if ("2" == drSchoolOption["OptionID"].ToString())
                        {
                            Amount = OriginalAmount;
                        }
                    }
                }
            }

            if (StatusValue == Convert.ToInt32(StatusInfo.SystemEligible))
            {
                // 2013-12-12 Chicago Coupon for other Day School campers: either $120, $240, $360
                DataSet dsAnswers = oCA.getCamperAnswers(FJCID, "", "", "17, 1047, 1051");
                if (dsAnswers.Tables[0].Rows.Count > 0)
                {
                    DataRow[] drs = dsAnswers.Tables[0].Select("QuestionId = 17");
                    if (drs.Length == 1)
                    {
                        if (drs[0]["OptionID"].ToString() == "3")
                        {
                            StatusValue = Convert.ToInt32(StatusInfo.EligibleCampCoupon);
                            Amount = 120;  // Minimally, other day school campers can get $120 coupon

                            foreach (DataRow dr in dsAnswers.Tables[0].Rows)
                            {
                                int qID = Convert.ToInt32(dr["QuestionId"]);

                                if (qID == 1047) // Did the camper attend a Jewish preschool?
                                {
                                    if (!dr["OptionID"].Equals(DBNull.Value))
                                        if (dr["OptionID"].ToString() == "1")
                                            Amount += 120;
                                }
                                else if (qID == 1051) // Did the camper attend a Jewish day camp?
                                {
                                    if (!dr["OptionID"].Equals(DBNull.Value))
                                        if (dr["OptionID"].ToString() == "1")
                                            Amount += 120;
                                }
                            }
                        }
                    }
                }
            }

            oCA.UpdateAmount(FJCID, Amount, 0, "");
            return true;
        }
    }
}
