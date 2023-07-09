using Aquality.Selenium.Core.Logging;

namespace ExamTest.Framework.Utils
{
    public static class FileUtils
    {
        public static string GetDataFromFile(string path)
        {
            Logger.Instance.Info($"Get data from file {path}");
            return File.ReadAllText(path);
        }

        public static string GetLastLineFromFile(string path)
        {
            Logger.Instance.Info($"Get last line from file {path}");
            return File.ReadLines(path).Last();
        }
    }
}