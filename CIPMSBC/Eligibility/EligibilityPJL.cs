using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    public class EligibilityPJL : EligibilityBase
    {
        public EligibilityPJL(FederationEnum fed)
            : base(fed)
        {
        }
        public override bool checkEligibilityforStep2(string FJCID, out int StatusValue)
        {
            //if (checkEligibilityCommon(FJCID, out StatusValue))
            //{
            //    return true;
            //}
            //StatusBasedOnCamperTimeInCampWithOutCamp(FJCID, out StatusValue);
            //if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            //{
            //    return true;
            //} 
            //StatusBasedOnGrade(FJCID, out StatusValue);
            //if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            //{
            //    return true;
            //}
            //StatusBasedOnSchool(FJCID, out StatusValue);
            //if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            //{
            //    return true;
            //}
            //return true;
            StatusValue = 3;
            return true;
        }

        public bool checkEligibilityforStep2(string FJCID, out int StatusValue, StatusInfo currentStatus)
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
            StatusBasedOnGrade(FJCID, out StatusValue);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                return true;
            }
            StatusBasedOnSchool(FJCID, out StatusValue, currentStatus);
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                return true;
            }
            return true;
        }
        private int StatusBasedOnCamp(string FJCID, int StatusValue)
        {
            return Convert.ToInt32(StatusInfo.SystemEligible);

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
                            // 2016-07-04 EligibleNoCamp is no longer existing from now on, and it's possible for PJL to have no camp selected
                            iStatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
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

        private void StatusBasedOnSchool(string FJCID, out int StatusValue, StatusInfo currentStatus)
        {
            //StatusValue = (int)StatusInfo.SystemEligible;
            //return;

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
                        //StatusValue = (int)StatusInfo.SystemInEligible;
                        
                        // 2014-10-14 if regular PJ program user chooses JDS (typically from zip code with no community program), we automatically mark it PendingLottery
                        StatusValue = (int)StatusInfo.EligiblePJLottery;

                        //2014-08-20 If it's EligiblePJLottery, we temporarily make it eligible, so the process can still keep the EligiblePJLottery on Step2_2
                        if (currentStatus == StatusInfo.EligiblePJLottery)
                            StatusValue = (int)StatusInfo.SystemEligible;
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
            
            StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
            return;

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
            CamperApplication oCA = new CamperApplication();
            StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
            daysInCamp = DaysInCamp(FJCID);
            if (daysInCamp > 11)
            {
                Amount = getCamperGrant(FJCID, daysInCamp, out StatusValue);
                if (Amount == 0)
                {
                    StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
                }
                else
                {
                    StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
                }
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
