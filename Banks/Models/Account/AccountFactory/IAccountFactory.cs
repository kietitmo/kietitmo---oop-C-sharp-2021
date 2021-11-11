using Banks.Models.BankClass;
using Banks.Models.ClientClass;
using Banks.Timer;

namespace Banks.Models.Account.AccountFactory
{
    public interface IAccountFactory
    {
        public IAccount CreateAccount(Bank bank, Client client, double balance, TimeMachine timeMachine);
    }
}
