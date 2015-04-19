using System.ComponentModel;

namespace CIPMSBC
{
	public enum FederationEnum
	{
        Cincinatti = 1,
        Middlesex = 2,
        JWest = 3,
        JWestLA = 4,
        Boston = 5,
		Bnai = 6,
        URJ = 7,
        NY = 8,
		Chicago = 9,
        MetroWest = 10,
        Greensboro = 11,
        Indianapolis = 12,
        Orange = 22,
        LACIP = 23,
		Columbus =24,
		Dallas =25,
		Judea =26,
        Arkansas = 27,
        Kansas = 28,
		Memphis = 29,
		NewHamshire = 32,
		NorthShore = 33,
		Philadelphia = 35,
		Pittsburgh  = 36,
		Ramah = 37,
		PalmBeach = 39,
		Miami = 40,
		CAiryLouise = 41,
		JCCRanchCamp = 42,
		CampSabra = 43,
		CampChi = 44,
		CapitalCamps = 45,
		NJY = 46,
		Adamahadventures = 47,
		CMART = 48,
		WashingtonDC = 49,
		NageelaMidwest = 50,
		SixPointsSportsAcadamy = 51,
		SolomonSchechter = 52,
		Baltimore = 53,
		Cleveland = 54,
		Louemma = 55,
		BBOttawa = 56,
		LMAN = 57,
		Barney = 58,
		Calgary = 59,
		Habonim = 60,
		NNJ=61,
		Eden=62,
		PJL=63,
		Berkshire=64,
		CJA=65,
		BIMA=66,
		Avoda=67,
		Laurelwood=68,
		Montreal=69,
		RhodeIsland=70,
		Livingston=71,
		SanDiego=72,
		MountainChai=73,
		CNJ =74,
		Hatikvah =75,
		JRF =76,
		Charles =77,
		Omaha =78,
		SurpriseLake = 79, 
		Poyntelle =80,
		GoldRing =81,
		StLouis =82,
		NageelaEast =83,
		PassportNYC = 84,
		CNY = 85,
        Simcah = 86,
        CohenCamps = 87,
        JewishGirlsRetreat = 88,
		Toronto=89,
        JAcademy = 90,
        HGF = 91,
		Louisville = 92,
		Colorado = 93,
		Shomria = 94,
		PalmSprings = 95,
        GanIsraelPoconos = 96,
        Delaware = 97,
		SanFrancisco = 98,
		Seattle = 99,
		Milwaukee = 100,
		Hartford = 101,
		ElPaso = 102,
		JCAShalom = 103,
        BYachad = 104,
		MoshavaMalibu = 105,
		Zeke = 106,
		Atlanta = 107,
		Nashville = 108,
        JCCMaccabiSports = 109,
        CampInc = 110,
        BnaiBrithPerlman = 111,
		Portland = 112,
        TelYehudah = 113,
        Houston = 114,
		RamahBerkshires = 115,
        RamahCalifornia = 116,
		RamahCanada = 117,
        RamahPoconos = 118,
		RamahOutdoorAdventure = 119,
        RamahWisconsin = 120,
        Madison = 121,
        HabonimTavor = 122,
        HabonimGalil = 123,
		HabonimMoshava = 124,
        HabonimMiriam = 125,
        HabonimGilboa = 126,
        HabonimNaaleh = 127,
        HabonimGesher = 128,
        RamahDarom = 129,
        RamahNewEngland = 130
	}

	/// <summary>
	/// FedDaySchoolEligibility
	/// To get the day school eligiblilyt for a federation use description (example General.GetEnumDescription(FedGradeEligibility.Cincinnati))
	/// </summary>
	public enum FedDaySchoolEligibility
	{
		[Description("false")]
		Cincinnati = 1,
		[Description("false")]
		Middlesex = 2,
		[Description("false")]
		JWest = 3,
		[Description("false")]
		JWestLA = 4,
		[Description("false")]
		Boston = 5,
		[Description("false")]
		BNai = 6,
		[Description("false")]
		URJ = 7,
		[Description("false")]
		NY = 8,
		[Description("true")]
		Chicago = 9,
		[Description("false")]
		MetroWest = 10,
		[Description("true")]
		Greensboro = 11,
		[Description("false")]
		Indianapolis = 12,
		[Description("false")]
		Orange = 22,
		[Description("false")]
		LACIP = 23,
		[Description("false")]
		Columbus = 24,
		[Description("false")]
		Dallas = 25,
		[Description("false")]
		Judaea = 26,
		[Description("false")]
		Arkansas = 27,
		[Description("false")]
		Kansas = 28,
		[Description("false")]
		Memphis = 29,
		//[Description("false")]
		//Montreal = 31,
		[Description("false")]
		NH = 32,
		[Description("false")]
		NorthShore = 33,
		[Description("false")]
		Philadelphia = 35,
		[Description("false")]
		Pittsburgh = 36,
		[Description("true")]
		Ramah = 37,
		[Description("false")]
		PalmBeach = 39,
		[Description("false")]
		Miami = 40,
		[Description("false")]
		AiryLouise = 41,
		[Description("false")]
		JCCRanch = 42,
		[Description("false")]
		Sabra = 43,
		[Description("false")]
		CampChi = 44,
		[Description("false")]
		Capital = 45,
		[Description("true")]
		NJY = 46,
		[Description("false")]
		Adamah = 47,
		[Description("true")]
		CMART_MIIP = 48,
		[Description("false")]
		Washington = 49,
		[Description("false")]
		Nageela = 50,
		[Description("false")]
		Solomon = 52,
		[Description("false")]
		Baltimore = 53,
		[Description("false")]
		Cleveland = 54,
		[Description("false")]
		Louemma = 55,
		[Description("false")]
		BBOttawa = 56,
		[Description("false")]
		LMAN = 57,
		[Description("false")]
		CampBarney = 58,
		[Description("false")]
		Calgary = 59,
		[Description("false")]
		Habonim = 60,
		[Description("false")]
		NNJ = 61,
		[Description("false")]
		Eden = 62,
		[Description("false")]
		PJL = 63,
		[Description("false")]
		Berkshire = 64,
		[Description("false")]
		CJA = 65,
		[Description("false")]
		BIMA = 66,
		[Description("false")]
		Avoda = 67,
		[Description("false")]
		Laurelwood = 68,
		[Description("false")]
		Montreal = 69,
		[Description("false")]
		RhodeIsland = 70,
		[Description("false")]
		Livingston = 71,
		[Description("false")]
		SanDiego = 72,
		[Description("false")]
		MountainChai = 73,
		[Description("false")]
		CNJ = 74,
		[Description("false")]
		Hatikvah = 75,
		[Description("false")]
		JRF = 76,
		[Description("false")]
		Charles = 77,
		[Description("false")]
		Omaha = 78,
		[Description("false")]
		SurpriseLake = 79,
		[Description("false")]
		Poyntelle = 80,
		[Description("false")]
		StLouis = 82,
		[Description("false")]
		NageelaEast = 83,
		[Description("false")]
		PassportNYC = 84,
		[Description("false")]
		CNY = 85,
		[Description("false")]
		Delaware = 97,
		[Description("false")]
		SanFrancisco = 98,
		[Description("false")]
		Seattle = 99,
		[Description("false")]
		Milwaukee = 100,
		[Description("false")]
		Hartford = 101,
		[Description("false")]
		ElPaso = 101
	}

	/// <summary>
	/// FedGradeEligibility
	/// To get the eligible grade for a federation use description (example General.GetEnumDescription(FedGradeEligibility.Cincinnati))
	/// </summary>
	public enum FedGradeEligibility
	{
		[Description("3-11")]
		Cincinnati = 1,
		[Description("3-11")]
		Middlesex = 2,
		[Description("6-8")]
		JWest = 3,
		[Description("6-8")]
		JWestLA = 4,
		[Description("2-11")]
		Boston = 5,
		[Description("4-11")]
		BNai = 6,
		[Description("1-12")]
		URJ = 7,
		[Description("3-11")]
		NY = 8,
		[Description("2-12")]
		Chicago = 9,
		[Description("1-12")]
		MetroWest = 10,
		[Description("3-11")]
		Greensboro = 11,
		[Description("3-11")]
		Indianapolis = 12,
		[Description("Need to Check")]
		Orange = 22,
		[Description("3-5 & 9-11 for 1st Timer and 3-12 for 2nd Timer")]
		LACIP = 23,
		[Description("2-10")]
		Columbus = 24,
		[Description("3-10")]
		Dallas = 25,
		[Description("2-11")]
		Judaea = 26,
		[Description("2-10")]
		Arkansas = 27,
		[Description("2-12")]
		Kansas = 28,
		[Description("3-10")]
		Memphis = 29,
		[Description("0")]
		Montreal = 31,
		[Description("1-12")]
		NH = 32,
		[Description("3-12")]
		NorthShore = 33,
		[Description("3-11")]
		Philadelphia = 35,
		[Description("2-12")]
		Pittsburgh = 36,
		[Description("3-11")]
		Ramah = 37,
		[Description("2-11")]
		PalmBeach = 39,
		[Description("3-12")]
		Miami = 40,
		[Description("2-11")]
		AiryLouise = 41,
		[Description("3-10")]
		JCCRanch = 42,
		[Description("3-9")]
		Sabra = 43,
		[Description("4-11")]
		CampChi = 44,
		[Description("3-9")]
		Capital = 45,
		[Description("1-12")]
		NJY = 46,
		[Description("8-12")]
		Adamah = 47,
		[Description("2-11")]
		CMART_MIIP = 48,
		[Description("3-8")]
		Washington = 49,
		[Description("4-11")]
		Nageela = 50,
		[Description("5-10")]
		Solomon = 52,
		[Description("2-12")]
		Baltimore = 53,
		[Description("4-12")]
		Cleveland = 54,
		[Description("2-10")]
		Louemma = 55,
		[Description("2-11")]
		BBOttawa = 56,
		[Description("3-11")]
		LMAN = 57,
		[Description("3-10")]
		CampBarney = 58,
		[Description("2-10")]
		Calgary = 59,
		[Description("3-10")]
		Habonim = 60,
		[Description("4-12")]
		NNJ = 61,
		[Description("3-12")]
		Eden = 62,
		[Description("3-12")]
		PJL = 63,
		[Description("1-12")]
		Berkshire = 64,
		[Description("1-12")]
		CJA = 65
	}

	public enum FirstTimerQuestion
	{ 
		
	
	}
}
