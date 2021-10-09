using Isu.Classes;
using Isu.Tools;
namespace IsuExtra.Classes
{
    public class StudentWrapper
    {
        private Student _tempStudent;
        private char _facultyOfStudent;
        private Schedule _scheduleOfStudent;
        public StudentWrapper(string nameOfStudent, string groupOfStudent, Schedule scheduleOfStudent)
        {
            TempStudent = new Student(nameOfStudent, groupOfStudent);
            FacultyOfStudent = groupOfStudent[0];
            ScheduleOfStudent = scheduleOfStudent;
        }

        public Student TempStudent { get => _tempStudent; set => _tempStudent = value; }
        public char FacultyOfStudent
        {
            get
            {
                return _facultyOfStudent;
            }
            set
            {
                if (!char.IsLetter(value))
                {
                    throw new IsuException("InvalidFacultyOfSudentException");
                }

                _facultyOfStudent = value;
            }
        }

        public string NameOfSudent
        {
            get
            {
                return TempStudent.Name;
            }
            set
            {
                TempStudent.Name = value;
            }
        }

        public string GroupOfStudent
        {
            get
            {
                return TempStudent.GroupName;
            }
            set
            {
                TempStudent.GroupName = value;
            }
        }

        public int GetIdOfStudent
        {
            get
            {
                return TempStudent.Id;
            }
        }

        public Schedule ScheduleOfStudent { get => _scheduleOfStudent; set => _scheduleOfStudent = value; }

        public void ShowStudent()
        {
            TempStudent.Show();
        }
    }
}
