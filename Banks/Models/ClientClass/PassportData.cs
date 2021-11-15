using Banks.Exceptions;

namespace Banks.Models.ClientClass
{
    public class PassportData
    {
        public PassportData()
        {
            Series = "---";
            Number = "000000";
        }

        public PassportData(string series, string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsLetter(number[i]))
                    throw new BankException("IvalidPassportNumberException");
            }

            Series = series;
            Number = number;
        }

        public string Series { get; }
        public string Number { get; }
    }
}
