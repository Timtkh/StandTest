using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Models.TestDataModels;
using Newtonsoft.Json;

namespace ExamTest.TestSolution.Managers
{
    public static class DataProvider
    {
        private const string TestDataPath = @"TestSolution\Configs\testdata.json";

        public static List<TestData> GetTestData()
        {
            Logger.Instance.Info("Get test data");
            var testData = new List<TestData>();

            foreach (var data in JsonUtils.Parse(FileUtils.GetDataFromFile(TestDataPath)))
            {
                testData.Add(JsonConvert.DeserializeObject<TestData>(data.Value.ToString()));
            }

            return testData;
        }
    }
}