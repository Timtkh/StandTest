using Aquality.Selenium.Core.Logging;
using ExamTest.Framework.Utils;
using ExamTest.TestSolution.Enums;
using ExamTest.TestSolution.Models.DataBaseModels;
using ExamTest.TestSolution.Workers;
using NUnit.Framework;

namespace ExamTest.TestSolution.Steps
{
    public static class DBSteps
    {
        private const string LogFilePath = @"Log\log.log";

        public static List<Test> GetTests(string projectName)
        {
            Logger.Instance.Info("Get tests");
            return TestWorker.Get(ProjectWorker.Get(projectName).Id);
        }

        public static void AddDataToDB(string projectName, int sessionKey, int buildNumber, string testName, int statusId, string browserName, byte[] screenshot)
        {
            Logger.Instance.Info("Add data to DB");
            SessionWorker.Insert(new Session()
            {
                SessionKey = sessionKey.ToString(),
                BuildNumber = buildNumber.ToString()
            });

            TestWorker.Insert(new Test()
            {
                Name = testName,
                StatusId = statusId.ToString(),
                MethodName = TestContext.CurrentContext.Test.MethodName,
                ProjectId = ProjectWorker.Get(projectName).Id,
                SessionId = SessionWorker.Get(sessionKey.ToString()).Id,
                Env = Environment.MachineName,
                Browser = browserName
            });

            LogWorker.Insert(new Log()
            {
                Content = FileUtils.GetLastLineFromFile(LogFilePath),
                TestId = TestWorker.GetOne(ProjectWorker.Get(projectName).Id).Id
            });

            AttachmentWorker.Insert(new Attachment()
            {
                Content = screenshot,
                ContentType = FileType.ImageType,
                TestId = TestWorker.GetOne(ProjectWorker.Get(projectName).Id).Id
            });
        }

        public static Test GetTest(string projectName)
        {
            Logger.Instance.Info("Get test");
            return TestWorker.GetOne(ProjectWorker.Get(projectName).Id);
        }

        public static string GetLogContent(Test createdTest)
        {
            Logger.Instance.Info("Get log content");
            return LogWorker.Get(createdTest.Id).Content;
        }
    }
}