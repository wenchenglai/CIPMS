using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CIPMSBC;

/// <summary>
/// Summary description for AppRouteDisplayManager
/// </summary>
public class AppRouteDisplayManager
{
    /// <summary>
    /// An abstration to check if an app status has eligible status or not.  This is better than check on each program.
    /// </summary>
    /// <returns></returns>
    public static bool IsAppEligible()
    {
        var flag = false;
        var statusObj = HttpContext.Current.Session["STATUS"];
        if (statusObj != null)
        {
            var status = (StatusInfo)Convert.ToInt32(statusObj);
            if (status == StatusInfo.SystemEligible || 
                status == StatusInfo.EligibleCampCoupon || 
                status == StatusInfo.EligiblePendingSchool ||
                status == StatusInfo.Eligibledayschool ||
                status == StatusInfo.EligiblePendingNumberOfDays ||
                status == StatusInfo.EligiblePJLottery )
            {
                flag = true;
            }

        }
        return flag;
    }
}