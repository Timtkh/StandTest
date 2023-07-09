using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTest.TestSolution.Pages
{
    public class TestPage : Form
    {
        private ILabel TextLabel(string text) => ElementFactory.GetLabel(By.XPath($"//*[contains(text(),'{text}')]"), $"{text} label");
        private ILabel ImageLabel(string src) => ElementFactory.GetLabel(By.XPath($"//*[contains(@src,'{src}')]"), "Image label");

        public TestPage() : base(By.XPath("//*[contains(text(),'Common info')]"), "Created test page") { }

        public bool IsTextDisplayed(string text)
        {
            Logger.Instance.Info("Is text displayed");
            return TextLabel(text).State.WaitForDisplayed();
        }

        public bool IsImageDisplayed(string src)
        {
            Logger.Instance.Info("Is image displayed");
            return ImageLabel(src).State.WaitForDisplayed();
        }
    }
}