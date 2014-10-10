﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionSpecialCode
/// </summary>
public class SessionSpecialCode
{
	public static string GetSpecialCode()
    {
        var session = HttpContext.Current.Session;
        if (session["SpecialCodeValue"] != null)
        {
            return session["SpecialCodeValue"].ToString();
        }
        else
            return "";
    }

    public static string GetPJLotterySpecialCode()
    {
        var code = GetSpecialCode();
        if (code.Length >= 9)
            return code.Substring(0, 9);
        else
            return "";
    }
}