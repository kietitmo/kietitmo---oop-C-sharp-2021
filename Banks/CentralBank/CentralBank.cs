using Banks.Account;
using Banks.Account.AccountCreation;
using Banks.Account.AccountService;
using Banks.BankClass;
using Banks.BankTransactions;
using Banks.ClientClass;
using Banks.Exceptions;

namespace Banks.CentralBank
{
    public class CentralBank
    {
        public CentralBank()
        {
            BankServices = new BankServices();
            AccountService = new AccountService();
            TransactionServices = new TransactionServices();
        }

        public BankServices BankServices { get; set; }
        public AccountService AccountService { get; set; }
        public TransactionServices TransactionServices { get; set; }

        public Bank CreateBank(string name, double commission, double persentage, double debtLimit)
        {
            var bank = new Bank(name, commission, persentage, debtLimit);
            BankServices.AddBank(bank);
            return bank;
        }

        public Client CreateClient(string name, string surname)
        {
            var client = new Client(name, surname);
            return client;
        }

        public void UpdatePassportData(Client client, PassportData passportData)
        {
            client.PassportData = passportData;
        }

        public void UpdateAdress(Client client, string address)
        {
            client.Address = address;
        }

        public void SetComission(Bank bank, double newCommission)
        {
            bank.Commission = newCommission;
        }

        public void SetPersentage(Bank bank, double newPersentage)
        {
            bank.Persentage = newPersentage;
        }

        public IAccount CreateAccount(Bank bank, Client client, double balance, TypeAccount typeAccount)
        {
            IAccount account = null;
            IAccountCreation accountCreation;

            switch (typeAccount)
            {
                case TypeAccount.Credit:
                    accountCreation = new CreditAccountCreation();
                    account = accountCreation.CreateAccount(bank, client, balance);
                    break;
                case TypeAccount.Debit:
                    accountCreation = new DebitAccountCreation();
                    account = accountCreation.CreateAccount(bank, client, balance);
                    break;
                case TypeAccount.Deposit:
                    accountCreation = new DepositAccountCreation();
                    account = accountCreation.CreateAccount(bank, client, balance);
                    break;
            }

            AccountService.AddAccount(account);
            return account;
        }

        public IBankTransactions WithDraw(IAccount account, double sum)
        {
            if (!account.IsTransactionAvailable(sum))
            {
                throw new BankException("CannotTransactionException");
            }

            var withDrawOperation = new WithDrawing(account, sum);
            withDrawOperation.DoOperation();
            TransactionServices.AddTrans(withDrawOperation);
            return withDrawOperation;
        }

        public IBankTransactions Replenish(IAccount account, double sum)
        {
            if (!account.IsTransactionAvailable(sum))
            {
                throw new BankException("CannotTransactionException");
            }

            var replenishOperation = new Replenishing(account, sum);
            replenishOperation.DoOperation();
            TransactionServices.AddTrans(replenishOperation);
            return replenishOperation;
        }

        public IBankTransactions Transfer(IAccount fromAccount, IAccount toAccount, double sum)
        {
            if (!fromAccount.IsTransactionAvailable(sum))
            {
                throw new BankException("CannotTransactionException");
            }

            var transferOperation = new Transfering(fromAccount, toAccount, sum);
            transferOperation.DoOperation();
            TransactionServices.AddTrans(transferOperation);
            return transferOperation;
        }

        public void CancelTransaction(IBankTransactions banktransaction)
        {
            banktransaction.UndoOperation();
            TransactionServices.RemoveTransactions(banktransaction);
        }
    }
}
