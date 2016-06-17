using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ValidationChecker
/// </summary>
public static class ValidationChecker
{
    public static bool CheckSessionDate(string inputDate)
    {
        var result = false;
        DateTime startDate;
        try
        {
            startDate = DateTime.ParseExact(inputDate, "d", CultureInfo.InvariantCulture);
            result = true;
        }
        catch (Exception ex)
        {
            result = false;
        }

        return result;
    }

    public static bool CheckSessionRange(DateTime startDate, DateTime endDate, int campYear)
    {
        int year = startDate.Year;

        if (year != campYear)
            return false;

        if (year != endDate.Year)
            return false;

        var minDate = new DateTime(year, 5, 1);
        var maxDate = new DateTime(year, 9, 30);

        if (startDate < minDate || startDate > maxDate)
            return false;

        if (endDate < minDate || endDate > maxDate)
            return false;

        return true;
    }
}