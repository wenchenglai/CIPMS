namespace CIPMSBC.Eligibility
{
	/// <summary>
	/// Determines and returns the proper eligibility business logic class
	/// </summary>
	public class EligibilityFactory
	{
		/// <summary>
		/// Factory method returning a class based on the federation parameter
		/// </summary>
		/// <returns>An Eligibility Business Logic class</returns>
		public static EligibilityBase GetEligibility(FederationEnum fed, int campId = -1)
		{
			EligibilityBase elig = null;
			switch (fed)
			{
				case FederationEnum.Arkansas:
					elig = new EligibilityArkansas(fed);
					break;
				case FederationEnum.Baltimore:
					elig = new EligibilityBaltimore(fed);
					break;
				case FederationEnum.Barney:
					elig = new EligibilityBarney(fed);
					break;
				case FederationEnum.Berkshire:
					elig = new EligibilityBerkshire(fed);
					break;
				case FederationEnum.Bnai:
					elig = new EligibilityBnai(fed);
					break;
				case FederationEnum.Boston:
					elig = new EligibilityBoston(fed);
					break;
				case FederationEnum.CampChi:
					elig = new EligibilityChi(fed);
					break;
				case FederationEnum.CampSabra:
					elig = new EligibilitySabra(fed);
					break;
				case FederationEnum.Chicago:
					elig = new EligibilityChicago(fed);
					break;
				case FederationEnum.Cincinatti:
					elig = new EligibilityCincinatti(fed);
					break;
				case FederationEnum.CMART:
					elig = new EligibilityCMART(fed);
					break;
				case FederationEnum.Columbus:
					elig = new EligibilityColumbus(fed);
					break;
				case FederationEnum.Dallas:
					elig = new EligibilityDallas(fed);
					break;
				case FederationEnum.Greensboro:
					elig = new EligibilityGreensboro(fed);
					break;
				case FederationEnum.Indianapolis:
					elig = new EligibilityIndianapolis(fed);
					break;
				case FederationEnum.JCCRanchCamp:
					elig = new EligibilityJCCRanch(fed);
					break;
				case FederationEnum.Judea:
					elig = new EligibilityJudea(fed);
					break;
				case FederationEnum.JWest:
					elig = new EligibilityJWest(fed);
					break;
				case FederationEnum.JWestLA:
					elig = new EligibilityJWestLA(fed);
					break;
				case FederationEnum.Kansas:
					elig = new EligibilityKansas(fed);
					break;
				case FederationEnum.LACIP:
					elig = new EligibilityLACIP(fed);
					break;
				case FederationEnum.MetroWest:
					elig = new EligibilityMetroWest(fed);
					break;
				case FederationEnum.Middlesex:
					elig = new EligibilityMiddlesex(fed);
					break;
				case FederationEnum.NageelaMidwest:
					elig = new EligibilityNageelaMidwest(fed);
					break;
				case FederationEnum.NJY:
					elig = new EligibilityNJY(fed);
					break;
				case FederationEnum.NY:
					elig = new EligibilityNY(fed);
					break;
				case FederationEnum.Orange:
					elig = new EligibilityOrange(fed);
					break;
				case FederationEnum.URJ:
					elig = new EligibilityURJ(fed);
					break;
				case FederationEnum.NorthShore:
					elig = new EligibilityNorthShore(fed);
					break;
				case FederationEnum.Philadelphia:
					elig = new EligibilityPhiladelphia(fed);
					break;
				case FederationEnum.Ramah:
					elig = new EligibilityRamah(fed);
					break;
				case FederationEnum.PalmBeach:
					elig = new EligibilityPalmBeach(fed);
					break;
				case FederationEnum.Miami:
					elig = new EligibilityMiami(fed);
					break;
				case FederationEnum.CAiryLouise:
					elig = new EligibilityCAiryLouise(fed);
					break;
				case FederationEnum.NewHamshire:
					elig = new EligibilityNewHampshire(fed);
					break;
				case FederationEnum.CapitalCamps:
					elig = new EligibilityCapital(fed);
					break;
				case FederationEnum.Adamahadventures:
					elig = new EligibilityAdamahAdventures(fed);
					break;
				case FederationEnum.Memphis:
					elig = new EligibilityMemphis(fed);
					break;
				case FederationEnum.WashingtonDC:
					elig = new EligibilityWashingtonDC(fed);
					break;
				case FederationEnum.SixPointsSportsAcadamy:
					elig = new EligibilitySportsAcadamy(fed);
					break;
				case FederationEnum.SolomonSchechter:
					elig = new EligibilitySolomonSchechter(fed);
					break;
				case FederationEnum.Cleveland:
					elig = new EligibilityCleveland(fed);
					break;
				case FederationEnum.Pittsburgh:
					elig = new EligibilityPittsburgh(fed);
					break;
				case FederationEnum.Louemma:
					elig = new EligibilityLouemma(fed);
					break;
				case FederationEnum.BBOttawa:
					elig = new EligibilityBBOttawa(fed);
					break;
				case FederationEnum.LMAN:
					elig = new EligibilityLman(fed);
					break;
				case FederationEnum.Calgary:
					elig = new EligibilityCalgary(fed);
					break;
				case FederationEnum.Habonim:
					elig = new EligibilityHabonim(fed, campId);
					break;
				case FederationEnum.NNJ:
					elig = new EligibilityNNJ(fed);
					break;
				case FederationEnum.Eden:
					elig = new EligibilityEdenVillage(fed);
					break;
				case FederationEnum.PJL:
					elig = new EligibilityPJL(fed);
					break;
				case FederationEnum.CJA:
					elig = new EligibilityCJA(fed);
					break;
				case FederationEnum.Avoda:
					elig = new EligibilityAvoda(fed);
					break;
				case FederationEnum.BIMA:
					elig = new EligibilityBIMA(fed);
					break;
				case FederationEnum.Laurelwood:
					elig = new EligibilityLaurelwood(fed);
					break;
				case FederationEnum.Montreal:
					elig = new EligibilityMontreal(fed);
					break;
				case FederationEnum.RhodeIsland:
					elig = new EligibilityRhodeIsland(fed);
					break;
				case FederationEnum.Livingston:
					elig = new EligibilityLivingston(fed);
					break;
				case FederationEnum.SanDiego:
					elig = new EligibilitySanDiego(fed);
					break;
				case FederationEnum.MountainChai:
					elig = new EligibilityMountainChai(fed);
					break;
				case FederationEnum.CNJ:
					elig = new EligibilityCNJ(fed);
					break;
				case FederationEnum.Hatikvah:
					elig = new EligibilityHatikvah(fed);
					break;
				case FederationEnum.Charles:
					elig = new EligibilityCharles(fed);
					break;
				case FederationEnum.Omaha:
					elig = new EligibilityOmaha(fed);
					break;
				case FederationEnum.SurpriseLake:
					elig = new EligibilitySurpriseLake(fed);
					break;
				case FederationEnum.Poyntelle:
					elig = new EligibilityPoyntelle(fed);
					break;
				case FederationEnum.StLouis:
					elig = new EligibilityStLouis(fed);
					break;
				case FederationEnum.NageelaEast:
					elig = new EligibilityNageelaEast(fed);
					break;
				case FederationEnum.PassportNYC:
					elig = new EligibilityPassportNYC(fed);
					break;
				case FederationEnum.Louisville:
					elig = new EligibilityLouisville(fed);
					break;
				case FederationEnum.CNY:
					elig = new EligibilityCNY(fed);
					break;
				case FederationEnum.Colorado:
					elig = new EligibilityColorado(fed);
					break;
				case FederationEnum.Shomria:
					elig = new EligibilityShomria(fed);
					break;
				case FederationEnum.PalmSprings:
					elig = new EligibilityPalmSprings(fed);
					break;
				case FederationEnum.SanFrancisco:
					elig = new EligibilitySanFrancisco(fed);
					break;
				case FederationEnum.Seattle:
					elig = new EligibilitySeattle(fed);
					break;
				case FederationEnum.Milwaukee:
					elig = new EligibilityMilwaukee(fed);
					break;
				case FederationEnum.Hartford:
					elig = new EligibilityHartford(fed);
					break;
				case FederationEnum.JRF:
					elig = new EligibilityJRF(fed);
					break;
				case FederationEnum.ElPaso:
					elig = new EligibilityElPaso(fed);
					break;
				case FederationEnum.JCAShalom:
					elig = new EligibilityJCAShalom(fed);
					break;
				case FederationEnum.MoshavaMalibu:
					elig = new EligibilityMoshavaMalibu(fed);
					break;
				case FederationEnum.Toronto:
					elig = new EligibilityToronto(fed);
					break;
				case FederationEnum.Zeke:
					elig = new EligibilityZeke(fed);
					break;
				case FederationEnum.Atlanta:
					elig = new EligibilityAtlanta(fed);
					break;
				case FederationEnum.Nashville:
					elig = new EligibilityHartford(fed);
					break;
				case FederationEnum.Portland:
					elig = new EligibilityPortland(fed);
					break;
				case FederationEnum.RamahBerkshires:
					elig = new EligibilityRamahBerkshires(fed);
					break;
                case FederationEnum.RamahCanada:
                    elig = new EligibilityRamahCanada(fed);
                    break;
			}
			return elig;
		}

	}
}
