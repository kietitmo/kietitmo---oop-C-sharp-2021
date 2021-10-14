using System;
using System.Collections.Generic;
using Isu.Classes;
using IsuExtra.Classes;
using IsuExtra.OGNPManager;

namespace IsuExtra
{
    internal class Program
    {
        private static void Main()
        {
            //// tao sinh vien
            var kiet = new Student("Kiet", "M3212");
            var nam = new Student("Nam", "M3212");
            var kien = new Student("Kien", "M3212");
            var ronaldo = new Student("Ronaldo", "R3202");
            var leo = new Student("Leo", "K3232");
            var mason = new Student("Mason", "P3212");

            var schedule1 = new Schedule();
            var para1 = new Para(1, 2);
            schedule1.AddPara(para1, "monday");
            var m3212 = new GroupWrapper("M3212", schedule1);
            m3212.StudentsList.Add(kiet);
            m3212.StudentsList.Add(nam);
            m3212.StudentsList.Add(kien);

            var schedule2 = new Schedule();
            var para2 = new Para(1, 2);
            schedule2.AddPara(para2, "tuesday");
            var r3202 = new GroupWrapper("R3202", schedule2);
            r3202.StudentsList.Add(ronaldo);

            var schedule3 = new Schedule();
            var para3 = new Para(4, 5);
            schedule3.AddPara(para3, "wednesday");
            var k3232 = new GroupWrapper("K3232", schedule3);
            k3232.StudentsList.Add(leo);

            var schedule4 = new Schedule();
            var para4 = new Para(4, 5);
            schedule2.AddPara(para4, "thursday");
            var p3212 = new GroupWrapper("P3212", schedule4);
            p3212.StudentsList.Add(mason);

            //// tao ognp1
            var ognp1 = new OGNP("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            var lecturer = new Lecturer("Povyshev");
            var para1OGNP = new Para(4, 5);
            var para2OGNP = new Para(6, 7);
            scheduleOGNP1.AddPara(para1OGNP, "tuesday");
            scheduleOGNP1.AddPara(para2OGNP, "tuesday");

            //// add potok1
            var potokOGNP1 = new Potok(scheduleOGNP1, lecturer);
            ognp1.PotokOGNP.Add(potokOGNP1);

            var scheduleOGNP2 = new Schedule();

            var lecturer2 = new Lecturer("Alina");
            var para1OGNP2 = new Para(4, 5);
            var para2OGNP2 = new Para(6, 7);
            scheduleOGNP2.AddPara(para1OGNP2, "monday");
            scheduleOGNP2.AddPara(para2OGNP2, "monday");

            //// add potok2
            var potokOGNP2 = new Potok(scheduleOGNP1, lecturer2);
            ognp1.PotokOGNP.Add(potokOGNP2);

            var test = new OGNPManagement();
            test.AddNewOGNP(ognp1);
            test.StudentRegistersOGNP(kiet, m3212, ognp1, potokOGNP1);
            test.StudentRegistersOGNP(mason, p3212, ognp1, potokOGNP1);
            test.StudentRegistersOGNP(leo, k3232, ognp1, potokOGNP1);
            test.StudentRegistersOGNP(ronaldo, r3202, ognp1, potokOGNP1);

            test.StudentRegistersOGNP(nam, m3212, ognp1, potokOGNP2);

            List<Student> listOGNP1 = test.GetStudentsOfOGNP(ognp1);
            Console.WriteLine(listOGNP1.Count);

            List<Student> listnotOGNP1 = test.GetStudentsDidNotRegister(m3212);
            Console.WriteLine(listnotOGNP1.Count);

            //// delete kiet
            test.DeleteRegistration(kiet, potokOGNP1);
            listOGNP1 = test.GetStudentsOfOGNP(ognp1);
            Console.WriteLine(listOGNP1.Count);

            List<Potok> potoksOfOgnp1 = test.GetPotokOfOGNP(ognp1);
            Console.WriteLine(potoksOfOgnp1.Count);
        }
    }
}
