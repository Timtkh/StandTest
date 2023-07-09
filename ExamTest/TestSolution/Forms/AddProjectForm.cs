using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTest.TestSolution.Forms
{
    public class AddProjectForm : Form
    {
        private readonly ITextBox ProjectNameInput = ElementFactory.GetTextBox(By.Id("projectName"), "Project name input");
        private readonly IButton SaveProjectButton = ElementFactory.GetButton(By.XPath("//*[contains(text(),'Save')]"), "Save project button");

        public AddProjectForm() : base(By.Id("addProjectForm"), "Add project form") { }

        public void WriteProjectName(string projectName)
        {
            Logger.Instance.Info($"Write project name {projectName}");
            ProjectNameInput.ClearAndType(projectName);
        }

        public void ClickSaveProjectButton()
        {
            Logger.Instance.Info("Click save project button");
            SaveProjectButton.Click();
        }

        public bool IsProjectDisplayed(string projectName)
        {
            Logger.Instance.Info($"Is {projectName} displayed");
            return ElementFactory.GetTextBox(By.XPath($"//*[contains(text(),'Project {projectName} saved')]"), "Save project text").State.WaitForDisplayed();
        }
    }
}