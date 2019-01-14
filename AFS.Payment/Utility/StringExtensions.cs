using System;

namespace AFS.Payment.Utility
{
    public static class StringExtensions
    {
        public static Option<DateTime> TicksToDate(this string dateString)
        {
            DateTime? date = null;
            try
            {
                date = new DateTime(1970, 1, 2).AddMilliseconds(double.Parse(dateString));
            }
            catch (Exception)
            {
            }

            return date.AsOption();
        }
    }
}