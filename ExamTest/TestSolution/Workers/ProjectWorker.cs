using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Models.DataBaseModels;

namespace ExamTest.TestSolution.Workers
{
    public static class ProjectWorker
    {
        private const string GetQuery = "SELECT * FROM project WHERE name = '{0}'";
        private const string IdColumn = "id";
        private const string NameColumn = "name";

        public static Project Get(string projectName)
        {
            Logger.Instance.Info("Project worker get");
            var project = new Project();

            using (var projectDataReader = DBUtils.ExecuteReader(string.Format(GetQuery, projectName)))
            {
                while (projectDataReader.Read())
                {
                    project.Id = (long)projectDataReader[IdColumn];
                    project.Name = projectDataReader[NameColumn] as string;
                }
            }

            return project;
        }
    }
}