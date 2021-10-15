using System.Collections.Generic;
using Isu.Classes;
using Isu.Tools;
using IsuExtra.Classes;

namespace IsuExtra.OGNPManager
{
    public class OgnpManagement
    {
        private List<Ognp> _ognpList;
        public OgnpManagement()
        {
            OgnpList = new List<Ognp>();
        }

        public List<Ognp> OgnpList { get => _ognpList; set => _ognpList = value; }

        public Ognp AddNewOgnp(Ognp tempOgnp)
        {
            OgnpList.Add(tempOgnp);
            return tempOgnp;
        }

        public void StudentRegistersOgnp(Student student, GroupWrapper groupOfStudent, Ognp ognp, Stream stream)
        {
            if (groupOfStudent.FacultyOfGroup.LetterOfFaculty == ognp.OfFaculty.LetterOfFaculty)
            {
                throw new IsuException("Register OGNP Of Student's Faculty Exception");
            }

            if (groupOfStudent.GroupSchedule.IsIntersectOther(stream.ScheduleOfStream))
            {
                throw new IsuException("Schedules cut each other Exception");
            }

            stream.StudentList.Add(student);
        }

        public void DeleteRegistration(Student student, Stream streamOfStudent)
        {
            int index = streamOfStudent.StudentList.IndexOf(student);
            if (index == -1)
            {
                throw new IsuException("student did not registered OGNP Exception");
            }

            streamOfStudent.StudentList.RemoveAt(index);
            return;
        }

        public List<Stream> GetStreamOfOgnp(Ognp ognp)
        {
            return ognp.StreamsOfOgnp;
        }

        public List<Student> GetStudentsOfOgnp(Ognp ognp)
        {
            var studentList = new List<Student>();
            foreach (Stream tempStream in ognp.StreamsOfOgnp)
            {
                studentList.AddRange(tempStream.StudentList);
            }

            return studentList;
        }

        public List<Student> GetStudentsDidNotRegister(GroupWrapper group)
        {
            var studentList = new List<Student>();
            foreach (Student tempStudent in group.StudentsList)
            {
                int count = 0;
                foreach (Ognp tempOgnp in OgnpList)
                {
                    foreach (Stream tempStream in tempOgnp.StreamsOfOgnp)
                    {
                        if (tempStream.StudentList.Contains(tempStudent))
                        {
                            count++;
                        }
                    }
                }

                if (count == 0)
                {
                    studentList.Add(tempStudent);
                }
            }

            return studentList;
        }
    }
}
