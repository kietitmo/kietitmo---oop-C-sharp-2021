using System;
using Isu.Tools;

namespace Isu.Classes
{
    public class Student
    {
        private static int coundID = 0;
        private int id = 0;
        private string name;
        private string group;

        public Student(string studentName)
        {
            name = studentName;
            id = ++coundID;
        }

        public Student(string studentName, string groupName)
        {
            name = studentName;
            group = groupName;
            id = ++coundID;
        }

        public int Id { get => id; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //// if name is null, throw exception
                    throw new IsuException("Wrong_Student_Name_Exception");
                }
                else
                {
                    name = value;
                }
            }
        }

        public string GroupName
        {
            get
            {
                return group;
            }
            set
            {
                if (value.Length != 5 || value[0] != 'M' || value[1] != '3' || string.IsNullOrEmpty(value))
                {
                    //// if group name is wrong, throw exception
                    throw new IsuException("Wrong_Group_Name_Exception");
                }
                else
                {
                    group = value;
                }
            }
        }

        public void Show()
        {
            Console.Write("Student: " + Name + "\t\t\t");
            Console.Write("ID: " + Id + "\t\t\t");
            Console.WriteLine("Group: " + GroupName);
        }
    }
}