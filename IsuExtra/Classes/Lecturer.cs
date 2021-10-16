using Isu.Tools;

namespace IsuExtra.Classes
{
    public class Lecturer
    {
        private string _name;
        public Lecturer(string lecturerName)
        {
            if (string.IsNullOrEmpty(lecturerName))
            {
                throw new IsuException("Lecturer_Name_Invalid_Exception");
            }

            Name = lecturerName;
        }

        public string Name { get => _name; set => _name = value; }
    }
}
