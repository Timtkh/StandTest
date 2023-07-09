using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Models.DataBaseModels;

namespace ExamTest.TestSolution.Workers
{
    public static class LogWorker
    {
        private const string InsertQuery = "INSERT INTO log (content, test_id) VALUES ('{0}', {1})";
        private const string GetQuery = "SELECT * FROM log WHERE test_id = '{0}'";
        private const string ContentColumn = "content";

        public static void Insert(Log log)
        {
            Logger.Instance.Info("Log worker insert");
            DBUtils.ExecuteSql(string.Format(InsertQuery, log.Content, log.TestId));
        }

        public static Log Get(long testId)
        {
            Logger.Instance.Info("Log worker get");
            var log = new Log();

            using (var logDataReader = DBUtils.ExecuteReader(string.Format(GetQuery, testId)))
            {
                while (logDataReader.Read())
                {
                    log.Content = logDataReader[ContentColumn] as string;
                }
            }

            return log;
        }
    }
}