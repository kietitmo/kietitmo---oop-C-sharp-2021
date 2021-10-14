using System.Collections.Generic;
using Isu.Tools;

namespace IsuExtra.Classes
{
    public class OGNP
    {
        private string _ognpName;
        private char _ofFaculty;
        private List<Stream> _streamOGNP;

        public OGNP(string ognpName, char facultyOfOGNP)
        {
            OgnpName = ognpName;
            OfFaculty = facultyOfOGNP;
            StreamOfOGNP = new List<Stream>();
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

        public List<Stream> StreamOfOGNP { get => _streamOGNP; set => _streamOGNP = value; }
        public char OfFaculty { get => _ofFaculty; set => _ofFaculty = value; }
    }
}
