using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class Stream
    {
        private List<Student> _studentList;
        private Lecturer _lecturerOfStream;
        private Schedule _scheduleOfStream;
        public Stream(Schedule schedule, Lecturer lecturer)
        {
            StudentList = new List<Student>();
            ScheduleOfStream = schedule;
            LecturerOfStream = lecturer;
        }

        public List<Student> StudentList { get => _studentList; set => _studentList = value; }
        public Schedule ScheduleOfStream { get => _scheduleOfStream; set => _scheduleOfStream = value; }
        public Lecturer LecturerOfStream { get => _lecturerOfStream; set => _lecturerOfStream = value; }
    }
}
