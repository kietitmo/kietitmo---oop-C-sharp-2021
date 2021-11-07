using Banks.BankClass;
using Banks.ClientClass;

namespace Banks.Account.AccountCreation
{
    public class DebitAccountCreation : IAccountCreation
    {
        public IAccount CreateAccount(Bank bank, Client client, double balance = 0)
        {
            var account = new DebitAcount(bank.Persentage, balance);
            account.Owner = client;
            return account;
        }
    }
}
