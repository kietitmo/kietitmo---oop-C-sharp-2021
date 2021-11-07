using System;
using Banks.Exceptions;

namespace Banks.ClientClass
{
    public class PassportData
    {
        public PassportData()
        {
            IssueDate = DateTime.Now;
            Series = "---";
            Number = "000000";
        }

        public PassportData(DateTime issueDate, string series, string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsLetter(number[i]))
                    throw new BankException("IvalidPassportNumberException");
            }

            IssueDate = issueDate;
            Series = series;
            Number = number;
        }

        public DateTime IssueDate { get; }
        public string Series { get; }
        public string Number { get; }
    }
}
