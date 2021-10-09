using System;
using System.Collections.Generic;
using Isu.Classes;
using Isu.Tools;
using IsuExtra.Classes;

namespace IsuExtra.OGNPManager
{
    public class OGNPManagement
    {
        private List<OGNP> _ognpList;
        public OGNPManagement()
        {
            OgnpList = new List<OGNP>();
        }

        public List<OGNP> OgnpList { get => _ognpList; set => _ognpList = value; }

        public OGNP AddNewOGNP(OGNP tempOGNP)
        {
            OgnpList.Add(tempOGNP);
            return tempOGNP;
        }

        public void StudentRegistersOGNP(Student student, GroupWrapper groupOfStudent, OGNP ognp, Potok potok)
        {
            if (student.GroupName[0] == ognp.OfFaculty)
            {
                throw new IsuException("Register OGNP Of Student's Faculty Exception");
            }

            if (groupOfStudent.GroupSchedule.IsIntersectOther(potok.PotokSchedule))
            {
                throw new IsuException("Schedules cut each other Exception");
            }

            potok.StudentList.Add(student);
        }

        public void DeleteRegistration(Student student, Potok potok)
        {
            for (int i = 0; i < potok.StudentList.Count; i++)
            {
                if (potok.StudentList[i].Id == student.Id)
                {
                    potok.StudentList.RemoveAt(i);
                }
            }
        }

        public List<Potok> GetPotokOfOGNP(OGNP ognp)
        {
            return ognp.PotokOGNP;
        }

        public List<Student> GetStudentsOfOGNP(OGNP ognp)
        {
            var studentList = new List<Student>();
            for (int i = 0; i < ognp.PotokOGNP.Count; i++)
            {
                studentList.AddRange(ognp.PotokOGNP[i].StudentList);
            }

            return studentList;
        }

        public List<Student> GetStudentsDidNotRegister(GroupWrapper group)
        {
            var studentList = new List<Student>();
            for (int i = 0; i < group.StudentsList.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < OgnpList.Count; j++)
                {
                    for (int k = 0; k < OgnpList[j].PotokOGNP.Count; k++)
                    {
                        if (OgnpList[j].PotokOGNP[k].StudentList.Contains(group.StudentsList[i]))
                        {
                            count++;
                        }
                    }
                }

                if (count == 0)
                {
                    studentList.Add(group.StudentsList[i]);
                }
            }

            return studentList;
        }

        public void Show(List<Student> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write("Student: " + list[i].Name + "\t\t\t");
                Console.Write("ID: " + list[i].Id + "\t\t\t");
                Console.WriteLine("Group: " + list[i].GroupName);
            }
        }
    }
}
