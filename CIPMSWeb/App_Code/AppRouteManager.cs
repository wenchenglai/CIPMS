using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CIPMSBC;

/// <summary>
/// Summary description for AppRouteManager
/// </summary>
public class AppRouteManager
{
    // 2014-07-28 The first routing rule is for PJL - if the user is in PendingPJLottery (used PJ special code, failed at community due to DS
    public static string GetNextRouteBasedOnStatus(StatusInfo status, string option)
    {
        var url = "Step2_3.aspx";
        if (status == StatusInfo.PendingPJLottery)
        {
            var specialCode = SessionSpecialCode.GetPJLotterySpecialCode();
            if (specialCode != "")
            {
                var campYearId = Convert.ToInt32(HttpContext.Current.Application["CampYearID"]);
                if (SpecialCodeManager.IsValidCode(campYearId, (int)FederationEnum.PJL, specialCode))
                {
                    url = "../PJL/Step2_2_route_info.aspx?prev=" + option;
                }                
            }
        }

        return url;
    }
}