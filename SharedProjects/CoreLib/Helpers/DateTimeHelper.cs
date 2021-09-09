using System;
using Mohammad.Win32.Natives.IfacesEnumsStructsClasses;

namespace Mohammad.Helpers
{
    public static class DateTimeHelper
    {
        public static bool IsBetween(this TimeSpan source, TimeSpan start, TimeSpan end) => source >= start && source <= end;
        public static bool IsBetween(this TimeSpan source, string start, string end) => source.IsBetween(ToTimeSpan(start), ToTimeSpan(end));
        private static TimeSpan ToTimeSpan(string source) => TimeSpan.Parse(source);
        public static DateTime ToDateTime(this FILETIME filetime) => DateTime.FromFileTime(filetime.ToLong());
        public static long ToLong(this FILETIME filetime) => ((long)filetime.dwHighDateTime << 32) + filetime.dwLowDateTime;
        public static bool IsValid(string dateTime) => DateTime.TryParse(dateTime, out DateTime buffer);
    }
}