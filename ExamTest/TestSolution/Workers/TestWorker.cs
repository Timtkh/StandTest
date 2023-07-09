using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Models.DataBaseModels;

namespace ExamTest.TestSolution.Workers
{
    public static class TestWorker
    {
        private const string InsertQuery = "INSERT INTO test (name, status_id, method_name, project_id, session_id, env, browser) VALUES ('{0}', {1}, '{2}', {3}, {4}, '{5}', '{6}')";
        private const string GetQuery = "SELECT * FROM test WHERE project_id = '{0}' ORDER BY start_time DESC LIMIT 21";
        private const string GetOneQuery = "SELECT * FROM test WHERE project_id = '{0}'";
        private const string IdColumn = "id";
        private const string NameColumn = "name";
        private const string StatusIdColumn = "status_id";
        private const string MethodNameColumn = "method_name";
        private const string ProjectIdColumn = "project_id";
        private const string SessionIdColumn = "session_id";
        private const string StartTimeColumn = "start_time";
        private const string EnvColumn = "env";
        private const string BrowserColumn = "browser";

        public static void Insert(Test test)
        {
            Logger.Instance.Info("Test table worker insert");
            DBUtils.ExecuteSql(string.Format(InsertQuery, test.Name, test.StatusId, test.MethodName, test.ProjectId, test.SessionId, test.Env, test.Browser));
        }

        public static List<Test> Get(long projectId)
        {
            Logger.Instance.Info("Test worker get");
            var testsList = new List<Test>();

            using (var testDataReader = DBUtils.ExecuteReader(string.Format(GetQuery, projectId)))
            {
                while (testDataReader.Read())
                {
                    testsList.Add(new Test
                    {
                        Id = (long)testDataReader[IdColumn],
                        Name = testDataReader[NameColumn] as string,
                        StatusId = testDataReader[StatusIdColumn].ToString(),
                        MethodName = testDataReader[MethodNameColumn] as string,
                        StartTime = (DateTime)testDataReader[StartTimeColumn],
                        ProjectId = (long)testDataReader[ProjectIdColumn],
                        SessionId = (long)testDataReader[SessionIdColumn],
                        Env = testDataReader[EnvColumn] as string,
                    });
                }
            }

            return testsList;
        }

        public static Test GetOne(long projectId)
        {
            Logger.Instance.Info("Test worker get one");
            var test = new Test();

            using (var testDataReader = DBUtils.ExecuteReader(string.Format(GetOneQuery, projectId)))
            {
                while (testDataReader.Read())
                {
                    test.Id = (long)testDataReader[IdColumn];
                    test.Name = testDataReader[NameColumn] as string;
                    test.StatusId = testDataReader[StatusIdColumn].ToString();
                    test.MethodName = testDataReader[MethodNameColumn] as string;
                    test.ProjectId = (long)testDataReader[ProjectIdColumn];
                    test.SessionId = (long)testDataReader[SessionIdColumn];
                    test.StartTime = (DateTime)testDataReader[StartTimeColumn];
                    test.Env = testDataReader[EnvColumn] as string;
                    test.Browser = testDataReader[BrowserColumn] as string;
                }
            }

            return test;
        }
    }
}