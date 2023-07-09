using Aquality.Selenium.Core.Logging;
using ExamTest.TestSolution.Forms;
using ExamTest.TestSolution.Pages;
using NUnit.Framework;

namespace ExamTest.TestSolution.Steps
{
    public static class MainPageSteps
    {
        private const string Version = "Version: {0}";

        private readonly static MainPage MainPage = new();
        private readonly static AddProjectForm AddProjectForm = new();

        public static void CheckMainPageOpened()
        {
            Logger.Instance.Info("Main page was opened");
            Assert.That(new MainPage().State.WaitForDisplayed(), Is.True, "Projects page is not displayed");
        }

        public static void CheckRightVersionInFooterAppear(string versionNumber)
        {
            Logger.Instance.Info("Check right version in footer appear");
            Assert.That(new MainPage().GetFooterVersionText(), Is.EqualTo(string.Format(Version, versionNumber)), $"Footer version is not equal {versionNumber}");
        }

        public static void OpenAddProjectForm()
        {
            Logger.Instance.Info("Open AddProject form");
            MainPage.ClickAdd();
        }

        public static void CheckProjectDisplayed(string projectName)
        {
            Logger.Instance.Info($"Check {projectName} displayed");
            Assert.That(MainPage.IsProjectDisplayed(projectName), Is.True, $"{projectName} is not displayed");
        }

        public static void CheckAddProjectFormClosed()
        {
            Logger.Instance.Info("Check AddProject form closed");
            Assert.That(AddProjectForm.State.WaitForDisplayed(), Is.False, "AddProject form is not closed");
        }

        public static void AddProjectAndCheckSuccessText(string projectName)
        {
            Logger.Instance.Info($"Add project {projectName} and check success text");
            Assert.That(AddProjectForm.State.WaitForDisplayed(), Is.True, "AddProject form is not opened");
            AddProjectForm.WriteProjectName(projectName);
            AddProjectForm.ClickSaveProjectButton();
            Assert.That(AddProjectForm.IsProjectDisplayed(projectName), Is.True, $"{projectName} is not added");
        }

        public static void OpenProject(string projectName)
        {
            Logger.Instance.Info($"Open project {projectName}");
            MainPage.ClickProject(projectName);
        }
    }
}