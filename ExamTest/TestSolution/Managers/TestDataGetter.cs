using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Models.TestDataModels;

namespace ExamTest.TestSolution.Managers
{
    public class TestDataGetter
    {
        private const string TestDataObject = @"TestSolution\Configs\{0}.json";

        public static readonly Configs Configs = JsonUtils.Deserialize<Configs>(FileUtils.GetDataFromFile(string.Format(TestDataObject, "settingsfile")));
        public static readonly DBSettings DBSettings = JsonUtils.Deserialize<DBSettings>(FileUtils.GetDataFromFile(string.Format(TestDataObject, "dbsettings")));
        public static readonly UserData UserData = JsonUtils.Deserialize<UserData>(FileUtils.GetDataFromFile(string.Format(TestDataObject, "userdata")));
    }
}