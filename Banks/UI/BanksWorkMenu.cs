using System;
using System.Linq;
using Banks.Models.Account.AccountFactory;
using Banks.Models.CentralBank;
using Banks.Models.ClientClass;

namespace Banks.UI
{
    public class BanksWorkMenu : IMenuOfWork
    {
        private CentralBank _centralBank;
        private CentralBankStartUp _centralBankStartUp;

        public BanksWorkMenu(CentralBankStartUp centralBankStartUp)
        {
            _centralBankStartUp = centralBankStartUp;
            _centralBank = _centralBankStartUp.GetCentralBank();
        }

        public void Show()
        {
            Console.WriteLine($"================================");
            Console.WriteLine("BANK SERVICES \n");
            Console.WriteLine($"1. Create a new account.");
            Console.WriteLine($"2. Check balance.");
            Console.WriteLine($"3. Add money into your account.");
            Console.WriteLine($"4. Transfer money to other account.");
            Console.WriteLine($"5. Withdraw money.");
            Console.WriteLine($"6. Update Adress Client.");
            Console.WriteLine($"7. Update Passport of Client.");
            Console.WriteLine($"8. Show all notification of a account.");
            Console.WriteLine($"9. Show all notification via phone of a client.");
            Console.WriteLine($"10. Show all transaction of a account");
            Console.WriteLine($"11. Cancel last transaction.");
            Console.WriteLine($"12. Return.");
            Console.Write($"Please enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine($"================================");
            switch (choice)
            {
                case "1":
                    Console.WriteLine($"1. Create a new account. \n");
                    //// Firstly Create Client
                    Console.Write("Enter name of bank: ");
                    string nameBank = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(nameBank))
                    {
                        Console.WriteLine("That bank does not exist!");
                        break;
                    }

                    Console.Write("Enter your first name: ");
                    string firstnameClient = Console.ReadLine();
                    Console.Write("Enter your surname: ");
                    string surnameClient = Console.ReadLine();
                    Console.Write("Enter your phone number: ");
                    string phoneNumber = Console.ReadLine();
                    var phone = new Phone(phoneNumber);
                    Console.Write("Enter balance: ");
                    string balance = Console.ReadLine();
                    if (balance.Any(x => char.IsLetter(x)))
                    {
                        Console.WriteLine("Invalid Input Data!");
                        break;
                    }

                    string choiceDoubt;
                    Console.WriteLine("Do you want to enter your passport and address? ");
                    Console.WriteLine("1. yes");
                    Console.WriteLine("2. no");
                    Console.Write("Enter your choice by number: ");
                    choiceDoubt = Console.ReadLine();

                    if (choiceDoubt == "1")
                    {
                        Console.Write("Enter your passport serires: ");
                        string passportSeries = Console.ReadLine();
                        Console.Write("Enter your passport number: ");
                        string passportNumber = Console.ReadLine();
                        Console.Write("Enter your address: ");
                        string address = Console.ReadLine();
                        _centralBank.CreateClient(firstnameClient, surnameClient, phone, new Models.ClientClass.PassportData(passportSeries, passportNumber), address);
                    }

                    if (choiceDoubt == "2")
                    {
                        _centralBank.CreateClient(firstnameClient, surnameClient, phone);
                    }

                    //// Then Create Account
                    string choiceTypeAccount;
                    Console.WriteLine("Which type of account you want to create? ");
                    Console.WriteLine("1. Credit");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Debit");
                    Console.Write("Enter your choice by number: ");
                    choiceTypeAccount = Console.ReadLine();

                    switch (choiceTypeAccount)
                    {
                        case "1":
                            _centralBank.CreateAccount(nameBank, firstnameClient, surnameClient, Convert.ToDouble(balance), TypeAccount.Credit);
                            break;

                        case "2":
                            _centralBank.CreateAccount(nameBank, firstnameClient, surnameClient, Convert.ToDouble(balance), TypeAccount.Deposit);

                            Console.WriteLine("How long do you want to deposit your savings? ");
                            Console.Write("Enter quantity day: ");
                            string period = Console.ReadLine();

                            if (period.Any(x => char.IsLetter(x)))
                            {
                                Console.WriteLine("Invalid Input Data!");
                                break;
                            }

                            _centralBank.SetPeriodOfDepositAccount(firstnameClient, surnameClient, nameBank, Convert.ToInt32(period));
                            break;

                        case "3":
                            _centralBank.CreateAccount(nameBank, firstnameClient, surnameClient, Convert.ToDouble(balance), TypeAccount.Debit);
                            break;
                    }

                    Console.WriteLine("New Account Created!");
                    break;

                case "2":
                    Console.WriteLine($"2. Check balance. \n");
                    Console.Write("Enter name of bank: ");
                    nameBank = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(nameBank))
                    {
                        Console.WriteLine("That bank does not exist!");
                        break;
                    }

                    Console.Write("Enter your first name: ");
                    firstnameClient = Console.ReadLine();
                    Console.Write("Enter your surname: ");
                    surnameClient = Console.ReadLine();
                    Console.WriteLine("Balance of this account: " + _centralBank.GetBalance(nameBank, firstnameClient, surnameClient));
                    break;

                case "3":
                    Console.WriteLine($"3. Add money into your account.\n");
                    Console.Write("Enter name of bank: ");
                    nameBank = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(nameBank))
                    {
                        Console.WriteLine("That bank does not exist!");
                        break;
                    }

                    Console.Write("Enter your first name: ");
                    firstnameClient = Console.ReadLine();
                    Console.Write("Enter your surname: ");
                    surnameClient = Console.ReadLine();
                    Console.Write("Enter sum: ");
                    string sum = Console.ReadLine();
                    if (sum.Any(x => char.IsLetter(x)))
                    {
                        Console.WriteLine("Invalid Input Data!");
                        break;
                    }

                    _centralBank.Replenish(firstnameClient, surnameClient, nameBank, Convert.ToDouble(sum));
                    Console.WriteLine("Acction Successful!");
                    break;

                case "4":
                    Console.WriteLine($"4. Transfer money to other account. \n");

                    Console.Write("Enter name of first bank (from): ");
                    string nameBankSource = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(nameBankSource))
                    {
                        Console.WriteLine("source bank does not exist!");
                        break;
                    }

                    Console.Write("Enter your first name: ");
                    string firstnameClientSource = Console.ReadLine();
                    Console.Write("Enter your surname: ");
                    string surnameClientSource = Console.ReadLine();

                    Console.Write("Enter name of second bank (Target): ");
                    string nameBankTarget = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(nameBankTarget))
                    {
                        Console.WriteLine("Target bank does not exist!");
                        break;
                    }

                    Console.Write("Enter your first name (Target Client): ");
                    string firstnameClientTarget = Console.ReadLine();
                    Console.Write("Enter your surname (Target Client): ");
                    string surnameClientTarget = Console.ReadLine();

                    Console.Write("Enter sum: ");
                    sum = Console.ReadLine();
                    if (sum.Any(x => char.IsLetter(x)))
                    {
                        Console.WriteLine("Invalid Input Data!");
                        break;
                    }

                    _centralBank.Transfer(firstnameClientSource, surnameClientSource, nameBankSource, firstnameClientTarget, surnameClientTarget, nameBankTarget, Convert.ToDouble(sum));
                    Console.WriteLine("Acction Successful!");
                    break;

                case "5":
                    Console.WriteLine($"5. Withdraw money. \n");
                    Console.Write("Enter name of bank: ");
                    nameBank = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(nameBank))
                    {
                        Console.WriteLine("That bank does not exist!");
                        break;
                    }

                    Console.Write("Enter your first name: ");
                    firstnameClient = Console.ReadLine();
                    Console.Write("Enter your surname: ");
                    surnameClient = Console.ReadLine();
                    Console.Write("Enter sum: ");
                    sum = Console.ReadLine();
                    if (sum.Any(x => char.IsLetter(x)))
                    {
                        Console.WriteLine("Invalid Input Data!");
                        break;
                    }

                    _centralBank.WithDraw(firstnameClient, surnameClient, nameBank, Convert.ToDouble(sum));
                    Console.WriteLine("Acction Successful!");
                    break;

                case "6":
                    Console.WriteLine($"6. Update Adress Client. \n");
                    Console.Write("Enter your first name: ");
                    firstnameClient = Console.ReadLine();
                    Console.Write("Enter your surname: ");
                    surnameClient = Console.ReadLine();
                    Console.Write("Enter your address: ");
                    string addressClient = Console.ReadLine();
                    _centralBank.UpdateAdress(firstnameClient, surnameClient, addressClient);
                    Console.WriteLine("Updated!");
                    break;

                case "7":
                    Console.WriteLine($"7. Update Passport of Client. \n");
                    Console.Write("Enter your first name: ");
                    firstnameClient = Console.ReadLine();
                    Console.Write("Enter your surname: ");
                    surnameClient = Console.ReadLine();
                    Console.Write("Enter your passport serires: ");
                    string passportSeriesClient = Console.ReadLine();
                    Console.Write("Enter your passport number: ");
                    string passportNumberClient = Console.ReadLine();
                    _centralBank.UpdatePassportData(firstnameClient, surnameClient, new Models.ClientClass.PassportData(passportSeriesClient, passportNumberClient));
                    Console.WriteLine("Updated!");
                    break;

                case "8":
                    Console.Write("Enter name of bank: ");
                    nameBank = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(nameBank))
                    {
                        Console.WriteLine("That bank does not exist!");
                        break;
                    }

                    Console.Write("Enter your first name: ");
                    firstnameClient = Console.ReadLine();
                    Console.Write("Enter your surname: ");
                    surnameClient = Console.ReadLine();
                    Console.WriteLine("All Notification of account: ");
                    _centralBank.ShowAllNotificationOfAccount(firstnameClient, surnameClient, nameBank);
                    break;
                case "9":
                    Console.WriteLine($"9. Show all notification via phone of a client.");
                    Console.Write("Enter your first name: ");
                    firstnameClient = Console.ReadLine();
                    Console.Write("Enter your surname: ");
                    surnameClient = Console.ReadLine();
                    Console.WriteLine("All Notification of client: ");
                    _centralBank.ShowAllNotificationsViaPhoneOfClient(firstnameClient, surnameClient);
                    break;

                case "10":
                    Console.WriteLine($"10. Show all transaction of account.");
                    Console.Write("Enter name of bank: ");
                    nameBank = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(nameBank))
                    {
                        Console.WriteLine("That bank does not exist!");
                        break;
                    }

                    Console.Write("Enter your first name: ");
                    firstnameClient = Console.ReadLine();
                    Console.Write("Enter your surname: ");
                    surnameClient = Console.ReadLine();
                    Console.WriteLine("All Transactions of account: ");
                    _centralBank.ShowAllTransactionOfAccount(firstnameClient, surnameClient, nameBank);
                    break;

                case "11":
                    Console.WriteLine($"11. Cancel last transaction.");
                    Console.Write("Enter name of bank: ");
                    nameBank = Console.ReadLine();
                    Console.Write("Enter your first name: ");
                    firstnameClient = Console.ReadLine();
                    Console.Write("Enter your surname: ");
                    surnameClient = Console.ReadLine();
                    _centralBank.CancelLastTransaction(firstnameClient, surnameClient, nameBank);
                    Console.WriteLine("Last transaction of account is canceled!");
                    break;

                case "12":
                    break;

                default:
                    Console.WriteLine("Please enter number in menu!\n");

                    break;
            }
        }
    }
}
