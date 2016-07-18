using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PageUtility
/// </summary>
public class PageUtility
{
    public static bool RedirectToNL(int fedId, bool isGrantAvailable, bool isAdmin)
    {
        if (ConfigurationManager.AppSettings["DisableOnSummaryPageFederations"].Split(',').Any(id => id == fedId.ToString()))
        {
            if (!isGrantAvailable && !isAdmin)
            {
                return true;
            }
        }
        return false;
    }
}