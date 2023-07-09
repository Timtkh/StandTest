using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Forms;
using ExamTest.TestSolution.Models.DataBaseModels;
using ExamTest.TestSolution.Models.UIModels;
using ExamTest.TestSolution.Pages;
using NUnit.Framework;

namespace ExamTest.TestSolution.Steps
{
    public static class ProjectPageSteps
    {
        private const string TestName = "Test name";
        private const string TestMethod = "Test method";
        private const string LatestTestResult = "Latest test result";
        private const string LatestTestStartTime = "Latest test start time";
        private const string LatestTestEndTime= "Latest test end time";
        private const string LatestTestDuration = "Latest test duration";
        private const string History = "History";
        private const string LatestTestStartTimeColumn = "LatestTestStartTime";

        private readonly static ProjectPage ProjectPage = new();
        public readonly static TableTestForm TableTest = new();

        public static void TestsAreSorteredAndEqual(List<Test> tests)
        {
            Logger.Instance.Info("Tests are sortered and equal");

            var headers = TableTest.GetHeadersTextList();
            var allRecordsCount = TableTest.GetAllRecordsCount();
            var projectTestList = new List<ProjectTest>();
            var headersList = new Dictionary<int, string>();

            for (int i = 0, j = 1; i < headers.Count; i++)
            {
                headersList.Add(j++, headers[i]);
            }

            for (int i = 2; i < (allRecordsCount / headers.Count) + 2; i++)
            {
                var record = new Dictionary<string, string>();

                foreach (var header in headersList)
                {
                    record.Add(header.Value, TableTest.GetCellText(i, header.Key));
                }

                projectTestList.Add(new ProjectTest()
                {
                    TestName = record[record.Where(header => header.Key == TestName).First().Key],
                    TestMethod = record[record.Where(header => header.Key == TestMethod).First().Key],
                    LatestTestResult = record[record.Where(header => header.Key == LatestTestResult).First().Key],
                    LatestTestStartTime = DateUtils.ParseTimeToDateTime(record[record.Where(header => header.Key == LatestTestStartTime).First().Key]),
                    LatestTestEndTime = DateUtils.ParseTimeToDateTime(timeString: record[record.Where(header => header.Key == LatestTestEndTime).First().Key]),
                    LatestTestDuration = DateUtils.ParseDurationToDateTime(timeString: record[record.Where(header => header.Key.Contains(LatestTestDuration)).First().Key]),
                    History = record[record.Where(header => header.Key == History).First().Key]
                });
            };

            Assert.That(projectTestList, Is.Ordered.Descending.By(LatestTestStartTimeColumn), "Table data is not ordered");
            foreach (var tableTest in projectTestList)
            {
                Assert.That(tests.Exists(test => test.Name == tableTest.TestName), Is.True, $"Test named {tableTest.TestName} is not exist");
                Assert.That(tests.Exists(test => test.MethodName == tableTest.TestMethod), Is.True, $"Test method {tableTest.TestMethod} is not exist");
                Assert.That(tests.Exists(test => test.StartTime == tableTest.LatestTestStartTime), Is.True, $"Test start time {tableTest.LatestTestStartTime} is not exist");
            }
        }

        public static void CheckAddedTestAppeared(Test test)
        {
            Logger.Instance.Info("Added test was appeared");
            Assert.That(ProjectPage.IsTestDisplayed(test.Name), Is.True, $"Test {test.Name} is not displayed");
        }

        public static void OpenTest(Test test)
        {
            Logger.Instance.Info("Added test was appeared");
            ProjectPage.ClickTest(test.Name);
        }

        public static void CheckProjectOpened(string projectName)
        {
            Logger.Instance.Info("Check project opened");
            Assert.That(ProjectPage.State.WaitForDisplayed(), Is.True, $"{projectName} page is not opened");
        }
    }
}