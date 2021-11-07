using Banks.BankClass;
using Banks.ClientClass;
namespace Banks.Account.AccountCreation
{
    public class CreditAccountCreation : IAccountCreation
    {
        public IAccount CreateAccount(Bank bank, Client client, double balance = 0)
        {
            var account = new CreditAcount(bank.Commission, bank.Commission, balance);
            account.Owner = client;
            return account;
        }
    }
}
