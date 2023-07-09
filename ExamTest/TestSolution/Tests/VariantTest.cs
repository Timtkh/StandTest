using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Enums;
using ExamTest.TestSolution.Managers;
using ExamTest.TestSolution.Models.DataBaseModels;
using ExamTest.TestSolution.Models.TestDataModels;
using ExamTest.TestSolution.Steps;
using NUnit.Framework;

namespace ExamTest.TestSolution.Tests
{
    [TestFixture]
    public class VariantTest : BaseTest
    {
        private const string TokenName = "token";
        private const string FrameName = "info";
        private const string ClosePopUpScript = "closePopUp()";

        [Test, TestCaseSource(nameof(GetTestCaseData))]
        public void Run_VariantTest(TestData data)
        {
            var token = APISteps.GetAndCheckToken(data.Variant);

            MainPageSteps.CheckMainPageOpened();
            BrowserUtils.SendCookies(cookieName: TokenName, cookieValue: token);
            BrowserUtils.Refresh();

            MainPageSteps.CheckRightVersionInFooterAppear(data.Variant);
            MainPageSteps.OpenProject(data.TestedProjectName);
            ProjectPageSteps.CheckProjectOpened(data.TestedProjectName);
            var tests = DBSteps.GetTests(data.TestedProjectName);
            ProjectPageSteps.TestsAreSorteredAndEqual(tests);

            var newProjectName = RandomUtils.GetRandomLatinString();
            BrowserUtils.GoBack();
            MainPageSteps.CheckMainPageOpened();
            MainPageSteps.OpenAddProjectForm();
            BrowserUtils.SwitchToFrame(FrameName);
            MainPageSteps.AddProjectAndCheckSuccessText(newProjectName);
            BrowserUtils.SwitchToDefaultContent();
            BrowserUtils.ExecuteScript(ClosePopUpScript);
            MainPageSteps.CheckAddProjectFormClosed();
            BrowserUtils.Refresh();

            MainPageSteps.CheckProjectDisplayed(newProjectName);
            MainPageSteps.OpenProject(newProjectName);
            ProjectPageSteps.CheckProjectOpened(newProjectName);
            var screenshot = BrowserUtils.GetScreenshot();
            DBSteps.AddDataToDB(projectName: newProjectName, sessionKey: RandomUtils.GetRandomInt(), buildNumber: RandomUtils.GetRandomInt(), testName: RandomUtils.GetRandomLatinString(), statusId: (int)RandomUtils.RandomEnumValue<StatusEnum>(), browserName: BrowserUtils.GetBrowserName(), screenshot: screenshot);
            var createdTest = DBSteps.GetTest(newProjectName);
            var logContent = DBSteps.GetLogContent(createdTest);
            ProjectPageSteps.CheckAddedTestAppeared(createdTest);

            ProjectPageSteps.OpenTest(createdTest);
            TestPageSteps.CheckTestOpenedAndRight(test: createdTest, projectName: newProjectName, logContent: logContent);
        }

        private static IEnumerable<TestCaseData> GetTestCaseData()
        {
            Logger.Instance.Info("Get test case data");
            var data = DataProvider.GetTestData();
            foreach (var item in data)
            {
                yield return new TestCaseData(item);
            }
        }
    }
}