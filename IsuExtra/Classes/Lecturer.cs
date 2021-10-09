using Isu.Tools;

namespace IsuExtra.Classes
{
    public class Lecturer
    {
        private string _name;
        public Lecturer(string lecturerName)
        {
            Name = lecturerName;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IsuException("Lecturer_Name_Invalid_Exception");
                }

                _name = value;
            }
        }
    }
}
