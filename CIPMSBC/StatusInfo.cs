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
		PendingValidation = 36,
		EligibleContactParentsAagain = 42,
        EligiblePendingNumberOfDays = 43,
        NonJewish = 9999
    }
}
