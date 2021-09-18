using System.Collections.Generic;
using Isu.Classes;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        //// Create new List to contain object Group
        private List<Group> groupList = null;

        public IsuService()
        {
            GroupList = new List<Group>();
        }

        public List<Group> GroupList { get => groupList; set => groupList = value; }

        public Group AddGroup(string name)
        {
            if (FindGroup(name) != null)
            {
                throw new IsuException("Added_Existing_Group");
            }

            var newGroup = new Group(name);
            groupList.Add(newGroup);
            return newGroup;
        }

        public Student AddStudent(Group group, string name)
        {
            /*
             if (group.StudentsList.Count >= MaxStudentPerGroup - 1)
             {
                 throw new IsuException("Reach_Max_Student_Exception");
             }
            */
            if (FindStudent(name) != null)
            {
                throw new IsuException("Added_Existing_Student");
            }

            var newStudent = new Student(name, group.Name);
            group.StudentsList.Add(newStudent);
            return newStudent;
        }

        public Student GetStudent(int id)
        {
            //// Searching student in groups of groupList
            for (int i = 0; i < groupList.Count; i++)
            {
                for (int j = 0; j < groupList[i].StudentsList.Count; j++)
                {
                    if (groupList[i].StudentsList[j].Id == id)
                    {
                        return groupList[i].StudentsList[j];
                    }
                }
            }

            //// Throw IsException if not found
            throw new IsuException("Student_Not_Found_Exception");
        }

        public Student FindStudent(string name)
        {
            //// Searching student in groups of groupList
            for (int i = 0; i < groupList.Count; i++)
            {
                for (int j = 0; j < groupList[i].StudentsList.Count; j++)
                {
                    if (groupList[i].StudentsList[j].Name == name)
                    {
                        return groupList[i].StudentsList[j];
                    }
                }
            }

            //// Throw IsException if not found
            return null;
            throw new IsuException("Student_Not_Found_Exception");
        }

        public List<Student> FindStudents(string groupName)
        {
            //// Searching students in groups of groupList by group name
            var foundList = new List<Student>();
            for (int i = 0; i < groupList.Count; i++)
            {
                if (groupList[i].Name == groupName)
                {
                    foundList.AddRange(GroupList[i].StudentsList);
                }
            }

            //// Throw IsException if not found
            if (foundList.Count == 0)
            {
                throw new IsuException("Student_Not_Found_Exception");
            }
            else
            {
                return foundList;
            }
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            //// Searching students in groups of groupList by course number
            var foundList = new List<Student>();
            for (int i = 0; i < groupList.Count; i++)
            {
                if (groupList[i].CourseNum.Number == courseNumber.Number)
                {
                    foundList.AddRange(GroupList[i].StudentsList);
                }
            }

            //// Throw IsException if not found
            if (foundList.Count == 0)
            {
                throw new IsuException("Student_Not_Found_Exception");
            }
            else
            {
                return foundList;
            }
        }

        public Group FindGroup(string groupName)
        {
            //// Searching group by groupname
            for (int i = 0; i < groupList.Count; i++)
            {
                if (groupList[i].Name == groupName)
                {
                    return GroupList[i];
                }
            }

            //// Throw IsuException if not found
            return null;
            throw new IsuException("Group_Not_Found_Exception");
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            //// Searching groups by course number
            var foundList = new List<Group>();
            for (int i = 0; i < groupList.Count; i++)
            {
                if (groupList[i].CourseNum.Number == courseNumber.Number)
                {
                    foundList.Add(GroupList[i]);
                }
            }

            //// Throw IsuException if not found
            if (foundList.Count == 0)
            {
                throw new IsuException("Group_Not_Found_Exception");
            }
            else
            {
                return foundList;
            }
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            bool found = false; //// to know found or not found when we searching in data
            //// Searching for student
            for (int i = 0; i < groupList.Count; i++)
            {
                for (int j = 0; j < groupList[i].StudentsList.Count; j++)
                {
                    if (groupList[i].StudentsList[j].Name == student.Name)
                    {
                        groupList[i].StudentsList.RemoveAt(j);
                        found = true;
                        break;
                    }
                }
            }

            //// Throw IsuException if not found
            if (found == false)
            {
                throw new IsuException("Student_Not_Found_Exception");
            }

            //// Change group name of student and add him to new group
            student.GroupName = newGroup.Name;
            AddStudent(newGroup, student.Name);
        }
    }
}
