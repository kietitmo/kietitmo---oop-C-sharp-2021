using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class Potok
    {
        private List<Student> _studentList;
        private Lecturer _lecturerOfPotok;
        private Schedule _potokSchedule;
        public Potok(Schedule schedule, Lecturer lecturer)
        {
            StudentList = new List<Student>();
            PotokSchedule = schedule;
            LecturerOfPotok = lecturer;
        }

        public List<Student> StudentList { get => _studentList; set => _studentList = value; }
        public Schedule PotokSchedule { get => _potokSchedule; set => _potokSchedule = value; }
        public Lecturer LecturerOfPotok { get => _lecturerOfPotok; set => _lecturerOfPotok = value; }
    }
}
