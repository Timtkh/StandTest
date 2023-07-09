namespace ExamTest.TestSolution.Models.UIModels
{
    public class ProjectTest
    {
        public string TestName { get; set; }
        public string TestMethod { get; set; }
        public string LatestTestResult { get; set; }
        public DateTime LatestTestStartTime { get; set; }
        public DateTime LatestTestEndTime { get; set; }
        public DateTime LatestTestDuration { get; set; }
        public string History { get; set; }
    }
}