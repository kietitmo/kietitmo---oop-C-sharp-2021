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

        public void StudentRegistersOGNP(Student student, GroupWrapper groupOfStudent, OGNP ognp, Stream stream)
        {
            if (student.GroupName[0] == ognp.OfFaculty)
            {
                throw new IsuException("Register OGNP Of Student's Faculty Exception");
            }

            if (groupOfStudent.GroupSchedule.IsIntersectOther(stream.ScheduleOfStream))
            {
                throw new IsuException("Schedules cut each other Exception");
            }

            stream.StudentList.Add(student);
        }

        public void DeleteRegistration(Student student, Stream potok)
        {
            for (int i = 0; i < potok.StudentList.Count; i++)
            {
                if (potok.StudentList[i].Id == student.Id)
                {
                    potok.StudentList.RemoveAt(i);
                }
            }
        }

        public List<Stream> GetPotokOfOGNP(OGNP ognp)
        {
            return ognp.StreamOfOGNP;
        }

        public List<Student> GetStudentsOfOGNP(OGNP ognp)
        {
            var studentList = new List<Student>();
            for (int i = 0; i < ognp.StreamOfOGNP.Count; i++)
            {
                studentList.AddRange(ognp.StreamOfOGNP[i].StudentList);
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
                    for (int k = 0; k < OgnpList[j].StreamOfOGNP.Count; k++)
                    {
                        if (OgnpList[j].StreamOfOGNP[k].StudentList.Contains(group.StudentsList[i]))
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
    }
}
