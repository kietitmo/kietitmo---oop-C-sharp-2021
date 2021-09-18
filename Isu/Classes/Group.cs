using System;
using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Classes
{
    public class Group
    {
        private string name;
        private CourseNumber courseNum;
        private List<Student> studentsList = null;
        private int groupNum;
        public Group(string groupName)
        {
            Name = groupName;
            CourseNum = GetCourseFromName(groupName);
            groupNum = GetGroupNum(groupName);
            StudentsList = new List<Student>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length != 5 || value[0] != 'M' || value[1] != '3' || string.IsNullOrEmpty(value))
                {
                    //// if group name is wrong (!= M3XYY), throw exception
                    throw new IsuException("Wrong_Group_Name_Exception");
                }
                else
                {
                    name = value;
                }
            }
        }

        public CourseNumber CourseNum
        {
            get
            {
                return courseNum;
            }
            set
            {
                if (value.Number > 5 || value.Number < 1)
                {
                    //// if course number is wrong, throw exception
                    throw new IsuException("Wrong_Course_Number_Exception");
                }
                else
                {
                    courseNum = value;
                }
            }
        }

        public int GroupNum { get => groupNum; }
        public List<Student> StudentsList { get => studentsList; set => studentsList = value; }

        public void Show()
        {
            Console.WriteLine("Group " + Name + ": ");
            for (int i = 0; i < studentsList.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                studentsList[i].Show();
            }
        }

        private CourseNumber GetCourseFromName(string groupName)
        {
            if (groupName.Length != 5 || groupName[0] != 'M' || groupName[1] != '3' || string.IsNullOrEmpty(groupName))
            {
                //// if group name is wrong (!= M3XYY), throw exception
                throw new IsuException("Wrong_Group_Name_Exception");
            }
            else
            {
                var temp = new CourseNumber(Convert.ToInt32(groupName[2]) - 48);
                return temp;
            }
        }

        private int GetGroupNum(string groupName)
        {
            if (groupName.Length != 5 || groupName[0] != 'M' || groupName[1] != '3' || string.IsNullOrEmpty(groupName))
            {
                //// if group name is wrong (!= M3XYY), throw exception
                throw new IsuException("Wrong_Group_Name_Exception");
            }
            else
            {
                return Convert.ToInt32(groupName.Substring(3));
            }
        }
    }
}
