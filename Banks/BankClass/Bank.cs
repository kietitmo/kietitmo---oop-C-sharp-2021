using System;
using Banks.Exceptions;

namespace Banks.BankClass
{
    public class Bank
    {
        public Bank(string name, double commission, double persentage, double debtLimit)
        {
            if (string.IsNullOrEmpty(name) || double.IsNegative(commission) || double.IsNegative(persentage) || double.IsNegative(debtLimit))
                throw new BankException("NotImplementedException");

            Name = name;
            Commission = commission;
            Persentage = persentage;
            DebtLimit = debtLimit;
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }
        public Guid Id { get; set; }
        public double Commission { get; set; }
        public double DebtLimit { get; set; }
        public double Persentage { get; set; }
    }
}
