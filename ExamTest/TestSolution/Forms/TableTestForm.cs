using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExamTest.TestSolution.Forms
{
    public class TableTestForm : Form
    {
        private IList<ILabel> HeadersList() => ElementFactory.FindChildElements<ILabel>(FormElement, By.XPath("//th"));
        private ILabel CellLabel(int row, int column) => ElementFactory.FindChildElement<ILabel>(FormElement, By.XPath($"//tr[{row}]//td[{column}]"), "Cell label");
        private IList<ILabel> AllRecords() => ElementFactory.FindChildElements<ILabel>(FormElement, By.XPath($"//td"));

        public TableTestForm() : base(By.XPath("//*[contains(@class,'table')]"), "Table test form") { }

        public List<string> GetHeadersTextList()
        {
            Logger.Instance.Info("Get headers text list");
            var headers = new List<string>();

            foreach (var header in HeadersList())
            {
                headers.Add(header.Text);
            }

            return headers;
        }

        public string GetCellText(int row, int column)
        {
            Logger.Instance.Info("Get cell text");
            return CellLabel(row, column).Text;
        }

        public int GetAllRecordsCount()
        {
            Logger.Instance.Info("Get all records count");
            return AllRecords().Count;
        }
    }
}