using System.Collections.Generic;
using IsuExtra.OGNPManager;
using IsuExtra.Classes;
using Isu.Classes;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        public OgnpManagement ognpTest;
         [SetUp]
        public void Setup()
        {
            ognpTest = new OgnpManagement(); 
        }

        [Test]
        public void AddNewOgnp()
        {
            var ognp1 = new Ognp("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            //// Create first Potok of OGNP
            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, DayOfWeek.Tuesday);
            scheduleOGNP1.Addpair(pair2OGNP, DayOfWeek.Tuesday);
            var streamOfOgnp1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.StreamsOfOgnp.Add(streamOfOgnp1);

            //// Create second Potok of OGNP
            var scheduleOGNP2 = new Schedule();
            var lecturer2 = new Lecturer("Alina");
            var pair1OGNP2 = new Pair(4, 5);
            var pair2OGNP2 = new Pair(6, 7);
            scheduleOGNP2.Addpair(pair1OGNP2, DayOfWeek.Monday);
            scheduleOGNP2.Addpair(pair2OGNP2, DayOfWeek.Monday);
            var streamOfOgnp2 = new Stream(scheduleOGNP1, lecturer2);
            ognp1.StreamsOfOgnp.Add(streamOfOgnp2);

            //// add ognp 1
            ognpTest.AddNewOgnp(ognp1);
            Assert.AreEqual(ognpTest.OgnpList.Count, 1);
        }

        [Test]
        public void StudentRegisterOgnp()
        {
            var kiet = new Student("Kiet", "M3212");

            var schedule1 = new Schedule();
            var pair1 = new Pair(1, 2);
            schedule1.Addpair(pair1, DayOfWeek.Monday);
            var m3212 = new GroupWrapper("M3212", schedule1);
            m3212.StudentsList.Add(kiet);

            var ognp1 = new Ognp("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            //// Create first Potok of OGNP
            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, DayOfWeek.Tuesday);
            scheduleOGNP1.Addpair(pair2OGNP, DayOfWeek.Tuesday);
            var streamOfOgnp1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.StreamsOfOgnp.Add(streamOfOgnp1);

            //// Students Register OGNP
            ognpTest.AddNewOgnp(ognp1);
            ognpTest.StudentRegistersOgnp(kiet, m3212, ognp1, streamOfOgnp1);
            List<Student> sutdentList = ognpTest.GetStudentsOfOgnp(ognp1);
            Assert.AreEqual(sutdentList.Count, 1);
        }

        [Test]
        public void StudentUnregisterOgnp()
        {
            var kiet = new Student("Kiet", "M3212");

            var schedule1 = new Schedule();
            var pair1 = new Pair(1, 2);
            schedule1.Addpair(pair1, DayOfWeek.Monday);
            var m3212 = new GroupWrapper("M3212", schedule1);
            m3212.StudentsList.Add(kiet);

            var ognp1 = new Ognp("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            //// Create first Potok of OGNP
            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, DayOfWeek.Tuesday);
            scheduleOGNP1.Addpair(pair2OGNP, DayOfWeek.Tuesday);
            var streamOfOgnp1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.StreamsOfOgnp.Add(streamOfOgnp1);

            //// Students Register OGNP
            ognpTest.AddNewOgnp(ognp1);
            ognpTest.StudentRegistersOgnp(kiet, m3212, ognp1, streamOfOgnp1);

            //// Student Unregister OGNP
            ognpTest.DeleteRegistration(kiet, streamOfOgnp1);
            List<Student> sutdentList = ognpTest.GetStudentsOfOgnp(ognp1);
            Assert.AreEqual(sutdentList.Count, 0);
        }

        [Test]
        public void GetStreamsFromOgnp()
        {
            var kiet = new Student("Kiet", "M3212");
            var nam = new Student("Nam", "M3212");
            var ronaldo = new Student("Ronaldo", "R3202");

            var schedule1 = new Schedule();
            var pair1 = new Pair(1, 2);
            schedule1.Addpair(pair1, DayOfWeek.Monday);
            var m3212 = new GroupWrapper("M3212", schedule1);
            m3212.StudentsList.Add(kiet);
            m3212.StudentsList.Add(nam);

            var schedule2 = new Schedule();
            var pair2 = new Pair(1, 2);
            schedule2.Addpair(pair2, DayOfWeek.Tuesday);
            var r3202 = new GroupWrapper("R3202", schedule2);
            r3202.StudentsList.Add(ronaldo);

            var ognp1 = new Ognp("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            //// Create first Potok of OGNP
            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, DayOfWeek.Tuesday);
            scheduleOGNP1.Addpair(pair2OGNP, DayOfWeek.Tuesday);
            var streamOfOgnp1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.StreamsOfOgnp.Add(streamOfOgnp1);

            //// Create second Potok of OGNP
            var scheduleOGNP2 = new Schedule();
            var lecturer2 = new Lecturer("Alina");
            var pair1OGNP2 = new Pair(4, 5);
            var pair2OGNP2 = new Pair(6, 7);
            scheduleOGNP2.Addpair(pair1OGNP2, DayOfWeek.Monday);
            scheduleOGNP2.Addpair(pair2OGNP2, DayOfWeek.Monday);
            var streamOfOgnp2 = new Stream(scheduleOGNP1, lecturer2);
            ognp1.StreamsOfOgnp.Add(streamOfOgnp2);

            //// Students Register OGNP
            ognpTest.AddNewOgnp(ognp1);
            ognpTest.StudentRegistersOgnp(kiet, m3212, ognp1, streamOfOgnp1);
            ognpTest.StudentRegistersOgnp(ronaldo, r3202, ognp1, streamOfOgnp1);
            ognpTest.StudentRegistersOgnp(nam, m3212, ognp1, streamOfOgnp2);

            //// get Potoks
            List<Stream> streamsOfOgnp1 = ognp1.StreamsOfOgnp;
            Assert.AreEqual(2, streamsOfOgnp1.Count);
        }

        [Test]
        public void GetStudentsFromOgnp()
        {
            //// create students
            var kiet = new Student("Kiet", "M3212");
            var nam = new Student("Nam", "M3212");
            var kien = new Student("Kien", "M3212");
            var ronaldo = new Student("Ronaldo", "R3202");
            var leo = new Student("Leo", "K3232");
            var mason = new Student("Mason", "P3212");

            var schedule1 = new Schedule();
            var pair1 = new Pair(1, 2);
            schedule1.Addpair(pair1, DayOfWeek.Monday);
            var m3212 = new GroupWrapper("M3212", schedule1);
            m3212.StudentsList.Add(kiet);
            m3212.StudentsList.Add(nam);
            m3212.StudentsList.Add(kien);

            var schedule2 = new Schedule();
            var pair2 = new Pair(1, 2);
            schedule2.Addpair(pair2, DayOfWeek.Tuesday);
            var r3202 = new GroupWrapper("R3202", schedule2);
            r3202.StudentsList.Add(ronaldo);

            var schedule3 = new Schedule();
            var pair3 = new Pair(4, 5);
            schedule3.Addpair(pair3, DayOfWeek.Wednesday);
            var k3232 = new GroupWrapper("K3232", schedule3);
            k3232.StudentsList.Add(leo);

            var schedule4 = new Schedule();
            var pair4 = new Pair(4, 5);
            schedule2.Addpair(pair4, DayOfWeek.Thursday);
            var p3212 = new GroupWrapper("P3212", schedule4);
            p3212.StudentsList.Add(mason);

            //// create ognp1
            var ognp1 = new Ognp("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, DayOfWeek.Tuesday);
            scheduleOGNP1.Addpair(pair2OGNP, DayOfWeek.Tuesday);

            //// add potok1
            var streamOfOgnp1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.StreamsOfOgnp.Add(streamOfOgnp1);

            var scheduleOGNP2 = new Schedule();

            var lecturer2 = new Lecturer("Alina");
            var pair1OGNP2 = new Pair(4, 5);
            var pair2OGNP2 = new Pair(6, 7);
            scheduleOGNP2.Addpair(pair1OGNP2, DayOfWeek.Monday);
            scheduleOGNP2.Addpair(pair2OGNP2, DayOfWeek.Monday);

            //// add potok2
            var streamOfOgnp2 = new Stream(scheduleOGNP1, lecturer2);
            ognp1.StreamsOfOgnp.Add(streamOfOgnp2);

            var test = new OgnpManagement();
            test.AddNewOgnp(ognp1);

            //// 5 Students register ognp1
            test.StudentRegistersOgnp(kiet, m3212, ognp1, streamOfOgnp1);
            test.StudentRegistersOgnp(mason, p3212, ognp1, streamOfOgnp1);
            test.StudentRegistersOgnp(leo, k3232, ognp1, streamOfOgnp1);
            test.StudentRegistersOgnp(ronaldo, r3202, ognp1, streamOfOgnp1);
            test.StudentRegistersOgnp(nam, m3212, ognp1, streamOfOgnp2);

            List<Student> listOGNP1 = test.GetStudentsOfOgnp(ognp1);
            Assert.AreEqual(listOGNP1.Count, 5);
        }

        [Test]
        public void GetStudentsDidNotRegisterOgnp()
        {
            //// create students
            var kiet = new Student("Kiet", "M3212");
            var nam = new Student("Nam", "M3212");
            var kien = new Student("Kien", "M3212");
            var ronaldo = new Student("Ronaldo", "R3202");

            var schedule1 = new Schedule();
            var pair1 = new Pair(1, 2);
            schedule1.Addpair(pair1, DayOfWeek.Monday);
            var m3212 = new GroupWrapper("M3212", schedule1);
            m3212.StudentsList.Add(kiet);
            m3212.StudentsList.Add(nam);
            m3212.StudentsList.Add(kien);

            var schedule2 = new Schedule();
            var pair2 = new Pair(1, 2);
            schedule2.Addpair(pair2, DayOfWeek.Tuesday);
            var r3202 = new GroupWrapper("R3202", schedule2);
            r3202.StudentsList.Add(ronaldo);

            //// create ognp1
            var ognp1 = new Ognp("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, DayOfWeek.Tuesday);
            scheduleOGNP1.Addpair(pair2OGNP, DayOfWeek.Tuesday);

            //// add potok1
            var streamOfOgnp1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.StreamsOfOgnp.Add(streamOfOgnp1);

            var scheduleOGNP2 = new Schedule();

            var lecturer2 = new Lecturer("Alina");
            var pair1OGNP2 = new Pair(4, 5);
            var pair2OGNP2 = new Pair(6, 7);
            scheduleOGNP2.Addpair(pair1OGNP2, DayOfWeek.Monday);
            scheduleOGNP2.Addpair(pair2OGNP2, DayOfWeek.Monday);

            //// add potok2
            var streamOfOgnp2 = new Stream(scheduleOGNP1, lecturer2);
            ognp1.StreamsOfOgnp.Add(streamOfOgnp2);

            var test = new OgnpManagement();
            test.AddNewOgnp(ognp1);
            test.StudentRegistersOgnp(kiet, m3212, ognp1, streamOfOgnp1);
            test.StudentRegistersOgnp(ronaldo, r3202, ognp1, streamOfOgnp1);
            test.StudentRegistersOgnp(nam, m3212, ognp1, streamOfOgnp2);

            List<Student> listnotOGNP1 = test.GetStudentsDidNotRegister(m3212);
            Assert.AreEqual(listnotOGNP1.Count, 1);
        }
    }
}