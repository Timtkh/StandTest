namespace ExamTest.TestSolution.Models.DataBaseModels
{
    public class Test
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string StatusId { get; set; }
        public string MethodName { get; set; }
        public long ProjectId { get; set; }
        public long SessionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Env { get; set; }
        public string Browser { get; set; }
    }
}