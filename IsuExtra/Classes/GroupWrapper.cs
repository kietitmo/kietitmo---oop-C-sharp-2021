using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class GroupWrapper
    {
        private Group _tempGroup;
        private Schedule _groupSchedule;
        private Faculty _facultyOfGroup;
        public GroupWrapper(string groupname, Schedule schedule)
        {
            _tempGroup = new Group(groupname);
            GroupSchedule = schedule;
            FacultyOfGroup = new Faculty(groupname[0]);
        }

        public Schedule GroupSchedule { get => _groupSchedule; set => _groupSchedule = value; }
        public string Name { get => _tempGroup.Name; set => _tempGroup.Name = value; }
        public Faculty FacultyOfGroup { get => _facultyOfGroup; set => _facultyOfGroup = value; }
        public CourseNumber CourseNum { get => _tempGroup.CourseNum; set => _tempGroup.CourseNum = value; }

        public int GroupNumber { get => _tempGroup.GroupNum; }

        public List<Student> StudentsList { get => _tempGroup.StudentsList; set => _tempGroup.StudentsList = value; }
    }
}
