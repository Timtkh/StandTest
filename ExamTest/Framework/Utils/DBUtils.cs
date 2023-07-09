using Aquality.Selenium.Core.Logging;
using ExamTest.TestSolution.Managers;
using MySql.Data.MySqlClient;

namespace ExamTest.Framework.Utils
{
    public static class DBUtils
    {
        private static readonly MySqlConnection Connection = new(string.Format(TestDataGetter.DBSettings.DBConnection, TestDataGetter.DBSettings.Login, TestDataGetter.DBSettings.Password));

        public static void Open()
        {
            Logger.Instance.Info("MySQL open");
            Connection.Open();
        }

        public static void Close()
        {
            Logger.Instance.Info("MySQL close");
            Connection.Close();
        }

        public static void ExecuteSql(string sql)
        {
            Logger.Instance.Info($"MySQL execute {sql}");
            new MySqlCommand(sql, Connection).ExecuteNonQuery();
        }

        public static void ExecuteSqlWithBlobType(string sql, string name, byte[] data)
        {
            Logger.Instance.Info($"MySQL execute {sql} with blob type");
            var command = new MySqlCommand(sql, Connection);
            command.Parameters.Add(name, MySqlDbType.Blob).Value = data;
            command.ExecuteNonQuery();
        }

        public static MySqlDataReader ExecuteReader(string sql)
        {
            Logger.Instance.Info($"MySQL execute reader {sql}");
            return new MySqlCommand(sql, Connection).ExecuteReader();
        }
    }
}