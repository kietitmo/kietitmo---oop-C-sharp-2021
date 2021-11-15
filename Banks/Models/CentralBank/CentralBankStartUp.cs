using System;
using Banks.Repositories;
using Banks.Services;
using Banks.Timer;

namespace Banks.Models.CentralBank
{
    public class CentralBankStartUp
    {
        private static BankRepository _bankRepository = new BankRepository();
        private static AccountRepository _accountRepository = new AccountRepository();
        private static ClientRepository _clientReposutory = new ClientRepository();
        private static TransactionRepository _transactionRepository = new TransactionRepository();

        private static BankServices _bankServices = new BankServices(_bankRepository);
        private static AccountServices _accountServices = new AccountServices(_accountRepository);
        private static ClientServices _clientServices = new ClientServices(_clientReposutory);
        private static TransactionServices _transactionServices = new TransactionServices(_transactionRepository);

        private static DateTime _date = DateTime.Today;
        private TimeMachine _timeMachine = new TimeMachine(_date);
        public CentralBankStartUp()
        {
            CentralBank = new Models.CentralBank.CentralBank(_bankServices, _accountServices, _clientServices, _transactionServices, _timeMachine);
        }

        public CentralBank CentralBank { get; set; }
        public CentralBank GetCentralBank() => CentralBank;
    }
}
