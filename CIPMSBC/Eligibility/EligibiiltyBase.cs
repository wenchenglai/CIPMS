using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIPMSBC.Eligibility
{
    /// <summary>
    /// Base class for each individual eligibility business logic module
    /// </summary>
    public abstract class EligibilityBase
    {
        protected FederationEnum myFederation;

        public EligibilityBase(FederationEnum fed)
        {
            myFederation = fed;
        }

        public abstract bool checkEligibility(string FJCID, out int StatusValue);
        
		public abstract bool checkEligibilityforStep2(string FJCID, out int StatusValue);

        public struct structCamperGrantInfo
        {
            public long FJCID;
            public int FederationID;
            public int CampID;
            public int TimeInCamp;
            public int CampYearID;
            public int DaysInCamp;
            public bool OverProjection;
            public decimal GrantAmount;
            public decimal StandardGrant;
            public decimal FJCMatch;
        }

        public decimal GetCamperGrantForDays(string FJCID, int Days)
        {
            CamperApplication oCA = new CamperApplication();
            return oCA.getCamperGrantForDays(FJCID, Days);
        }

        public structCamperGrantInfo GetCamperGrantInfo(string FJCID)
        {
            structCamperGrantInfo CamperGrantInfo = new structCamperGrantInfo();
            DataSet dsCamperGrant;
            DataRow drCamperGrant;
 
            CamperApplication oCA = new CamperApplication();
            dsCamperGrant = oCA.getCamperGrantInfo(FJCID);
            if (dsCamperGrant.Tables[0].Rows.Count > 0)
            {
                drCamperGrant = dsCamperGrant.Tables[0].Rows[0];

                if (!Convert.IsDBNull(drCamperGrant["FJCID"]))
                    CamperGrantInfo.FJCID = Convert.ToInt64(drCamperGrant["FJCID"]);

                if (!Convert.IsDBNull(drCamperGrant["FederationID"]))
                    CamperGrantInfo.FederationID = Convert.ToInt16(drCamperGrant["FederationID"]);

                if (!Convert.IsDBNull(drCamperGrant["CampID"]))
                    CamperGrantInfo.CampID = Convert.ToInt16(drCamperGrant["CampID"]);

                if (!Convert.IsDBNull(drCamperGrant["TimeInCamp"]))
                    CamperGrantInfo.TimeInCamp = Convert.ToInt16(drCamperGrant["TimeInCamp"]);

                if (!Convert.IsDBNull(drCamperGrant["CampYearID"]))
                    CamperGrantInfo.CampYearID = Convert.ToInt16(drCamperGrant["CampYearID"]);

                if (!Convert.IsDBNull(drCamperGrant["DaysInCamp"]))
                    CamperGrantInfo.DaysInCamp = Convert.ToInt16(drCamperGrant["DaysInCamp"]);

                if (!Convert.IsDBNull(drCamperGrant["OverProjection"]))
                    CamperGrantInfo.OverProjection = Convert.ToBoolean(drCamperGrant["OverProjection"]);


                if (!Convert.IsDBNull(drCamperGrant["GrantAmount"]))
                    CamperGrantInfo.GrantAmount = Convert.ToDecimal(drCamperGrant["GrantAmount"]);

                if (!Convert.IsDBNull(drCamperGrant["StandardGrant"]))
                    CamperGrantInfo.StandardGrant = Convert.ToDecimal(drCamperGrant["StandardGrant"]);

                if (!Convert.IsDBNull(drCamperGrant["FJCMatch"]))
                    CamperGrantInfo.FJCMatch = Convert.ToDecimal(drCamperGrant["FJCMatch"]);
            }
            
            return CamperGrantInfo;
        }

        public static int getCampID(string FJCID)
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsCamperApplication;
            DataRow drCamper;
            int CampID = 0;

            dsCamperApplication = oCA.getCamperApplication(FJCID);
            if (dsCamperApplication.Tables[0].Rows.Count > 0)
            {
                drCamper = dsCamperApplication.Tables[0].Rows[0];
                if (!Convert.IsDBNull(drCamper["Camp"]))
                    CampID = Convert.ToInt16(drCamper["Camp"]);
            }
            return CampID;
        }

        public static int getDaysInCamp(string FJCID)
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsCamperApplication;
            DataRow drCamper;
            int Days = 0;

            dsCamperApplication = oCA.getCamperApplication(FJCID);
            if (dsCamperApplication.Tables[0].Rows.Count > 0)
            {
                drCamper = dsCamperApplication.Tables[0].Rows[0];
                if (!Convert.IsDBNull(drCamper["Days"]))
                    Days = Convert.ToInt16(drCamper["Days"]);
            }

            //if number of days was not entered by Camp Director
            //it needs to be retirieved from a camper application
            if (Days == 0)
            {
                DataSet dsCampSession;
                dsCampSession = oCA.getCamperAnswers(FJCID, "12", "12", "N");
                DataRow drStartDate;
                DataRow drEndDate;

                if (dsCampSession.Tables[0].Rows.Count > 1)
                {
                    drStartDate = dsCampSession.Tables[0].Rows[0];
                    drEndDate = dsCampSession.Tables[0].Rows[1];
                    if (!string.IsNullOrEmpty(drStartDate["Answer"].ToString()) && 
                        !string.IsNullOrEmpty(drEndDate["Answer"].ToString()))
                    {
                        try
                        {
                            string strStartDate = Convert.ToString(drStartDate["Answer"]);
                            string strEndDate = Convert.ToString(drEndDate["Answer"]);

                            DateTime dtStartDate = Convert.ToDateTime(strStartDate);
                            DateTime dtEndDate = Convert.ToDateTime(strEndDate);

                            TimeSpan span = dtEndDate.Subtract(dtStartDate);
                            Days = span.Days + 1;
                        }
                        catch { Days = 0; }  //in case of wrong data
                    }
                }
            }
            return Days;
        }

        public static void checkEligibilityDays2(string FJCID, int CampDays, out int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();
            decimal StandardGrant = 0;
            bool SecondApprovalNeeded = false;

            DataSet dsCamperApplication;
            dsCamperApplication = oCA.getCamperApplication(FJCID);
            DataRow drCamper;

            if (dsCamperApplication.Tables[0].Rows.Count > 0)
            {
                drCamper = dsCamperApplication.Tables[0].Rows[0];
                if (!Convert.IsDBNull(drCamper["SecondApproval"]))
                    SecondApprovalNeeded = Convert.ToBoolean(drCamper["SecondApproval"]);
            }

            StandardGrant = oCA.getCamperGrantForDays(FJCID, CampDays);

            if (StandardGrant > 0)
            { 
                if (SecondApprovalNeeded)
                    StatusValue = Convert.ToInt32(StatusInfo.SecondApproval);
                else
                    StatusValue = Convert.ToInt32(StatusInfo.PaymentPending);
            }
            else
                StatusValue = Convert.ToInt32(StatusInfo.IneligibleBasedonDays);
    
            
               
        }

        public static void checkEligibilityDays(string FJCID, int CampDays, out int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();

            Boolean TwoWeeksSession = false;
            Boolean ThreeWeeksSession = false;
            Boolean SecondApprovalNeeded = false;

            DataSet dsCamperApplication;
            dsCamperApplication = oCA.getCamperApplication(FJCID);
            DataRow drCamper;

            if (dsCamperApplication.Tables[0].Rows.Count > 0)
            {
                drCamper = dsCamperApplication.Tables[0].Rows[0];
                SecondApprovalNeeded = Convert.ToBoolean(drCamper["SecondApproval"]);
            }

            DataSet dsCampSession;
            dsCampSession = oCA.getCamperAnswers(FJCID, "12", "12", "N");
            DataRow drStartDate;
            DataRow drEndDate;

            StatusValue = Convert.ToInt32(StatusInfo.RegAcceptedCamp);

            if (dsCampSession.Tables[0].Rows.Count > 1)
            {
                drStartDate = dsCampSession.Tables[0].Rows[0];
                drEndDate = dsCampSession.Tables[0].Rows[1];
                if (!string.IsNullOrEmpty(drStartDate["Answer"].ToString()))
                {
                    string strStartDate = Convert.ToString(drStartDate["Answer"]);
                    string strEndDate = Convert.ToString(drEndDate["Answer"]);

                    DateTime dtStartDate = Convert.ToDateTime(strStartDate);
                    DateTime dtEndDate = Convert.ToDateTime(strEndDate);
                    //int iDays = DateTime.
                    TimeSpan span = dtEndDate.Subtract(dtStartDate);
                    int iDays = span.Days + 1;

                    if ((iDays > 11) && (iDays < 19))
                    {
                        TwoWeeksSession = true;
                    }
                    if ((iDays > 18))
                    {
                        ThreeWeeksSession = true;
                    }


                    if (TwoWeeksSession || ThreeWeeksSession)
                    {
                        if (TwoWeeksSession)
                        {
                            if (CampDays > 11)
                            {
                                if (SecondApprovalNeeded)
                                {
                                    StatusValue = Convert.ToInt32(StatusInfo.SecondApproval);
                                }
                                else
                                {
                                    StatusValue = Convert.ToInt32(StatusInfo.PaymentPending);
                                }
                            }
                            else
                            {
                                StatusValue = Convert.ToInt32(StatusInfo.IneligibleBasedonDays);
                            }
                        }
                        if (ThreeWeeksSession)
                        {
                            if (CampDays > 18)
                            {
                                if (SecondApprovalNeeded)
                                {
                                    StatusValue = Convert.ToInt32(StatusInfo.SecondApproval);
                                }
                                else
                                {
                                    StatusValue = Convert.ToInt32(StatusInfo.PaymentPending);
                                }
                            }
                            else
                            {
                                StatusValue = Convert.ToInt32(StatusInfo.IneligibleBasedonDays);
                            }
                        }

                    }
                    else
                    {
                        StatusValue = Convert.ToInt32(StatusInfo.IneligibleBasedonDays);
                    }
                }

            }
            else
            {
                StatusValue = Convert.ToInt32(StatusInfo.IneligibleBasedonDays);
            }
        }

        protected int calculateAge(DateTime Birthdate)
        {
            int iAge;
            if (DateTime.Now.Month < 6)
            {
                iAge = (DateTime.Now.Year - Birthdate.Year) - 1;
                return iAge;
            }
            else
            {
                iAge = (DateTime.Now.Year - Birthdate.Year);
                return iAge;
            }
        }

        protected int calNoOfSaturdays(DateTime dtStartDate, DateTime dtEndDate)
        {
            int NoOfSaturdays = 0;

            for (int i = 0; dtStartDate <= dtEndDate; i++)
            {
                if (dtStartDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    NoOfSaturdays = NoOfSaturdays + 1;
                }
                dtStartDate = dtStartDate.AddDays(1);
            }
            return NoOfSaturdays;
        }

        protected void calculateJCCRanchCampGrant(int iDays, Boolean FirstTimeCamper, Boolean SecondTimeCamper, out int Status, out double Amount)
        {
            if ((iDays > 18))
            {
                Status = Convert.ToInt32(StatusInfo.SystemEligible);
                if (FirstTimeCamper)
                {
                    Amount = 1500.00;
                }
                else if (SecondTimeCamper)
                {
                    Amount = 1000.00;
                }
                else
                {
                    Amount = 0;
                    Status = Convert.ToInt32(StatusInfo.SystemInEligible);
                }
            }
            else if (iDays > 13 && iDays < 19)
            {
                Status = Convert.ToInt32(StatusInfo.SystemEligible);
                if (FirstTimeCamper)
                {
                    Amount = 1000.00;
                }
                else if (SecondTimeCamper)
                {
                    Amount = 600.00;
                }
                else
                {
                    Amount = 0;
                    Status = Convert.ToInt32(StatusInfo.SystemInEligible);
                }
            }
            else
            {
                Amount = 0;
                Status = Convert.ToInt32(StatusInfo.SystemInEligible);
            }
        }

        protected int DaysInCamp(string FJCID)
        {
            int days = 0;
            CamperApplication oCA = new CamperApplication();
            days = oCA.getDaysInCamp(FJCID);
            return days;
        }

        protected int TimeInCamp(string FJCID)
        {
            int timeInCamp = 0;
            CamperApplication oCA = new CamperApplication();
            timeInCamp = oCA.getTimeInCamp(FJCID);
            return timeInCamp;
        }

        protected int NumberOfSaturdays(string FJCID)
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsCampSession;
            dsCampSession = oCA.getCamperAnswers(FJCID, "12", "12", "N");
            DataRow drStartDate;
            DataRow drEndDate;
            int NumbOfSat = 0;

            if (dsCampSession.Tables[0].Rows.Count > 1)
            {
                drStartDate = dsCampSession.Tables[0].Rows[0];
                drEndDate = dsCampSession.Tables[0].Rows[1];
                if (!string.IsNullOrEmpty(drStartDate["Answer"].ToString()))
                {
                    string strStartDate = Convert.ToString(drStartDate["Answer"]);
                    string strEndDate = Convert.ToString(drEndDate["Answer"]);

                    DateTime dtStartDate = Convert.ToDateTime(strStartDate);
                    DateTime dtEndDate = Convert.ToDateTime(strEndDate);
                    //int iDays = DateTime.
                    TimeSpan span = dtEndDate.Subtract(dtStartDate);
                    
                    NumbOfSat = calNoOfSaturdays(dtStartDate, dtEndDate);
                }
            }
            return NumbOfSat;
        }

        protected double getCamperGrant(string FJCID, int days, out int StatusValue)
        {
            double grant = 0;
            CamperApplication oCA = new CamperApplication();
            grant = (double)oCA.getCamperGrantForDays(FJCID, days);

            if (grant > 0)
                StatusValue = (int)StatusInfo.SystemEligible;
            else
                StatusValue = (int)StatusInfo.SystemInEligible;

            return grant;
        }

        protected double getCamperDefaultAmount(string FJCID, int days)
        {
            double grant = 0;
            CamperApplication oCA = new CamperApplication();
            grant = (double)oCA.getCamperDefaultAmount(FJCID, days);

            return grant;
        }

        /// <summary>
        /// Common code to use to check Eligibility called by all subclasses
        /// </summary>
        /// <param name="FJCID"></param>
        /// <param name="StatusValue"></param>
        /// <returns>true if eligibility was determined or false if more checking is needed</returns>
        protected bool checkEligibilityCommon(string FJCID, out int StatusValue)
        {
            CamperApplication CamperAppl = new CamperApplication();
            if (CamperAppl.CamperStatusDetectived(FJCID, (int)StatusInfo.SecondApproval))
            {
                //Get the current status of the camper
                StatusValue = GetCamperStatus(FJCID);

				CamperAppl = null;
				return true;
            }

            CamperAppl = null;
            StatusValue = 0;
            return false;
        }

        protected int GetCamperStatus(string FJCID)
        {
            CamperApplication CamperAppl = new CamperApplication();
            DataSet dsApp = CamperAppl.getCamperApplication(FJCID);
            int StatusValue = Convert.ToInt16(dsApp.Tables[0].Rows[0]["Status"]);

            CamperAppl = null;
            return StatusValue;
        }

        protected bool IsCamperRepiting(string FJCID)
        {
            General objGeneral = new General();
            UserDetails UserInfo;
            CamperApplication CamperAppl = new CamperApplication();
            UserInfo = CamperAppl.getCamperInfo(FJCID);

            DataSet dsLAHist = objGeneral.GetLAFederationForCamper(UserInfo.FirstName, UserInfo.LastName,UserInfo.DateofBirth);
            if (dsLAHist.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void StatusBasedOnCamperTimeInCampWithOutCamp(string FJCID, out int StatusValue)
        {
            CamperApplication oCA = new CamperApplication();
            DataSet dsCamperTimeInCampWithOutCamp;
            dsCamperTimeInCampWithOutCamp = oCA.GetCamperTimeInCampWithOutCamp(FJCID);
            DataRow drCamperTimeInCampWithOutCamp;
            int Grade = 0;

            if (dsCamperTimeInCampWithOutCamp.Tables[0].Rows.Count > 0)
            {
                drCamperTimeInCampWithOutCamp = dsCamperTimeInCampWithOutCamp.Tables[0].Rows[0];
                if (DBNull.Value.Equals(drCamperTimeInCampWithOutCamp["TimeInCampEligible"]))
                {
                    StatusValue = Convert.ToInt32(StatusInfo.SystemInEligible);
                }
                else
                {
                    if (drCamperTimeInCampWithOutCamp["TimeInCampEligible"].ToString() == "1")
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

    }
}
