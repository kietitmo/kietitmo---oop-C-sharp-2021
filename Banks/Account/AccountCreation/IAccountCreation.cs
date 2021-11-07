using Banks.BankClass;
using Banks.ClientClass;

namespace Banks.Account.AccountCreation
{
    public interface IAccountCreation
    {
        public IAccount CreateAccount(Bank bank, Client client, double balance = 0);
    }
}
