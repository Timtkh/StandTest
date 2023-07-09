using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;

namespace ExamTest.Framework.Utils
{
    public static class BrowserUtils
    {
        public static void SendCookies(string cookieName, string cookieValue)
        {
            Logger.Instance.Info($"Send cookies {cookieName}");
            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookieName, cookieValue));
        }

        public static void Refresh()
        {
            Logger.Instance.Info("Refresh");
            AqualityServices.Browser.Refresh();
        }

        public static void GoBack()
        {
            Logger.Instance.Info("Go back");
            AqualityServices.Browser.GoBack();
        }

        public static byte[] GetScreenshot()
        {
            Logger.Instance.Info("Get screenshot");
            return AqualityServices.Browser.GetScreenshot();
        }

        public static void SwitchToFrame(string frameName)
        {
            Logger.Instance.Info($"Switch to frame {frameName}");
            AqualityServices.Browser.Driver.SwitchTo().Frame(frameName);
        }

        public static void SwitchToDefaultContent()
        {
            Logger.Instance.Info("Switch to default content");
            AqualityServices.Browser.Driver.SwitchTo().DefaultContent();
        }

        public static void ExecuteScript(string script)
        {
            Logger.Instance.Info($"Execute script {script}");
            AqualityServices.Browser.ExecuteScript(script);
        }

        public static string GetBrowserName()
        {
            Logger.Instance.Info("Get browser name");
            return AqualityServices.Browser.BrowserName.ToString();
        }
    }
}