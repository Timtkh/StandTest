using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Models.DataBaseModels;
using ExamTest.TestSolution.Pages;
using ExamTest.TestSolution.Workers;
using NUnit.Framework;

namespace ExamTest.TestSolution.Steps
{
    public static class TestPageSteps
    {
        private readonly static TestPage TestPage = new();

        public static void CheckTestOpenedAndRight(Test test, string projectName, string logContent)
        {
            Logger.Instance.Info($"Open {test.Name}");

            Assert.That(TestPage.State.IsDisplayed, Is.True, "Created test page is not opened");
            Assert.That(TestPage.IsTextDisplayed(projectName), Is.True, $"{projectName} name is not displayed");
            Assert.That(TestPage.IsTextDisplayed(test.Name), Is.True, $"{test.Name} name is not displayed");
            Assert.That(TestPage.IsTextDisplayed(StatusWorker.Get(test.StatusId).Name), Is.True, "Status is not displayed");
            Assert.That(TestPage.IsTextDisplayed(DateUtils.ParseDateTimeToFormatedString(date: test.StartTime)), Is.True, "Start time is not displayed");
            Assert.That(TestPage.IsTextDisplayed(test.MethodName), Is.True, "Method name is not displayed");
            Assert.That(TestPage.IsTextDisplayed(test.Env), Is.True, "Env is not displayed");
            Assert.That(TestPage.IsTextDisplayed(test.Browser), Is.True, "Browser is not displayed");
            Assert.That(TestPage.IsTextDisplayed(logContent), Is.True, "Log is not displayed");
            Assert.That(TestPage.IsImageDisplayed(ConvertUtils.ToBase64String(AttachmentWorker.Get(test.Id).Content)), Is.True, "Screenshot is not displayed");
        }
    }
}