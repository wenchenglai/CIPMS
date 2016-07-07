using System;
using System.Collections.Generic;
using System.Text;

namespace CIPMSBC
{
    public enum StatusInfo
    {
        SystemEligible = 1, 
		EligibleNoCamp, 
		SystemInEligible,
        NationalProgramNotAssigned, 
		Incomplete, 
		EligiblePendingSchool,
        EligibleByStaff, 
		IneligibleByStaff, 
		BeingResearched,
        NotRegForCampNeedsFollowup, 
		RegAcceptedCamp,
        CampFull, 
		IneligibleBasedonDays, 
		PaymentPending, 
		SecondApproval,
        Paid, 
		CamperDeclinedToGoToCamp, 
		SecondApprovalRejected, 
		Refunded, 
		PendingSchoolAndCamp, 
		Eligibledayschool = 23,
        PaymentRequested = 25,
        CamperAttendedCamp = 28,
		PendingValidation = 36,
		EligibleContactParentsAagain = 42,
        EligiblePendingNumberOfDays = 43,
        EligibleCampCoupon = 45,
        //EligiblePJLottery = 46,
        EligiblePJLottery = 47, // added 2014-07-28 For PJL routing - PJL will accept campers not eligible for DS from other community programs.  So we need to attach this status to routing app
        IneligiblePJLottery = 48,
        WinnerPJLottery = 49,
        EligiblePendingRegistrationCamp = 50,
        NonJewish = 9999
    }
}
