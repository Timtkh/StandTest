using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTest.TestSolution.Pages
{
    public class ProjectPage : Form
    {
        public ProjectPage() : base(By.XPath("//*[contains(text(),'Total tests progress')]"), "Project page") { }

        public bool IsTestDisplayed(string testName)
        {
            Logger.Instance.Info("Is test appear");
            return ElementFactory.GetLabel(By.XPath($"//*[contains(@class,'table')]//*[contains(text(),'{testName}')]"), $"{testName} state").State.WaitForDisplayed();
        }

        public void ClickTest(string testName)
        {
            Logger.Instance.Info("Click test");
            ElementFactory.GetLabel(By.XPath($"//*[contains(@class,'table')]//*[contains(text(),'{testName}')]"), $"{testName} click").Click();
        }
    }
}