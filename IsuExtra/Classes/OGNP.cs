using System.Collections.Generic;
using Isu.Tools;

namespace IsuExtra.Classes
{
    public class Ognp
    {
        private string _ognpName;
        private Faculty _ofFaculty;
        private List<Stream> _streamsOgnp;

        public Ognp(string ognpName, char facultyOfOgnp)
        {
            if (string.IsNullOrEmpty(ognpName))
            {
                throw new IsuException("OGNP Name Invalid Exception");
            }

            OgnpName = ognpName;
            OfFaculty = new Faculty(facultyOfOgnp);
            StreamsOfOgnp = new List<Stream>();
        }

        public List<Stream> StreamsOfOgnp { get => _streamsOgnp; set => _streamsOgnp = value; }
        public Faculty OfFaculty { get => _ofFaculty; set => _ofFaculty = value; }
        public string OgnpName { get => _ognpName; set => _ognpName = value; }
    }
}
