using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CIPMSBC;
using System.Web;
namespace CIPMSBC.Eligibility
{
    class EligibilityJWest:EligibilityBase
    {
        public EligibilityJWest(FederationEnum fed) : base(fed)
        {}

        public override bool checkEligibilityforStep2(string FJCID, out int StatusValue)
        {
            bool EligibleNoCamp = false;
            if (checkEligibilityCommon(FJCID, out StatusValue))
            {
                return true;
            }

            //Added by sandhya - Rename the variables to Second Timer from 3rd
            //to ineligible the first time campers
            int ThirdTimeCamperOption = 0;
            CamperApplication oCA = new CamperApplication();
            DataSet dsThirdTimeCamper;
            dsThirdTimeCamper = oCA.getCamperAnswers(FJCID, "3", "3", "N");
            DataRow drSTC;

            if (dsThirdTimeCamper.Tables[0].Rows.Count > 0)
            {
                drSTC = dsThirdTimeCamper.Tables[0].Rows[0];
                //To ineligible the first time campers
                if (!string.IsNullOrEmpty(drSTC["OptionID"].ToString()))
                {
                    ThirdTimeCamperOption = Convert.ToInt32(drSTC["OptionID"]);

					if (ThirdTimeCamperOption == 2)
					{
						StatusValue = (int)StatusInfo.SystemEligible;
					}
					else
					{
						StatusValue = (int)StatusInfo.SystemInEligible;
						return true;
					}
                }
            }

            StatusValue = StatusBasedOnSchool(FJCID, EligibleNoCamp, StatusValue);
          
            if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
            {
                return true;
            }
            return true;
        }

		public override bool checkEligibility(string FJCID, out int StatusValue)
		{
			int daysInCamp;
			double Amount = 0.00;
			bool EligibleNoCamp = false;

			if (checkEligibilityCommon(FJCID, out StatusValue))
			{
				return true;
			}
			General objGeneral = new General();
			CamperApplication oCA = new CamperApplication();

			StatusValue = StatusBasedOnCamp(FJCID, out EligibleNoCamp);

			daysInCamp = DaysInCamp(FJCID);

			if (daysInCamp < 12)
			{
				StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
				Amount = 0;
				return false;
			}

			string Previous2011FJCID = "", Previous2012FJCID = "";
			int Previous2011Status = 0, Previous2012Status = 0;
			double GrantAmount2011 = 0.0, GrantAmount2012 = 0.0;

			DataSet dsPreviousFJCIDs = objGeneral.GetPreviousFJCIDs(FJCID);

			DataRow[] ds2011ExistingCampers = dsPreviousFJCIDs.Tables[0].Select("campyearid=3");
			if (ds2011ExistingCampers.Length > 0)
			{
				Previous2011FJCID = ds2011ExistingCampers[0].ItemArray[0].ToString();
				Previous2011Status = Convert.ToInt32(ds2011ExistingCampers[0].ItemArray[6].ToString());
				GrantAmount2011 = Convert.ToDouble(ds2011ExistingCampers[0]["Amount"]);
			}

			DataRow[] ds2012ExistingCampers = dsPreviousFJCIDs.Tables[0].Select("campyearid=4");
			if (ds2012ExistingCampers.Length > 0)
			{
				Previous2012FJCID = ds2012ExistingCampers[0].ItemArray[0].ToString();
				Previous2012Status = Convert.ToInt32(ds2012ExistingCampers[0].ItemArray[6].ToString());
				GrantAmount2012 = Convert.ToDouble(ds2012ExistingCampers[0]["Amount"]);
			}

			if (Previous2011FJCID != "" && Previous2012FJCID != "")
			{
				Amount = 0.0;
				StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);

				if (!(Previous2012Status == 29 || Previous2012Status == 30 || Previous2012Status == 31 || Previous2012Status == 32
					|| Previous2011Status == 29 || Previous2011Status == 30 || Previous2011Status == 31 || Previous2011Status == 32))
				{
					if (GrantAmount2011 == 1000 && GrantAmount2012 == 1000)
					{
						StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
						Amount = 500;
					}
				}
			}
			else
			{
				Amount = 0.0;
				StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
			}

			// 2012-11-17 In Camp Year 2013, there will be JWest/JWest special codes with amount = 500.  Look at tblSpecialCodes for those 20 initial codes given by Val
			if (HttpContext.Current.Session["UsedCode"] != null)
			{
				string currentCode = HttpContext.Current.Session["UsedCode"].ToString();
				List<string> codes = SpecialCodeManager.GetAvailableJWestJWestLACodes(5);

				// when moved to .NET 3.5 or above, remember to use lamda expression
				foreach (string code in codes)
				{
					if (code == currentCode)
					{
						Amount = 500;
						StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
						int CampYearID = 5;
						if (HttpContext.Current.Application["CampYearID"] != null)
						{
							CampYearID = Convert.ToInt32(HttpContext.Current.Application["CampYearID"]);
						}
						SpecialCodeManager.UseCode(CampYearID, 3, currentCode, FJCID);
						break;
					}
				}
			}

			if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
			{
				oCA.UpdateAmount(FJCID, 0, 0, "");
				return true;
			}
			else
			{
				StatusValue = StatusBasedOnSchool(FJCID, EligibleNoCamp, StatusValue);
				if (StatusValue == Convert.ToInt32(StatusInfo.SystemInEligible))
				{
					oCA.UpdateAmount(FJCID, 0, 0, "");
					return true;
				}
				else
				{
					oCA.UpdateAmount(FJCID, Amount, 0, "");
					return true;
				}
			}
		}

        private int StatusBasedOnCamp(string FJCID, out bool EligibleNoCamp)
        {
            EligibleNoCamp = false;
            CamperApplication oCA = new CamperApplication();
            DataSet dsCamp;
            dsCamp = oCA.getCamperAnswers(FJCID, "10", "10", "N");
            DataRow drCamp;
            int CampID = 0;
            int StatusValue = (int)StatusInfo.SystemEligible;

            if (dsCamp.Tables[0].Rows.Count > 0)
            {
                drCamp = dsCamp.Tables[0].Rows[0];
                // Camper Camp value is null 
                if (DBNull.Value.Equals(drCamp["OptionID"]))
                {
                    StatusValue = Convert.ToInt32(StatusInfo.EligibleNoCamp);
                    oCA.UpdateAmount(FJCID, 0.00, 0, "");
                    EligibleNoCamp = true;
                }
                else
                {
                    CampID = Convert.ToInt32(drCamp["OptionID"]);
                    if (CampID == -1)
                    {
                        StatusValue = Convert.ToInt32(StatusInfo.EligibleNoCamp);
                        oCA.UpdateAmount(FJCID, 0.00, 0, "");
                        EligibleNoCamp = true;
                    }
                    else
                    {
                        StatusValue = Convert.ToInt32(StatusInfo.SystemEligible);
                    }
                }
            }
            
            return StatusValue;
        }

        private int StatusBasedOnSchool(string FJCID, bool EligibleNoCamp, int statusValue)
        {
            //What kind of the school the camper go to
            //Jewish day school ineligible
            int StatusValue = statusValue;
            int JewishSchool = 0,TimeInCamp = 0;
            DataSet dsJewishSchool, dsTimeInCamp;
            CamperApplication oCA = new CamperApplication();

            dsJewishSchool = oCA.getCamperAnswers(FJCID, "7", "7", "N");
            dsTimeInCamp = oCA.getCamperAnswers(FJCID, "3", "3", "N");

            DataRow drJewishSchool,drTimeInCamp;

            if (dsTimeInCamp.Tables[0].Rows.Count > 0)
            {
                drTimeInCamp = dsTimeInCamp.Tables[0].Rows[0];
                TimeInCamp = Convert.ToInt32(drTimeInCamp["OptionID"]);
            }


            if (dsJewishSchool.Tables[0].Rows.Count > 0)
            {
                drJewishSchool = dsJewishSchool.Tables[0].Rows[0];
                JewishSchool = Convert.ToInt32(drJewishSchool["OptionID"]);

                if ((JewishSchool == 4) && (TimeInCamp == 2))
                {
                    StatusValue = (int)StatusInfo.SystemEligible;
                    return StatusValue;
                }
                else if (JewishSchool == 4)
                {
                    StatusValue = (int)StatusInfo.SystemInEligible;
                }
                else if (JewishSchool == 3)
                {
                    if (EligibleNoCamp)
                    {
                        StatusValue = (int)StatusInfo.EligibleNoSchoolNoCamp;
                    }
                    else
                    {
                        StatusValue = (int)StatusInfo.PendingSchoolEligibility;
                    }
                }
                else
                {

                }
            }
            return StatusValue;
        }
    }
}
