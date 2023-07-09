using Aquality.Selenium.Core.Logging;

namespace ExamTest.Framework.Utils
{
    public static class ConvertUtils
    {
        public static string ToBase64String(byte[] bytes)
        {
            Logger.Instance.Info("ToBase64String ConvertUtils");
            return Convert.ToBase64String(bytes);
        }
    }
}