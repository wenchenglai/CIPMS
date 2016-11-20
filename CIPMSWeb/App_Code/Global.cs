/// <summary>
/// User Roles - copy from CIPMS db
/// </summary>
public enum Role
{
    Camper = 0,
    FJCAdmin,
    FederationAdmin,
    CampDirector,
    Approver
}

/// <summary>
/// Meta Program Type
/// </summary>
public enum ProgramType
{
    NoUse = -1,
    CIP = 0,
    JWest = 1,
    All
}

public enum CamperOrgType
{
    Camp = 0,
    Synagogue,
    CamperContactInfo
}

public enum SearchKeys
{
    Name = 0,
    Address,
    Email,
    BirthDate
}

public enum QuestionId
{
    FirstTime = 3,
    Grade = 6,
    SchoolType = 7,
    SchoolName = 8,
    Q13_SecondTime = 13,
    SelectJewishDaySchool = 17,
    Q28_IsSecondTimer = 28,
    Q29_ReceivedGrant = 29,
    Q30_ReferredBySynagogueOrJCC = 30,
    Q31_SelectYourSynagogueOrJCC = 31,
    Q33_ReceivedGrant = 33,
    Q1016_AttendedDayCamp = 1016,
    Q1017_DayCampName = 1017,
    Q1021_PJLNames = 1021,
    Q1044_WhoYouSpeakToInSynagogue = 1044,
    Q1045_ProfessionalOrCongregate = 1045,
    GrandfatherPolicySessionLength = 1063,
    Q1068_AttendSecondarySchool = 1068,
    Q1032_SiblingAttended = 1032,
    Q1033_SiblingFirstName = 1033,
    Q1034_SiblingLastName = 1034,
    Q1066_2ndYear = 1066,
    Q1067_IncomeUnder = 1067
}
