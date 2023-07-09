using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTest.TestSolution.Pages
{
    public class MainPage : Form
    {
        private readonly ILabel VersionTextBox = ElementFactory.GetLabel(By.XPath("//*[contains(@class,'footer-text')]//span"), "Version label");
        private readonly IButton AddButton = ElementFactory.GetButton(By.XPath("//*[contains(text(),'+Add')]"), "Add button");

        private ILabel ProjectLabel(string projectName) => ElementFactory.GetLabel(By.XPath($"//*[contains(text(),'{projectName}')]"), $"{projectName} label");

        public MainPage() : base(By.XPath("//*[contains(text(),'Available projects')]"), "Main page") { }

        public string GetFooterVersionText()
        {
            Logger.Instance.Info("Get footer version text");
            return VersionTextBox.Text;
        }

        public void ClickAdd()
        {
            Logger.Instance.Info("Click add");
            AddButton.Click();
        }

        public void ClickProject(string projectName)
        {
            Logger.Instance.Info($"Click project {projectName}");
            ProjectLabel(projectName).Click();
        }

        public bool IsProjectDisplayed(string projectName)
        {
            Logger.Instance.Info($"Is {projectName} displayed");
            return ProjectLabel(projectName).State.WaitForDisplayed();
        }
    }
}