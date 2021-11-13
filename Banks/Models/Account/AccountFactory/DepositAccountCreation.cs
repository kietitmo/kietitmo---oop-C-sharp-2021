using Banks.Models.BankClass;
using Banks.Models.ClientClass;
using Banks.Timer;

namespace Banks.Models.Account.AccountFactory
{
    public class DepositAccountCreation : IAccountFactory
    {
        public IAccount CreateAccount(Bank bank, Client client, double balance, TimeMachine timeMachine)
        {
            var account = new DepositAcount(bank.Persentage, balance, timeMachine);
            client.TypeAccountClientHave.Add(TypeAccount.Deposit);
            account.Owner = client;
            account.IdBank = bank.Id;
            return account;
        }
    }
}
