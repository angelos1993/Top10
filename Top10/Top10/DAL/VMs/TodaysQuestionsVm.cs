namespace Top10.DAL.VMs
{
    public class TodaysQuestionsVm
    {
        public string Question { get; set; }
        public int Mark { get; set; }
        public string TrueAnswer { get; set; }
        public string UserAnswer { get; set; }
        public bool IsTrue => TrueAnswer == UserAnswer;
    }
}