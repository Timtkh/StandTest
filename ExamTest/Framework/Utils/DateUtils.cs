using Aquality.Selenium.Core.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ExamTest.Framework.Utils
{
    public static class DateUtils
    {
        private const string TimeFormat = "yyyy-MM-dd HH:mm:ss.0";
        private const string DurationFormat = "HH:mm:ss.000";

        public static DateTime ParseTimeToDateTime(string timeString)
        {
            Logger.Instance.Info($"Parse time {timeString} to date time");
            return !timeString.IsNullOrEmpty() ? DateTime.ParseExact(timeString, TimeFormat, null) : DateTime.MinValue;
        }

        public static DateTime ParseDurationToDateTime(string timeString)
        {
            Logger.Instance.Info($"Parse duration {timeString} to date time");
            return !timeString.IsNullOrEmpty() ? DateTime.ParseExact(timeString, DurationFormat, null) : DateTime.MinValue;
        }

        public static string ParseDateTimeToFormatedString(DateTime date)
        {
            Logger.Instance.Info($"Parse date {date} to formated string");
            return date.ToString(TimeFormat);
        }
    }
}