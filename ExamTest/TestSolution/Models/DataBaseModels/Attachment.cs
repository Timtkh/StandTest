namespace ExamTest.TestSolution.Models.DataBaseModels
{
    public class Attachment
    {
        public long Id { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public long TestId { get; set; }
    }
}