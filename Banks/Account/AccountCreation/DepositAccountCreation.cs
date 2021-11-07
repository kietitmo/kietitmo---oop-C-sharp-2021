using Banks.BankClass;
using Banks.ClientClass;

namespace Banks.Account.AccountCreation
{
    public class DepositAccountCreation : IAccountCreation
    {
        public IAccount CreateAccount(Bank bank, Client client, double balance = 0)
        {
            var account = new DepositAcount(bank.Persentage, balance);
            account.Owner = client;
            return account;
        }
    }
}
