using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    class EligibilityMilwaukee : EligibilityBase
    {
        private int intCampID = 0;
        private int intSynagogueID = 0;

		public EligibilityMilwaukee(FederationEnum fed)
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
                        intCampID = CampID;
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

            DataSet dsJewishSchool;
            dsJewishSchool = oCA.getCamperAnswers(FJCID, "7", "7", "N");
            DataRow drJewishSchool;
            int JewishSchoolOption;

            if (dsJewishSchool.Tables[0].Rows.Count > 0)
            {
                drJewishSchool = dsJewishSchool.Tables[0].Rows[0];
                if (!string.IsNullOrEmpty(drJewishSchool["OptionID"].ToString()))
                {
                    JewishSchoolOption = Convert.ToInt32(drJewishSchool["OptionID"]);

                    if (JewishSchoolOption == 4)
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
        private int StatusBasedOnSynagogue(string FJCID, int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsSynagogue;
            dsSynagogue = oCA.getCamperAnswers(FJCID, "31", "31", "N");
            DataRow drSynagogue;
            string Synagogue;
            if (dsSynagogue.Tables[0].Rows.Count > 0)
            {
                drSynagogue = dsSynagogue.Tables[0].Rows[0];
                if (DBNull.Value.Equals(drSynagogue["Answer"]))
                {
                    intSynagogueID = 0;
                }
                else
                {
                    if (!drSynagogue["OptionID"].Equals(DBNull.Value))
                        if (drSynagogue["OptionID"].ToString() == "1")
                            if (!drSynagogue["Answer"].Equals(DBNull.Value))
                            {
                                Synagogue = drSynagogue["Answer"].ToString();
                                intSynagogueID = Convert.ToInt32(Synagogue);
                            }
                }
            }

            return intSynagogueID;
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
            intSynagogueID = StatusBasedOnSynagogue(FJCID, StatusValue);
            daysInCamp = DaysInCamp(FJCID);
            if (daysInCamp > 0)
            {
                // Commented by Rajesh
                //if (intCampID == 1138 && intSynagogueID == 1221)
                //{
                Amount = getCamperGrant(FJCID, daysInCamp, out StatusValue);
                oCA.UpdateAmount(FJCID, Amount, 0, "");
                //}
                //else
            
                    //Amount = getCamperDefaultAmount(FJCID, daysInCamp);                       
                    //oCA.UpdateAmount(FJCID, Amount, 0, "");
            }
            else
            {
                StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
                Amount = 0;
                oCA.UpdateAmount(FJCID, Amount, 0, "");
            }

            
            return true;
                        
        }
    }
}
