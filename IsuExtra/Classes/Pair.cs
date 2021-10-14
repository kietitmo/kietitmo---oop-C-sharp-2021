namespace IsuExtra.Classes
{
    public class Pair
    {
        private int startTime;
        private int endTime;
        public Pair(int startTime, int endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public int StartTime { get => startTime; set => startTime = value; }
        public int EndTime { get => endTime; set => endTime = value; }
    }
}
