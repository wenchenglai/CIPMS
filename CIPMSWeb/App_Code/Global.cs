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
    Q30_ReferredBySynagogueOrJCC = 30,
    Q31_SelectYourSynagogueOrJCC = 31,
    Q33_ReceivedGrant = 33,
    Q1016_AttendedDayCamp = 1016,
    Q1017_DayCampName = 1017,
    Q1021_PJLNames = 1021,
    WhoYouSpeakToInSynagogue = 1044,
    ProfessionalOrCongregate = 1045,
    GrandfatherPolicySessionLength = 1063
}
