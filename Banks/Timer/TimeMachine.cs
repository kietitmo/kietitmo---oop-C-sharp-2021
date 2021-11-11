using System;

namespace Banks.Timer
{
    public class TimeMachine
    {
        public TimeMachine(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; set; }
        public void AddSomeDays(int quantityDay)
        {
            Date = Date.AddDays(quantityDay);
        }

        public void AddSomeMonths(int quantityMonths)
        {
            Date = Date.AddMonths(quantityMonths);
        }

        public void AddSomeYears(int quantityYear)
        {
            Date = Date.AddYears(quantityYear);
        }
    }
}
