using Banks.Models.BankClass;
using Banks.Models.ClientClass;
using Banks.Timer;

namespace Banks.Models.Account.AccountFactory
{
    public class CreditAccountCreation : IAccountFactory
    {
        public IAccount CreateAccount(Bank bank, Client client, double balance, TimeMachine timeMachine)
        {
            var account = new CreditAcount(bank.Commission, bank.Commission, balance, timeMachine);
            account.Owner = client;
            account.IdBank = bank.Id;
            return account;
        }
    }
}
