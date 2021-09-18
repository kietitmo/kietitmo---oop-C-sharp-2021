using System;
using System.Collections.Generic;
using Isu.Classes;
using Isu.Services;
namespace Isu
{
    internal class Program
    {
        public static void Main()
        {
            //// add new Group and Student
            var isuService = new IsuService();
            Group m3212 = isuService.AddGroup("M3212");
            Group m3213 = isuService.AddGroup("M3213");
            Group m3112 = isuService.AddGroup("M3112");
            Group m3312 = isuService.AddGroup("M3312");
            Student kiet = isuService.AddStudent(m3212, "Kiet Nguyen");
            isuService.AddStudent(m3213, "Kilyan Mbappe");
            isuService.AddStudent(m3112, "Leo Messi");
            isuService.AddStudent(m3312, "Cristiano Ronaldo");
            Console.WriteLine("***********Added new group and new student");
            m3212.Show();
            kiet.Show();

            //// get studednt by id
            Student getStuRes = isuService.GetStudent(2);
            Console.WriteLine("\n*************get studednt by id");
            getStuRes.Show();

            //// get student by name
            getStuRes = isuService.FindStudent("Leo Messi");
            Console.WriteLine("\n*************get student by name");
            getStuRes.Show();

            //// Get more students by group name
            List<Student> getsMoreStudentRes = isuService.FindStudents("M3212");
            Console.WriteLine("\n*************Get more students by group name");
            Show(getsMoreStudentRes);

            //// get more student by course number
            var courseNeedToFind = new CourseNumber(2);
            getsMoreStudentRes = isuService.FindStudents(courseNeedToFind);
            Console.WriteLine("\n************get more student by course number");
            Show(getsMoreStudentRes);

            //// get group by group name
            Group groupRes = isuService.FindGroup("M3212");
            Console.WriteLine("\n************Get group by group name");
            groupRes.Show();

            //// get more group by course number
            courseNeedToFind.Number = 2;
            Console.WriteLine("\n************Get group by course number");
            List<Group> groupResList = isuService.FindGroups(courseNeedToFind);
            for (int i = 0; i < groupResList.Count; i++)
            {
                groupResList[i].Show();
            }

            //// Change student to other group
            Console.WriteLine("\n************Change student to other group");
            m3212.Show();
            Console.WriteLine("Changed!!!");
            isuService.ChangeStudentGroup(kiet, m3213);
            m3212.Show();
            m3213.Show();
        }

        public static void Show(List<Student> studentsList)
        {
            for (int i = 0; i < studentsList.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                studentsList[i].Show();
            }
        }
    }
}
