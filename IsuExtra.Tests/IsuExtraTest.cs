﻿using System.Collections.Generic;
using IsuExtra.OGNPManager;
using IsuExtra.Classes;
using Isu.Classes;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        public OGNPManagement ognpTest;
         [SetUp]
        public void Setup()
        {
            ognpTest = new OGNPManagement();

            
        }

        [Test]
        public void AddNewOGNP()
        {
            var ognp1 = new OGNP("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            //// Create first Potok of OGNP
            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, "tuesday");
            scheduleOGNP1.Addpair(pair2OGNP, "tuesday");
            var potokOGNP1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.PotokOGNP.Add(potokOGNP1);

            //// Create second Potok of OGNP
            var scheduleOGNP2 = new Schedule();
            var lecturer2 = new Lecturer("Alina");
            var pair1OGNP2 = new Pair(4, 5);
            var pair2OGNP2 = new Pair(6, 7);
            scheduleOGNP2.Addpair(pair1OGNP2, "monday");
            scheduleOGNP2.Addpair(pair2OGNP2, "monday");
            var potokOGNP2 = new Stream(scheduleOGNP1, lecturer2);
            ognp1.PotokOGNP.Add(potokOGNP2);

            //// add ognp 1
            ognpTest.AddNewOGNP(ognp1);
            Assert.AreEqual(ognpTest.OgnpList.Count, 1);
        }

        [Test]
        public void StudentRegisterOGNP()
        {
            var kiet = new Student("Kiet", "M3212");

            var schedule1 = new Schedule();
            var pair1 = new Pair(1, 2);
            schedule1.Addpair(pair1, "monday");
            var m3212 = new GroupWrapper("M3212", schedule1);
            m3212.StudentsList.Add(kiet);

            var ognp1 = new OGNP("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            //// Create first Potok of OGNP
            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, "tuesday");
            scheduleOGNP1.Addpair(pair2OGNP, "tuesday");
            var potokOGNP1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.PotokOGNP.Add(potokOGNP1);

            //// Students Register OGNP
            ognpTest.AddNewOGNP(ognp1);
            ognpTest.StudentRegistersOGNP(kiet, m3212, ognp1, potokOGNP1);
            List<Student> sutdentList = ognpTest.GetStudentsOfOGNP(ognp1);
            Assert.AreEqual(sutdentList.Count, 1);
        }

        [Test]
        public void StudentUnregisterOGNP()
        {
            var kiet = new Student("Kiet", "M3212");

            var schedule1 = new Schedule();
            var pair1 = new Pair(1, 2);
            schedule1.Addpair(pair1, "monday");
            var m3212 = new GroupWrapper("M3212", schedule1);
            m3212.StudentsList.Add(kiet);

            var ognp1 = new OGNP("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            //// Create first Potok of OGNP
            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, "tuesday");
            scheduleOGNP1.Addpair(pair2OGNP, "tuesday");
            var potokOGNP1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.PotokOGNP.Add(potokOGNP1);

            //// Students Register OGNP
            ognpTest.AddNewOGNP(ognp1);
            ognpTest.StudentRegistersOGNP(kiet, m3212, ognp1, potokOGNP1);

            //// Student Unregister OGNP
            ognpTest.DeleteRegistration(kiet, potokOGNP1);
            List<Student> sutdentList = ognpTest.GetStudentsOfOGNP(ognp1);
            Assert.AreEqual(sutdentList.Count, 0);
        }

        [Test]
        public void GetPotoksFromOGNP()
        {
            var kiet = new Student("Kiet", "M3212");
            var nam = new Student("Nam", "M3212");
            var ronaldo = new Student("Ronaldo", "R3202");

            var schedule1 = new Schedule();
            var pair1 = new Pair(1, 2);
            schedule1.Addpair(pair1, "monday");
            var m3212 = new GroupWrapper("M3212", schedule1);
            m3212.StudentsList.Add(kiet);
            m3212.StudentsList.Add(nam);

            var schedule2 = new Schedule();
            var pair2 = new Pair(1, 2);
            schedule2.Addpair(pair2, "tuesday");
            var r3202 = new GroupWrapper("R3202", schedule2);
            r3202.StudentsList.Add(ronaldo);

            var ognp1 = new OGNP("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            //// Create first Potok of OGNP
            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, "tuesday");
            scheduleOGNP1.Addpair(pair2OGNP, "tuesday");
            var potokOGNP1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.PotokOGNP.Add(potokOGNP1);

            //// Create second Potok of OGNP
            var scheduleOGNP2 = new Schedule();
            var lecturer2 = new Lecturer("Alina");
            var pair1OGNP2 = new Pair(4, 5);
            var pair2OGNP2 = new Pair(6, 7);
            scheduleOGNP2.Addpair(pair1OGNP2, "monday");
            scheduleOGNP2.Addpair(pair2OGNP2, "monday");
            var potokOGNP2 = new Stream(scheduleOGNP1, lecturer2);
            ognp1.PotokOGNP.Add(potokOGNP2);

            //// Students Register OGNP
            ognpTest.AddNewOGNP(ognp1);
            ognpTest.StudentRegistersOGNP(kiet, m3212, ognp1, potokOGNP1);
            ognpTest.StudentRegistersOGNP(ronaldo, r3202, ognp1, potokOGNP1);
            ognpTest.StudentRegistersOGNP(nam, m3212, ognp1, potokOGNP2);

            //// get Potoks
            List<Stream> potoksOfOgnp1 = ognpTest.GetPotokOfOGNP(ognp1);
            Assert.AreEqual(2, potoksOfOgnp1.Count);
        }

        [Test]
        public void GetStudentsFromOGNP()
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
            schedule1.Addpair(pair1, "monday");
            var m3212 = new GroupWrapper("M3212", schedule1);
            m3212.StudentsList.Add(kiet);
            m3212.StudentsList.Add(nam);
            m3212.StudentsList.Add(kien);

            var schedule2 = new Schedule();
            var pair2 = new Pair(1, 2);
            schedule2.Addpair(pair2, "tuesday");
            var r3202 = new GroupWrapper("R3202", schedule2);
            r3202.StudentsList.Add(ronaldo);

            var schedule3 = new Schedule();
            var pair3 = new Pair(4, 5);
            schedule3.Addpair(pair3, "wednesday");
            var k3232 = new GroupWrapper("K3232", schedule3);
            k3232.StudentsList.Add(leo);

            var schedule4 = new Schedule();
            var pair4 = new Pair(4, 5);
            schedule2.Addpair(pair4, "thursday");
            var p3212 = new GroupWrapper("P3212", schedule4);
            p3212.StudentsList.Add(mason);

            //// create ognp1
            var ognp1 = new OGNP("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, "tuesday");
            scheduleOGNP1.Addpair(pair2OGNP, "tuesday");

            //// add potok1
            var potokOGNP1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.PotokOGNP.Add(potokOGNP1);

            var scheduleOGNP2 = new Schedule();

            var lecturer2 = new Lecturer("Alina");
            var pair1OGNP2 = new Pair(4, 5);
            var pair2OGNP2 = new Pair(6, 7);
            scheduleOGNP2.Addpair(pair1OGNP2, "monday");
            scheduleOGNP2.Addpair(pair2OGNP2, "monday");

            //// add potok2
            var potokOGNP2 = new Stream(scheduleOGNP1, lecturer2);
            ognp1.PotokOGNP.Add(potokOGNP2);

            var test = new OGNPManagement();
            test.AddNewOGNP(ognp1);

            //// 5 Students register ognp1
            test.StudentRegistersOGNP(kiet, m3212, ognp1, potokOGNP1);
            test.StudentRegistersOGNP(mason, p3212, ognp1, potokOGNP1);
            test.StudentRegistersOGNP(leo, k3232, ognp1, potokOGNP1);
            test.StudentRegistersOGNP(ronaldo, r3202, ognp1, potokOGNP1);
            test.StudentRegistersOGNP(nam, m3212, ognp1, potokOGNP2);

            List<Student> listOGNP1 = test.GetStudentsOfOGNP(ognp1);
            Assert.AreEqual(listOGNP1.Count, 5);
        }

        [Test]
        public void GetStudentsDidNotRegisterOGNP()
        {
            //// create students
            var kiet = new Student("Kiet", "M3212");
            var nam = new Student("Nam", "M3212");
            var kien = new Student("Kien", "M3212");
            var ronaldo = new Student("Ronaldo", "R3202");

            var schedule1 = new Schedule();
            var pair1 = new Pair(1, 2);
            schedule1.Addpair(pair1, "monday");
            var m3212 = new GroupWrapper("M3212", schedule1);
            m3212.StudentsList.Add(kiet);
            m3212.StudentsList.Add(nam);
            m3212.StudentsList.Add(kien);

            var schedule2 = new Schedule();
            var pair2 = new Pair(1, 2);
            schedule2.Addpair(pair2, "tuesday");
            var r3202 = new GroupWrapper("R3202", schedule2);
            r3202.StudentsList.Add(ronaldo);

            //// create ognp1
            var ognp1 = new OGNP("mon1", 'Z');
            var scheduleOGNP1 = new Schedule();

            var lecturer = new Lecturer("Povyshev");
            var pair1OGNP = new Pair(4, 5);
            var pair2OGNP = new Pair(6, 7);
            scheduleOGNP1.Addpair(pair1OGNP, "tuesday");
            scheduleOGNP1.Addpair(pair2OGNP, "tuesday");

            //// add potok1
            var potokOGNP1 = new Stream(scheduleOGNP1, lecturer);
            ognp1.StreamOfOGNP.Add(potokOGNP1);

            var scheduleOGNP2 = new Schedule();

            var lecturer2 = new Lecturer("Alina");
            var pair1OGNP2 = new Pair(4, 5);
            var pair2OGNP2 = new Pair(6, 7);
            scheduleOGNP2.Addpair(pair1OGNP2, "monday");
            scheduleOGNP2.Addpair(pair2OGNP2, "monday");

            //// add potok2
            var potokOGNP2 = new Stream(scheduleOGNP1, lecturer2);
            ognp1.StreamOfOGNP.Add(potokOGNP2);

            var test = new OGNPManagement();
            test.AddNewOGNP(ognp1);
            test.StudentRegistersOGNP(kiet, m3212, ognp1, potokOGNP1);
            test.StudentRegistersOGNP(ronaldo, r3202, ognp1, potokOGNP1);
            test.StudentRegistersOGNP(nam, m3212, ognp1, potokOGNP2);

            List<Student> listnotOGNP1 = test.GetStudentsDidNotRegister(m3212);
            Assert.AreEqual(listnotOGNP1.Count, 1);
        }
    }
}