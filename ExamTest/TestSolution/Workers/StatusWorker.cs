using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Models.DataBaseModels;

namespace ExamTest.TestSolution.Workers
{
    public static class StatusWorker
    {
        private const string GetQuery = "SELECT * FROM status WHERE id = '{0}'";
        private const string IdColumn = "id";
        private const string NameColumn = "name";

        private static readonly List<string> CurrentStatusesList = new() { "Passed", "Failed", "Skipped" };

        public static Status Get(string statusId)
        {
            Logger.Instance.Info("Status worker get");
            var status = new Status();

            using (var statusDataReader = DBUtils.ExecuteReader(string.Format(GetQuery, statusId)))
            {
                while (statusDataReader.Read())
                {
                    status.Id = (int)statusDataReader[IdColumn];
                    status.Name = CurrentStatusesList.Where(status => status.ToUpper() == statusDataReader[NameColumn] as string).First();
                }
            }

            return status;
        }
    }
}