namespace IsuExtra.Classes
{
    public class Pair
    {
        private int _startTime;
        private int _endTime;
        public Pair(int startTime, int endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public int StartTime { get => _startTime; set => _startTime = value; }
        public int EndTime { get => _endTime; set => _endTime = value; }
    }
}
