using System;
using Banks.Exceptions;
using Banks.Models.Account;

namespace Banks.Models.BankClass
{
    public class Bank
    {
        public Bank(string name, Commission commission, Persentage persentage, DebtLimit debtLimit, double maxSumIfDoubtful)
        {
            if (string.IsNullOrEmpty(name) || double.IsNegative(commission.ValueCommission) || double.IsNegative(persentage.LowPersentage) || double.IsNegative(persentage.MediumPersentage) || double.IsNegative(persentage.HighPersentage) || double.IsNegative(debtLimit.ValueDebtLimit))
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
        public Commission Commission { get; set; }
        public DebtLimit DebtLimit { get; set; }
        public double MaxSumIfDoubtful { get; set; }
        public Persentage Persentage { get; set; }
    }
}
