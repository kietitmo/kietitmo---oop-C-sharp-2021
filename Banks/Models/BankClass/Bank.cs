using System;
using Banks.Exceptions;
using Banks.Models.Account;

namespace Banks.Models.BankClass
{
    public class Bank
    {
        public Bank(string name, double commission, Persentage persentage, double debtLimit, double maxSumIfDoubtful)
        {
            if (string.IsNullOrEmpty(name) || double.IsNegative(commission) || double.IsNegative(persentage.LowPersentage) || double.IsNegative(persentage.MediumPersentage) || double.IsNegative(persentage.HighPersentage) || double.IsNegative(debtLimit))
                throw new BankException("NotImplementedException");

            Name = name;
            Commission = commission;
            Persentage = persentage;
            DebtLimit = debtLimit;
            MaxSumIfDoubtful = maxSumIfDoubtful;
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }
        public Guid Id { get; set; }
        public double Commission { get; set; }
        public double DebtLimit { get; set; }
        public double MaxSumIfDoubtful { get; set; }
        public Persentage Persentage { get; set; }
    }
}
