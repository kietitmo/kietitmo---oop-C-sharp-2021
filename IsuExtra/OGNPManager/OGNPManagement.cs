using System.Collections.Generic;
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
        public OGNP AddNewOGNP(string ognpName, char ofFaculty)
        {
            var tempOGNP = new OGNP(ognpName, ofFaculty);
            return tempOGNP;
        }

        public void StudentRegistersOGNP(StudentWrapper student, OGNP ognp)
        {
            if (student.FacultyOfStudent == ognp.OfFaculty)
            {
                throw new IsuException("Register OGNP Of Student's Faculty Exception");
            }
        }
    }
}
