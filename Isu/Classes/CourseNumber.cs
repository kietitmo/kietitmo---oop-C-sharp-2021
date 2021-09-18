using Isu.Tools;

namespace Isu.Classes
{
    public class CourseNumber
    {
        private int number;

        public CourseNumber(int number)
        {
            Number = number;
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value > 5 || value < 1)
                {
                    //// if course number is wrong, throw exception
                    throw new IsuException("Wrong_Course_Number_Exception");
                }
                else
                {
                    number = value;
                }
            }
        }
    }
}