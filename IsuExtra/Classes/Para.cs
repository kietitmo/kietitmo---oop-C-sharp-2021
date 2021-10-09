namespace IsuExtra.Classes
{
    public class Para
    {
        private int startTime;
        private int endTime;
        public Para(int startTime, int endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public int StartTime { get => startTime; set => startTime = value; }
        public int EndTime { get => endTime; set => endTime = value; }
    }
}
