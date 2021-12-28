using System;
using System.Collections.Generic;
using Banks.Exceptions;
using Banks.Models.Account;
using Banks.Models.Account.AccountFactory;
using Banks.Models.BankClass;
using Banks.Models.BankTransactions;
using Banks.Models.ClientClass;
using Banks.Models.Notification;
using Banks.Observer;
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

        public Bank CreateBank(string name, Commission commission, Persentage persentage, DebtLimit debtLimit, double maxSumIfDoubtful)
        {
            var bank = new Bank(name, commission, persentage, debtLimit, maxSumIfDoubtful);
            BankServices.AddBank(bank);
            return bank;
        }

        public Client CreateClient(string name, string surname, Phone phone)
        {
            Client client = new ClientBuilder().SetName(name).SetSurname(surname).SetPhone(phone).Build();
            ClientServices.AddClient(client);
            return client;
        }

        public Client CreateClient(string name, string surname,  Phone phone, PassportData passportData, string address)
        {
            Client client = new ClientBuilder().SetName(name).SetSurname(surname).SetPhone(phone).SetPassport(passportData).SetAddress(address).Build();
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

        public void SetComission(string bankName, double newCommissionValue)
        {
            Bank bank = BankServices.GetBankByName(bankName);
            bank.Commission.ValueCommission = newCommissionValue;
            bank.Commission.AddObserver(new AccountNotifier(AccountServices.GetListKindOfAccount(TypeAccount.Credit)));
            bank.Commission.AddObserver(new PhoneNotifier(ClientServices.GetPhoneClientList(TypeAccount.Credit)));
            bank.Commission.ChangeCommission();
            ////AccountServices.AddNotifications(AccountServices.GetListKindOfAccount(TypeAccount.Credit), new CommissionChanged());
            ////add notification to credit
        }

        public void SetPersentage(string bankName, double lowPer, double mediumPer, double highPer)
        {
            Bank bank = BankServices.GetBankByName(bankName);
            bank.Persentage.LowPersentage = lowPer;
            bank.Persentage.MediumPersentage = mediumPer;
            bank.Persentage.HighPersentage = highPer;

            bank.Persentage.AddObserver(new AccountNotifier(AccountServices.GetListKindOfAccount(TypeAccount.Debit)));
            bank.Persentage.AddObserver(new AccountNotifier(AccountServices.GetListKindOfAccount(TypeAccount.Deposit)));
            bank.Persentage.AddObserver(new PhoneNotifier(ClientServices.GetPhoneClientList(TypeAccount.Debit)));
            bank.Persentage.AddObserver(new PhoneNotifier(ClientServices.GetPhoneClientList(TypeAccount.Deposit)));
            bank.Persentage.ChangePercentage();

            ////AccountServices.AddNotifications(AccountServices.GetListKindOfAccount(TypeAccount.Debit), new PercentageChanged());
            ////AccountServices.AddNotifications(AccountServices.GetListKindOfAccount(TypeAccount.Deposit), new PercentageChanged());
            //// add notification to deposit debit
        }

        public void SetDebtLimit(string bankName, double newDebtLimitValue)
        {
            Bank bank = BankServices.GetBankByName(bankName);
            bank.DebtLimit.ValueDebtLimit = newDebtLimitValue;
            bank.DebtLimit.AddObserver(new AccountNotifier(AccountServices.GetListKindOfAccount(TypeAccount.Credit)));
            bank.DebtLimit.AddObserver(new PhoneNotifier(ClientServices.GetPhoneClientList(TypeAccount.Credit)));
            bank.DebtLimit.ChangeDebtLimit();
            ////AccountServices.AddNotifications(AccountServices.GetListKindOfAccount(TypeAccount.Credit), new DebtLimitChanged());
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
            AccountServices.AddNotificationForAccount(account, new AnotherNotificotion("Welcome to " + bank.Name));
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
                withDrawOperation = new WithDrawing(account, sum, TimeMachine.Date);
                withDrawOperation.DoOperation();
                TransactionServices.AddTransaction(withDrawOperation);
                return withDrawOperation;
            }

            withDrawOperation = new WithDrawing(account, bankOfClient.MaxSumIfDoubtful, TimeMachine.Date);
            withDrawOperation.DoOperation();
            TransactionServices.AddTransaction(withDrawOperation);
            AccountServices.AddNotificationForAccount(account, new ReducedBalance());
            return withDrawOperation;
        }

        public IBankTransactions Replenish(string firstName, string surname, string bank, double sum)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(firstName, surname);
            Guid bankId = BankServices.GetBankIdbyName(bank);
            Guid accountId = AccountServices.GetId(clientId, bankId);
            IAccount account = AccountServices.GetAccountById(accountId);

            Client client = ClientServices.GetClientById(clientId);
            Bank bankOfClient = BankServices.GetBankbyId(bankId);
            Replenishing replenishOperation;

            if (!client.IsDoubtful() || sum < bankOfClient.MaxSumIfDoubtful)
            {
                replenishOperation = new Replenishing(account, sum, TimeMachine.Date);
                replenishOperation.DoOperation();
                TransactionServices.AddTransaction(replenishOperation);
                return replenishOperation;
            }

            replenishOperation = new Replenishing(account, bankOfClient.MaxSumIfDoubtful, TimeMachine.Date);
            replenishOperation.DoOperation();
            TransactionServices.AddTransaction(replenishOperation);
            AccountServices.AddNotificationForAccount(account, new IncreasedBalance());
            return replenishOperation;
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
                transferOperation = new Transfering(fromAccount, toAccount, sum, TimeMachine.Date);
                transferOperation.DoOperation();
                TransactionServices.AddTransaction(transferOperation);
                AccountServices.AddNotificationForAccount(toAccount, new IncreasedBalance());
                AccountServices.AddNotificationForAccount(fromAccount, new ReducedBalance());
                return transferOperation;
            }

            transferOperation = new Transfering(fromAccount, toAccount, bankOfClientSource.MaxSumIfDoubtful, TimeMachine.Date);
            transferOperation.DoOperation();
            TransactionServices.AddTransaction(transferOperation);
            AccountServices.AddNotificationForAccount(toAccount, new IncreasedBalance());
            AccountServices.AddNotificationForAccount(fromAccount, new ReducedBalance());
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

        public void ShowAllNotificationOfAccount(string firstName, string surname, string bank)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(firstName, surname);
            Guid bankId = BankServices.GetBankIdbyName(bank);
            Guid accountId = AccountServices.GetId(clientId, bankId);
            IAccount account = AccountServices.GetAccountById(accountId);
            int count = 1;
            foreach (INotification notify in account.Notification)
            {
                Console.WriteLine(count + ". " + notify.ContentNotify);
                count++;
            }
        }

        public void ShowAllTransactionOfAccount(string firstName, string surname, string bank)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(firstName, surname);
            Guid bankId = BankServices.GetBankIdbyName(bank);
            Guid accountId = AccountServices.GetId(clientId, bankId);
            IEnumerable<IBankTransactions> transactionList = TransactionServices.GetAllTransactionOfAccount(accountId);
            int count = 1;
            foreach (IBankTransactions transaction in transactionList)
            {
                if (transaction is Transfering)
                {
                    Console.WriteLine(count + ". " + transaction.DateOfTrasnsaction + " Tranfering transaction");
                    count++;
                }

                if (transaction is WithDrawing)
                {
                    Console.WriteLine(count + ". " + transaction.DateOfTrasnsaction + " Withdrawing transaction");
                    count++;
                }

                if (transaction is Replenishing)
                {
                    Console.WriteLine(count + ". " + transaction.DateOfTrasnsaction + " Replenishing transaction");
                    count++;
                }
            }
        }

        public void CancelLastTransaction(string firstName, string surname, string bank)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(firstName, surname);
            Guid bankId = BankServices.GetBankIdbyName(bank);
            Guid accountId = AccountServices.GetId(clientId, bankId);
            TransactionServices.RemoveTransactions(TransactionServices.GetLastTransactionOfAccount(accountId));
        }

        public void ShowListAllBank()
        {
            IEnumerable<Bank> bankList = BankServices.GetEnumerator();
            int count = 1;
            foreach (Bank bank in bankList)
            {
                Console.WriteLine(count + ". " + bank.Name + ".");
                count++;
            }
        }

        public void ShowAllNotificationsViaPhoneOfClient(string firstName, string surname)
        {
            Guid clientId = ClientServices.GetClientIdByNameAndSurname(firstName, surname);
            Client client = ClientServices.GetClientById(clientId);
            int count = 1;
            foreach (INotification notification in client.PhoneClient.Notifications)
            {
                Console.WriteLine(count + ". " + notification.ContentNotify + ".");
                count++;
            }
        }
    }
}
