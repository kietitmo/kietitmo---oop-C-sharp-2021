using System;
using Banks.Exceptions;
using Banks.Models.Account;
using Banks.Models.Account.AccountFactory;
using Banks.Models.BankClass;
using Banks.Models.BankTransactions;
using Banks.Models.ClientClass;
using Banks.Services;
using Banks.Timer;

namespace Banks.Models.CentralBank
{
    public class CentralBank
    {
        public CentralBank(BankServices bankServices, AccountServices accountServices, ClientServices clientServices, TransactionServices transactionServices, TimeMachine timeMachine)
        {
            BankServices = bankServices;
            AccountServices = accountServices;
            TransactionServices = transactionServices;
            ClientServices = clientServices;
            TimeMachine = timeMachine;
        }

        public TimeMachine TimeMachine { get; set; }
        public BankServices BankServices { get; set; }
        public AccountServices AccountServices { get; set; }
        public ClientServices ClientServices { get; set; }
        public TransactionServices TransactionServices { get; set; }

        public Bank CreateBank(string name, double commission, Persentage persentage, double debtLimit, double maxSumIfDoubtful)
        {
            var bank = new Bank(name, commission, persentage, debtLimit, maxSumIfDoubtful);
            BankServices.AddBank(bank);
            return bank;
        }

        public Client CreateClient(string name, string surname)
        {
            Client client = new ClientBuilder().SetName(name).SetSurname(surname).Build();
            ClientServices.AddClient(client);
            return client;
        }

        public Client CreateClient(string name, string surname, PassportData passportData, string address)
        {
            Client client = new ClientBuilder().SetName(name).SetSurname(surname).SetPassport(passportData).SetAddress(address).Build();
            ClientServices.AddClient(client);
            return client;
        }

        public Guid GetAccountId(string firstName, string surname, string bank)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(firstName, surname);
            Guid bankId = BankServices.GetBankIdbyName(bank);
            Guid accountId = AccountServices.GetId(clientId, bankId);
            return accountId;
        }

        public void UpdatePassportData(string nameClient, string surname, PassportData passportData)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(nameClient, surname);
            Client client = ClientServices.GetClientById(clientId);
            client.PassportData = passportData;
        }

        public void UpdateAdress(string nameClient, string surname, string address)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(nameClient, surname);
            Client client = ClientServices.GetClientById(clientId);
            client.Address = address;
        }

        public void SetComission(string bankName, double newCommission)
        {
            Bank bank = BankServices.GetBankByName(bankName);
            bank.Commission = newCommission;
            AccountServices.AddNotification(AccountServices.GetListKindOfAccount(TypeAccount.Credit), "Commission is changed to " + newCommission);
            ////add notification to credit
        }

        public void SetPersentage(string bankName, Persentage newPersentage)
        {
            Bank bank = BankServices.GetBankByName(bankName);
            bank.Persentage = newPersentage;

            AccountServices.AddNotification(AccountServices.GetListKindOfAccount(TypeAccount.Debit), "Persentage is changed!");
            AccountServices.AddNotification(AccountServices.GetListKindOfAccount(TypeAccount.Deposit), "Persentage is changed!");
            //// add notification to deposit debit
        }

        public void SetDebtLimit(string bankName, double newDebtLimit)
        {
            Bank bank = BankServices.GetBankByName(bankName);
            bank.DebtLimit = newDebtLimit;
            AccountServices.AddNotification(AccountServices.GetListKindOfAccount(TypeAccount.Credit), "Debt limit is changed to " + newDebtLimit);
            ////add notification to credit
        }

        public void SetPeriodOfDepositAccount(string firstName, string surname, string bank, int period)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(firstName, surname);
            Guid bankId = BankServices.GetBankIdbyName(bank);
            Guid accountId = AccountServices.GetId(clientId, bankId);
            IAccount account = AccountServices.GetAccountById(accountId);

            if (account.TypeAccount == TypeAccount.Deposit)
            {
                (account as DepositAcount).Period = period;
            }
        }

        public void CreateAccount(string bankName, string nameClient, string surname, double balance, TypeAccount typeAccount)
        {
            IAccountFactory accountFactory;

            switch (typeAccount)
            {
                case TypeAccount.Credit:
                    accountFactory = new CreditAccountCreation();
                    break;

                case TypeAccount.Debit:
                    accountFactory = new DebitAccountCreation();
                    break;

                case TypeAccount.Deposit:
                    accountFactory = new DepositAccountCreation();
                    break;

                default:
                    accountFactory = new CreditAccountCreation();
                    break;
            }

            Bank bank = BankServices.GetBankByName(bankName);
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(nameClient, surname);
            Client client = ClientServices.GetClientById(clientId);

            IAccount account = accountFactory.CreateAccount(bank, client, balance, TimeMachine);
            account.TypeAccount = typeAccount;
            AccountServices.AddAccount(account);
        }

        public IBankTransactions WithDraw(string firstName, string surname, string bank, double sum)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(firstName, surname);
            Guid bankId = BankServices.GetBankIdbyName(bank);
            Guid accountId = AccountServices.GetId(clientId, bankId);
            IAccount account = AccountServices.GetAccountById(accountId);

            if (!account.IsTransactionAvailable(sum))
            {
                throw new BankException("CannotTransactionException");
            }

            Client client = ClientServices.GetClientById(clientId);
            Bank bankOfClient = BankServices.GetBankbyId(bankId);
            WithDrawing withDrawOperation;

            if (!client.IsDoubtful() || sum < bankOfClient.MaxSumIfDoubtful)
            {
                withDrawOperation = new WithDrawing(account, sum);
                withDrawOperation.DoOperation();
                TransactionServices.AddTransaction(withDrawOperation);
                return withDrawOperation;
            }

            withDrawOperation = new WithDrawing(account, bankOfClient.MaxSumIfDoubtful);
            withDrawOperation.DoOperation();
            TransactionServices.AddTransaction(withDrawOperation);
            return withDrawOperation;
        }

        public IBankTransactions Replenish(string firstName, string surname, string bank, double sum)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(firstName, surname);
            Guid bankId = BankServices.GetBankIdbyName(bank);
            Guid accountId = AccountServices.GetId(clientId, bankId);
            IAccount account = AccountServices.GetAccountById(accountId);

            if (!account.IsTransactionAvailable(sum))
            {
                throw new BankException("CannotTransactionException");
            }

            Client client = ClientServices.GetClientById(clientId);
            Bank bankOfClient = BankServices.GetBankbyId(bankId);
            Replenishing withDrawOperation;

            if (!client.IsDoubtful() || sum < bankOfClient.MaxSumIfDoubtful)
            {
                withDrawOperation = new Replenishing(account, sum);
                withDrawOperation.DoOperation();
                TransactionServices.AddTransaction(withDrawOperation);
                return withDrawOperation;
            }

            withDrawOperation = new Replenishing(account, bankOfClient.MaxSumIfDoubtful);
            withDrawOperation.DoOperation();
            TransactionServices.AddTransaction(withDrawOperation);
            return withDrawOperation;
        }

        public IBankTransactions Transfer(string fromFirstName, string fromSurname, string fromBank, string toFirstName, string toSurname, string toBank, double sum)
        {
            //// Define source account
            Guid fromClientId = ClientServices.GetClientIdByNameAndSurname(fromFirstName, fromSurname);
            Guid fromBankId = BankServices.GetBankIdbyName(fromBank);
            Guid fromAccountId = AccountServices.GetId(fromClientId, fromBankId);
            IAccount fromAccount = AccountServices.GetAccountById(fromAccountId);

            //// define target account
            Guid toClientId = ClientServices.GetClientIdByNameAndSurname(toFirstName, toSurname);
            Guid toBankId = BankServices.GetBankIdbyName(toBank);
            Guid toAccountId = AccountServices.GetId(toClientId, toBankId);
            IAccount toAccount = AccountServices.GetAccountById(toAccountId);

            if (!fromAccount.IsTransactionAvailable(sum))
            {
                throw new BankException("CannotTransactionException");
            }

            Client clientSource = ClientServices.GetClientById(fromClientId);
            Bank bankOfClientSource = BankServices.GetBankbyId(fromBankId);
            Transfering transferOperation;

            if (!clientSource.IsDoubtful() || sum < bankOfClientSource.MaxSumIfDoubtful)
            {
                transferOperation = new Transfering(fromAccount, toAccount, sum);
                transferOperation.DoOperation();
                TransactionServices.AddTransaction(transferOperation);
                return transferOperation;
            }

            transferOperation = new Transfering(fromAccount, toAccount, bankOfClientSource.MaxSumIfDoubtful);
            transferOperation.DoOperation();
            TransactionServices.AddTransaction(transferOperation);
            return transferOperation;
        }

        public double GetBalance(string bank, string firstName, string surname)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(firstName, surname);
            Guid bankId = BankServices.GetBankIdbyName(bank);
            Guid accountId = AccountServices.GetId(clientId, bankId);
            IAccount account = AccountServices.GetAccountById(accountId);
            account.UpdateBalance(TimeMachine.Date);
            return account.Balance;
        }

        public void CancelTransaction(Guid banktransactionID)
        {
            IBankTransactions banktransaction = TransactionServices.GetTransactions(banktransactionID);
            banktransaction.UndoOperation();
            TransactionServices.RemoveTransactions(banktransaction);
        }

        public int GetQuantityAccount()
        {
            return AccountServices.GetQuantityAccount();
        }

        public void BackToTheFuture(int quantityDay)
        {
            TimeMachine.AddSomeDays(quantityDay);
        }

        public void UpdateBalanceOfAllAccount()
        {
            AccountServices.UpdateBalanceOfAllAccount(TimeMachine.Date);
        }
    }
}
