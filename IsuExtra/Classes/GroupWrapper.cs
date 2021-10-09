using System.Collections.Generic;
using Isu.Classes;
using Isu.Tools;

namespace IsuExtra.Classes
{
    public class GroupWrapper
    {
        private Group _tempGroup;
        private Schedule _groupSchedule;
        private char _facultyOfGroup;
        public GroupWrapper(string groupname, Schedule schedule)
        {
            TempGroup = new Group(groupname);
            GroupSchedule = schedule;
            FacultyOfGroup = groupname[0];
        }

        public Schedule GroupSchedule { get => _groupSchedule; set => _groupSchedule = value; }
        public Group TempGroup { get => _tempGroup; set => _tempGroup = value; }
        public string Name
        {
            get
            {
                return TempGroup.Name;
            }
            set
            {
                TempGroup.Name = value;
            }
        }

        public char FacultyOfGroup
        {
            get
            {
                return _facultyOfGroup;
            }
            set
            {
                if (!char.IsLetter(value))
                {
                    throw new IsuException("InvalidFacultyOfSudentException");
                }

                _facultyOfGroup = value;
            }
        }

        public CourseNumber CourseNum
        {
            get
            {
                return TempGroup.CourseNum;
            }
            set
            {
                TempGroup.CourseNum = value;
            }
        }

        public int GroupNum
        {
            get
            {
                return TempGroup.GroupNum;
            }
        }

        public List<Student> StudentsList
        {
            get
            {
                return TempGroup.StudentsList;
            }
            set
            {
                TempGroup.StudentsList = value;
            }
        }

        public void Show()
        {
            TempGroup.Show();
        }
    }
}
