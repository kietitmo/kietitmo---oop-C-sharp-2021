using System;
using Banks.Account;
using Banks.Account.AccountCreation;
using Banks.BankClass;
using Banks.BankTransactions;
using Banks.ClientClass;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            var centralBank = new CentralBank.CentralBank();
            Bank sber = centralBank.CreateBank("Sber", 10, 12, 1000);
            Client kiet = centralBank.CreateClient("kiet", "nguyen");
            IAccount creditAccKiet = centralBank.CreateAccount(sber, kiet, 2000, TypeAccount.Credit);

            Client nam = centralBank.CreateClient("nam", "tran");
            IAccount debitAccNam = centralBank.CreateAccount(sber, nam, 2000, TypeAccount.Debit);
            Console.WriteLine(creditAccKiet.Balance);
            Console.WriteLine(debitAccNam.Balance);
            Console.WriteLine("============================================");
            IBankTransactions transaction = centralBank.Transfer(creditAccKiet, debitAccNam, 222);
            Console.WriteLine(creditAccKiet.Balance);
            Console.WriteLine(debitAccNam.Balance);

            Console.WriteLine("============================================");
            centralBank.Replenish(creditAccKiet, 1000);
            Console.WriteLine(creditAccKiet.Balance);
            Console.WriteLine(debitAccNam.Balance);

            Console.WriteLine("============================================");
            centralBank.CancelTransaction(transaction);
            Console.WriteLine(creditAccKiet.Balance);
            Console.WriteLine(debitAccNam.Balance);

            Console.WriteLine("============================================");
        }
    }
}
