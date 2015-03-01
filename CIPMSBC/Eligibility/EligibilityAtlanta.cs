using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
	class EligibilityAtlanta : EligibilityBase
	{
		private int intCampID = 0;
		private int intSynagogueID = 0;

        public EligibilityAtlanta(FederationEnum fed)
			: base(fed)
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

		private int StatusBasedOnSchool(string FJCID, int StatusValue, string specialCode = "None")
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
						if (specialCode == "PJGTC2015")
							iStatusValue = (int)StatusInfo.PendingPJLottery;
						else
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
                string q1 = "", q1a = "", q1b = "", q1c = "";
                string campID = "";
                var CamperAppl = new CamperApplication();
                DataSet dsAnswers = CamperAppl.getCamperAnswers(FJCID, "", "", "3,10,1063,1066,1067");

                foreach (DataRow dr in dsAnswers.Tables[0].Rows)
                {
                    int qID = Convert.ToInt32(dr["QuestionId"]);

                    if (qID == 3) // Is this your first time to attend a Non-profit Jewish overnight camp, for 3 weeks or longer:
                    {
                        if (dr["OptionID"].Equals(DBNull.Value))
                            continue;

                        if (dr["OptionID"].ToString() == "1")
                        {
                            q1 = "yes";
                        }
                        else
                        {
                            q1 = "no";
                        }
                    }
                    if (qID == 10)
                    {
                        if (dr["Answer"].Equals(DBNull.Value))
                            continue;

                        campID = dr["Answer"].ToString();
                    }
                    else if (qID == 1063)
                    {
                        if (dr["OptionID"].Equals(DBNull.Value))
                            continue;

                        if (dr["OptionID"].ToString() == "1")
                            q1a = "12";
                        else if (dr["OptionID"].ToString() == "2")
                            q1a = "19";
                    }
                    else if (qID == 1066) // Did your camper receive a One Happy Camper last year through the Jewish Federation of Greater Atlanta?
                    {
                        if (dr["OptionID"].Equals(DBNull.Value))
                            continue;

                        if (dr["OptionID"].ToString() == "1")
                            q1b = "yes";
                        else if (dr["OptionID"].ToString() == "2")
                            q1b = "no";
                    }
                    else if (qID == 1067) // Is your combined gross household income $160,000 or less?
                    {
                        if (dr["OptionID"].Equals(DBNull.Value))
                            continue;

                        if (dr["OptionID"].ToString() == "1")
                            q1c = "yes";
                        else if (dr["OptionID"].ToString() == "2")
                            q1c = "no";
                    }
                }

                if (q1 == "no")
                {
                    if (q1a == "12")
                    {
                        if (q1b == "yes")
                        {
                            if (q1c == "yes")
                            {
                                Amount = 500;
                            }                            
                        }
                        else
                        {
                            if (daysInCamp >= 19)
                            {
                                Amount = 1000;
                            }
                            else if (daysInCamp == 18 && campID == "6147") // 2015/10/28 temporary code used ONLY in 2015
                            {
                                var userInfo = CamperAppl.getCamperInfo(FJCID);
                                var code = userInfo.SpecialCode;
                                if (code == "AA2015ATL159" || code == "AA2015ATL357" || code == "AA2015ATL963" || code == "AA2015ATL784" || code == "AA2015ATL658" || code == "AA2015ATL224")
                                    Amount = 1000;
                            }                            
                        }
                    }
                    else if (q1a == "19")
                    {
                        if (q1b == "yes")
                        {
                            if (q1c == "yes")
                            {
                                Amount = 500;
                            }
                        }
                    }
                }
                else
                {
                    Amount = getCamperGrant(FJCID, daysInCamp, out StatusValue);
                }

                // 2015-01-27  Kibbutz Max Straus and Gesher at Kibbutz Max Straus must be 250 no matter what
                // a candidate for global grant rule
			    if (Amount > 0)
			    {
                    string last3Digits = campID.Substring(campID.Length - 3);
			        if (last3Digits == "211" || last3Digits == "218")
			        {
			            Amount = 250;
			        }
			    }

				if (Amount <= 0)
                    StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
				
                oCA.UpdateAmount(FJCID, Amount, 0, "");

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
