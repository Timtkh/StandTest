using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Models.DataBaseModels;

namespace ExamTest.TestSolution.Workers
{
    public static class AttachmentWorker
    {
        private const string InsertQuery = "INSERT INTO attachment (content, content_type, test_id) VALUES (@image, '{0}', {1})";
        private const string GetQuery = "SELECT * FROM attachment WHERE test_id = '{0}'";
        private const string ContentColumn = "content";

        public static void Insert(Attachment attachment)
        {
            Logger.Instance.Info("Attachment worker insert");
            DBUtils.ExecuteSqlWithBlobType(sql: string.Format(InsertQuery, attachment.ContentType, attachment.TestId), name: "@image", data: attachment.Content);
        }

        public static Attachment Get(long testId)
        {
            Logger.Instance.Info("Attachment worker get");
            var attachment = new Attachment();

            using (var attachmentDataReader = DBUtils.ExecuteReader(string.Format(GetQuery, testId)))
            {
                while (attachmentDataReader.Read())
                {
                    attachment.Content = (byte[])attachmentDataReader[ContentColumn];
                }
            }

            return attachment;
        }
    }
}