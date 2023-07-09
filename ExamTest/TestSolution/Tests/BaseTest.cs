using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Managers;
using NUnit.Framework;

namespace ExamTest.TestSolution.Tests
{
    public class BaseTest
    {
        private readonly Browser Browser = AqualityServices.Browser;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Logger.Instance.Info("OneTimeSetUp");
            DBUtils.Open();
            Browser.Maximize();
            Browser.GoTo(new UriBuilder(TestDataGetter.Configs.BaseUrl) { UserName = TestDataGetter.UserData.Login, Password = TestDataGetter.UserData.Password }.Uri);
            Browser.WaitForPageToLoad();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Logger.Instance.Info("OneTimeTearDown");
            DBUtils.Close();
            Browser.Quit();
        }
    }
}