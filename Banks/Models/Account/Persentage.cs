namespace Banks.Models.Account
{
    public class Persentage
    {
        public Persentage(double lowPersentage, double mediumPersentage, double highPersentage)
        {
            LowPersentage = lowPersentage;
            MediumPersentage = mediumPersentage;
            HighPersentage = highPersentage;
        }

        public double LowPersentage { get; set; }
        public double MediumPersentage { get; set; }
        public double HighPersentage { get; set; }

        public double SumWithLowPersentage { get; set; }
        public double SumWithMediumPersentage { get; set; }
    }
}
