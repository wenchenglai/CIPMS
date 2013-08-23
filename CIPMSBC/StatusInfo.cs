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
		PendingSchoolEligibility,
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
		CamperDeclined, 
		SecondApprovalRejected, 
		Refunded, 
		EligibleNoSchoolNoCamp, 
		Eligibledayschool = 23,
		PendingValidation = 36,
		EligibleContactParentsAagain = 42
    }
}
