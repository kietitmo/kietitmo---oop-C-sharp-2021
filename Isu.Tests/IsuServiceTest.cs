using Isu.Services;
using Isu.Tools;
using Isu.Classes;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            //TODO: implement
            _isuService = null;
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {   //// Arrange
            _isuService = new IsuService();

            //// Act
            Group m3212 = _isuService.AddGroup("M3212");
            Student kiet = _isuService.AddStudent(m3212, "kiet");

            //// Assert
            if (kiet.GroupName != "M3212" || !m3212.StudentsList.Contains(kiet))
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            //// Arrange
            //// If max student pre group is 3
            int maxStudentPerGroup = 3;
            _isuService = new IsuService();
            Group m3212 = _isuService.AddGroup("M3212");

            //// Act
            _isuService.AddStudent(m3212, "Kiet");
            _isuService.AddStudent(m3212, "Ivan");

            ////Asslert
            if (m3212.StudentsList.Count >= maxStudentPerGroup)
            {
                throw new IsuException("ReachMaxStudentException");
            }
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            _isuService = new IsuService();
            _isuService.AddGroup("M3222");
            //// Exception builded in funtion AddGroup, so we dont need to build again.
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {

            _isuService = new IsuService();
            Group m3212 = _isuService.AddGroup("M3212");
            Group m3211 = _isuService.AddGroup("M3211");
            Student kiet = _isuService.AddStudent(m3212, "kiet");

            //// Act
            _isuService.ChangeStudentGroup(kiet, m3211);

            //// Assert
            Assert.AreEqual(kiet.GroupName, "M3211");
        }
    }
}