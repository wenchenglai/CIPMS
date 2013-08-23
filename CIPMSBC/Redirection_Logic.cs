using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace CIPMSBC
{
    /// <summary>
    /// Summary description for Redirection_Logic
    /// </summary>
    public class Redirection_Logic
    {
        public string _FJCID;
        private int _currentFederationId=0;
        private int _nextFederationId=0;
        private bool _isValidMiiPCodeEntered=false;
        private bool _isValidPJLCodeEntered=false;
        private bool _isSandiegoZipCode=false;
        private bool _isColoradoZipCode = false;
        private bool _isPalmSpringsZipCode = false;
		private bool _isSanFranciscoZipCode = false;

        public string _NextFederationURL="";
        private bool _beenToMiiP=false;
        private bool _beenToPJL=false;
        private bool _beenToSandiego=false;
        private bool _beenToColorado = false;
        private bool _beenToPalmSprings = false;
		private bool _beenToSanFrancisco = false;

        public int _pageName = 0;
        public bool _appSubmitted = false;
        private bool _isLACIPZipCode = false;
        private bool _beenToLACIP = false;

        public enum PageNames
        {            
            Step1= 1 ,
            Step1_Questions = 2 ,
            ThankYou = 3,
            Step2_1 = 4,
            Step2_2 = 5,
            Step2_3 = 6,
            Step1_NL=7,
            Step3_OtherInfo=8

        }

        public string FJCID
        {
            get { return _FJCID; }
            set { _FJCID = value; }
        }
        
        public int CurrentFederationId
        {
            get { return _currentFederationId; }
            set { _currentFederationId = value; }
        }

        public int NextFederationId
        {
            get { return _nextFederationId; }
            set { _nextFederationId = value; }
        }

        public bool IsValidMiiPCodeEntered
        {
            get { return _isValidMiiPCodeEntered; }
            set { _isValidMiiPCodeEntered = value; }
        }

        public bool IsValidPJLCodeEntered
        {
            get { return _isValidPJLCodeEntered; }
            set { _isValidPJLCodeEntered = value; }
        }

        public bool IsColoradoZipCode
        {
            get { return _isColoradoZipCode; }
            set { _isColoradoZipCode = value; }
        }
        public bool IsSandiegoZipCode
        {
            get { return _isSandiegoZipCode; }
            set { _isSandiegoZipCode = value; }
        }

        public bool IsPalmSpringsZipCode
        {
            get { return _isPalmSpringsZipCode; }
            set { _isPalmSpringsZipCode = value; }
        }

		public bool IsSanFranciscoZipCode
		{
			get { return _isSanFranciscoZipCode; }
			set { _isSanFranciscoZipCode = value; }
		}

        public string NextFederationURL
        {
            get { return _NextFederationURL; }
            set { _NextFederationURL = value; }
        }

        public bool BeenToMiiP
        {
            get { return _beenToMiiP; }
            set { _beenToMiiP = value; }
        }

        public bool BeenToPJL
        {
            get { return _beenToPJL; }
            set { _beenToPJL = value; }
        }

        public bool BeenToSandiego
        {
            get { return _beenToSandiego; }
            set { _beenToSandiego = value; }
        }

		public bool BeenToSanFrancisco
		{
			get { return _beenToSanFrancisco; }
			set { _beenToSanFrancisco = value; }
		}

        public bool BeenToColorado
        {
            get { return _beenToColorado; }
            set { _beenToColorado = value; }
        }

        public bool BeenToPalmSprings
        {
            get { return _beenToPalmSprings; }
            set { _beenToPalmSprings = value; }
        }

        public int PageName
        {
            get { return _pageName; }
            set { _pageName = value; }
        }

        public bool AppSubmitted
        {
            get { return _appSubmitted; }
            set { _appSubmitted = value; }
        }
        public bool IsLACIPZipCode
        {
            get { return _isLACIPZipCode; }
            set { _isLACIPZipCode = value; }
        }
        public bool BeenToLACIP
        {
            get { return _beenToLACIP; }
            set { _beenToLACIP = value; }
        }

        /// <summary>
        /// GetNextFederationDetails: Assign FJCID property and call this function
        /// </summary>
        public void GetNextFederationDetails(string strFJCID)
        {
            if (!String.IsNullOrEmpty(strFJCID))
            {
                FJCID = strFJCID;
                GetCamperApplicationDetails(FJCID);
            }
            switch (CurrentFederationId)
            {
                case 3:
                    {
						//If JWest then Sandiego (Same ZipCode) else normal flow (MiiP, PJL & NL)
                        if (IsSandiegoZipCode && !BeenToSandiego) 
						{ 
							NextFederationId = 72; 
						}
						else if (IsSanFranciscoZipCode && !BeenToSandiego)
						{
							NextFederationId = 98;
						}
                        else if (IsColoradoZipCode && !BeenToColorado) { NextFederationId = 93; } //If JWest then Colorado (Same ZipCode) else normal flow (MiiP, PJL & NL)
                        else if (IsPalmSpringsZipCode && !BeenToPalmSprings) { NextFederationId = 95; } //If JWest then Colorado (Same ZipCode) else normal flow (MiiP, PJL & NL)
                        else if (IsLACIPZipCode && !BeenToLACIP) { NextFederationId = 23; } else goto default; //If JWest then LACIP else normal flow 
                    }
                    break;
                case 4:
                    {                        
                        if (IsLACIPZipCode && !BeenToLACIP) { NextFederationId = 23; } else goto default; //If JWest-LA then LACIP else normal flow 
                    }
                    break;
                case 48: { if (IsValidMiiPCodeEntered && !BeenToMiiP) NextFederationId = 48; else if (IsValidPJLCodeEntered && !BeenToPJL && BeenToMiiP) NextFederationId = 63; else goto case 63; } break; //if already in MiiP then next would be PJL if PJLCode provided else NL
                case 63: { if (IsValidPJLCodeEntered && !BeenToPJL) NextFederationId = 63; else if (IsValidPJLCodeEntered && BeenToPJL) NextFederationId = ((PageNames)PageName == PageNames.ThankYou ? 0 : CurrentFederationId); } break;//changed by ram to fix bug in step1_questions page when navigating to NL of incomplete application } 
                            
                default:
                    {
                        Redirection_Logic_WithCodes();
                    }
                    break;
            }
            NextFederationDetails();
        }

        /// <summary>
        /// GetCamperApplicationDetails (CurrentFederation, PJLCode,MiiPCode,SadiegoZipCode if JWest,etc  required for the redirection logic from the FJCID)
        /// </summary>
        /// <param name="FJCID"></param>
        private void GetCamperApplicationDetails(string FJCID)
        {
            CamperApplication _objCamperApplication = new CamperApplication();
            DataSet dsCamperApplication = _objCamperApplication.getCamperApplication(FJCID);
            string zipCode = string.Empty;
            string pjlCode = string.Empty;
            string camperID = string.Empty;
            if (dsCamperApplication.Tables.Count > 0)
            {
                if (dsCamperApplication.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsCamperApplication.Tables[0].Rows[0];
                    if (String.IsNullOrEmpty(dr["CMART_MiiP_ReferalCode"].ToString()))
                        IsValidMiiPCodeEntered = false;
                    else IsValidMiiPCodeEntered = true;

                    if (String.IsNullOrEmpty(dr["PJLCode"].ToString()))
                        IsValidPJLCodeEntered = false;
                    else { IsValidPJLCodeEntered = true; pjlCode = dr["PJLCode"].ToString(); }

                    if (String.IsNullOrEmpty(dr["FederationId"].ToString()))
                        CurrentFederationId = 0;
                    else CurrentFederationId = Int32.Parse(dr["FederationId"].ToString());

                    if (!String.IsNullOrEmpty(dr["Zip"].ToString()))
                        zipCode = dr["Zip"].ToString();

                    if(!String.IsNullOrEmpty(dr["CamperID"].ToString()))
                        camperID = dr["CamperID"].ToString();
                }
            }
            if (zipCode != String.Empty)
            {
                General _objGeneral = new General();
                DataSet dsFederation = _objGeneral.GetFederationForZipCode(zipCode);
                if (dsFederation.Tables.Count > 0)
                {
                    if (dsFederation.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsFederation.Tables[0].Rows[0];
                        if (dr["Federation"].ToString() == "72")
                            IsSandiegoZipCode = true;
                        else 
                            IsSandiegoZipCode = false;

                        if (dr["Federation"].ToString() == "93")
                            IsColoradoZipCode = true;
                        else 
                            IsColoradoZipCode = false;

                        if (dr["Federation"].ToString() == "95")
                            IsPalmSpringsZipCode = true;
                        else
                            IsPalmSpringsZipCode = false;

						if (dr["Federation"].ToString() == "98")
							IsSanFranciscoZipCode = true;
						else
							IsSanFranciscoZipCode = false;						
                    }
                }
            }
            else
            {
                IsSandiegoZipCode = false;
                IsColoradoZipCode = false;
                IsPalmSpringsZipCode = false;
				IsSanFranciscoZipCode = false;
            }

            if (zipCode != String.Empty)
            {
                General _objGeneral = new General();
                DataSet dsFederation = _objGeneral.GetFederationForZipCode(zipCode);
                if (dsFederation.Tables.Count > 0)
                {
                    if (dsFederation.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsFederation.Tables[0].Rows[0];
                        if (dr["Federation"].ToString() == "23")
                            IsLACIPZipCode = true;
                        else IsLACIPZipCode = false;
                    }
                }
            }
            else
                IsLACIPZipCode = false;

            if (camperID != string.Empty) // This will check if the camper has already submitted MiiP/PJL application using this redirection logic
            {
                DataSet dsListOfDeletedCamperApplications = new DataSet();
                DataRow[] drArray = new DataRow[0];
                dsListOfDeletedCamperApplications = _objCamperApplication.GetCamperApplicationsFromCamperID(camperID);
                if(dsListOfDeletedCamperApplications.Tables.Count > 0)
                    if (dsListOfDeletedCamperApplications.Tables[0].Rows.Count > 0)
                    {
                        drArray = dsListOfDeletedCamperApplications.Tables[0].Select("Type='D'", "FJCID ASC");
                    }
                if (drArray.Length > 0)
                {
                    foreach (DataRow dr in drArray)
                    {
                        if (dr["FederationID"].ToString() == "72") BeenToSandiego = true;
						if (dr["FederationID"].ToString() == "98") BeenToSanFrancisco = true;
                        if (dr["FederationID"].ToString() == "93") BeenToColorado = true;
                        if (dr["FederationID"].ToString() == "23") BeenToLACIP = true;
                        if (dr["FederationID"].ToString() == "48") BeenToMiiP = true;
                        if (dr["FederationID"].ToString() == "63" || pjlCode.ToLower() == ConfigurationManager.AppSettings["SpecialPJLCode"].ToLower()) BeenToPJL = true;
                    }
                }
            }
        }

        /// <summary>
        /// Gets Federation details (Federation details required for the redirection logic from the FJCID
        /// </summary>
        /// <param name="FJCID"></param>
        private void SetFederationUrl(string federationId)
        {
            General _objGeneral = new General();
            DataSet dsFederationDetails = _objGeneral.GetFederationDetails(federationId);
            if (dsFederationDetails.Tables.Count > 0)
                if (dsFederationDetails.Tables[0].Rows.Count > 0)
                    NextFederationURL = dsFederationDetails.Tables[0].Rows[0]["NavigationURL"].ToString();
        }


        private void Redirection_Logic_WithCodes()
        {
            if (IsValidMiiPCodeEntered && !BeenToMiiP)
                NextFederationId = 48;
            else if (IsValidPJLCodeEntered && !BeenToPJL)
                NextFederationId = 63;
            else
                NextFederationId = ((PageNames)PageName == PageNames.ThankYou ? 0 : CurrentFederationId); //changed by ram to fix bug in step1_questions page when navigating to NL of incomplete application
        }


        private void NextFederationDetails()
        {
            if (NextFederationId == 0)
                NextFederationURL = "Step1_NL.aspx";
            else
            {
                SetFederationUrl(NextFederationId.ToString());
            }
        }
    }
}
