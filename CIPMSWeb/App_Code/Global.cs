﻿/// <summary>
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
    GrandfatherPolicySessionLength = 1063
}
