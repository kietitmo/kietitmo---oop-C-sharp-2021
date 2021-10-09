using System.Collections.Generic;
using Isu.Tools;

namespace IsuExtra.Classes
{
    public class OGNP
    {
        private string _ognpName;
        private char _ofFaculty;
        private List<Potok> _potokOGNP;

        public OGNP(string ognpName, char facultyOfOGNP)
        {
            OgnpName = ognpName;
            OfFaculty = facultyOfOGNP;
            PotokOGNP = new List<Potok>();
        }

        public string OgnpName
        {
            get
            {
                return _ognpName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IsuException("OGNP Name Invalid Exception");
                }

                _ognpName = value;
            }
        }

        public List<Potok> PotokOGNP { get => _potokOGNP; set => _potokOGNP = value; }
        public char OfFaculty { get => _ofFaculty; set => _ofFaculty = value; }
    }
}
