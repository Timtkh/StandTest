using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Models.DataBaseModels;

namespace ExamTest.TestSolution.Workers
{
    public static class SessionWorker
    {
        private const string InsertQuery = "INSERT INTO session (session_key, build_number) VALUES ({0}, {1})";
        private const string GetQuery = "SELECT * FROM session WHERE session_key = '{0}'";
        private const string IdColumn = "id";
        private const string SessionKeyColumn = "session_key";

        public static void Insert(Session session)
        {
            Logger.Instance.Info("Session worker insert");
            DBUtils.ExecuteSql(string.Format(InsertQuery, session.SessionKey, session.BuildNumber));
        }

        public static Session Get(string sessionKey)
        {
            Logger.Instance.Info("Session worker get");
            var session = new Session();

            using (var sessionDataReader = DBUtils.ExecuteReader(string.Format(GetQuery, sessionKey)))
            {
                while (sessionDataReader.Read())
                {
                    session.Id = (long)sessionDataReader[IdColumn];
                    session.SessionKey = sessionDataReader[SessionKeyColumn] as string;
                }
            }

            return session;
        }
    }
}