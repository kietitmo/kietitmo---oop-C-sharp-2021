using System;
using System.Linq;
using Banks.Models.Account;
using Banks.Models.BankClass;
using Banks.Models.CentralBank;

namespace Banks.UI
{
    public class CentralWorksMenu : IMenuOfWork
    {
        private CentralBankStartUp _centralBankStartUp;
        private CentralBank _centralBank;

        public CentralWorksMenu(CentralBankStartUp centralBankStartUp)
        {
            _centralBankStartUp = centralBankStartUp;
            _centralBank = _centralBankStartUp.GetCentralBank();
        }

        public void Show()
        {
            Console.WriteLine($"================================");
            Console.WriteLine("CENTRAL-BANK CONTROLLER \n");
            Console.WriteLine($"1. Create a new bank.");
            Console.WriteLine($"2. Change Comssion of a bank.");
            Console.WriteLine($"3. Change Persentage of a bank.");
            Console.WriteLine($"3. Change debt limit of a bank.");
            Console.WriteLine($"5. Get Information a a bank.");
            Console.WriteLine($"6. Show list all bank.");
            Console.WriteLine($"7. Return");
            Console.Write($"Please enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine($"================================");
            switch (choice)
            {
                case "1":
                    Console.WriteLine($"1. Create a new bank.\n");
                    Console.Write("Enter name of new bank: ");
                    string name = Console.ReadLine();

                    if (_centralBank.BankServices.FindBankIdByName(name))
                    {
                        Console.WriteLine("Name of Bank is existing!");
                        break;
                    }

                    Console.Write("Enter commission of new bank: ");
                    string commissionValue = Console.ReadLine();
                    Console.Write("Enter low persentage of new bank: ");
                    string lowPersentage = Console.ReadLine();
                    Console.Write("Enter medium persentage of new bank: ");
                    string mediumPersentage = Console.ReadLine();
                    Console.Write("Enter high persentage of new bank: ");
                    string highPersentage = Console.ReadLine();
                    Console.Write("Enter debt limit of new bank: ");
                    string debtLimitValue = Console.ReadLine();

                    if (commissionValue.Any(x => char.IsLetter(x)) || lowPersentage.Any(x => char.IsLetter(x)) || mediumPersentage.Any(x => char.IsLetter(x)) || highPersentage.Any(x => char.IsLetter(x)) || debtLimitValue.Any(x => char.IsLetter(x)))
                    {
                        Console.WriteLine("Invalid Input Data!");
                        break;
                    }

                    var commission = new Commission(Convert.ToDouble(commissionValue));
                    var debtlimit = new DebtLimit(Convert.ToDouble(debtLimitValue));
                    var persentage = new Persentage(Convert.ToDouble(lowPersentage), Convert.ToDouble(mediumPersentage), Convert.ToDouble(highPersentage));
                    Console.Write("Enter range of values we apply low percentage (0 -> x): x = ");
                    string x = Console.ReadLine();
                    Console.Write("Enter range of values we apply medium percentage (x -> y): y = ");
                    string y = Console.ReadLine();

                    if (x.Any(x => char.IsLetter(x)) || y.Any(x => char.IsLetter(x)))
                    {
                        Console.WriteLine("Invalid range of values we apply percentage!");
                        break;
                    }

                    persentage.SumWithLowPersentage = Convert.ToDouble(x);
                    persentage.SumWithMediumPersentage = Convert.ToDouble(y);

                    Console.Write("Enter max sum if client is doubtful: ");
                    string maxSumIfDoubtful = Console.ReadLine();

                    if (maxSumIfDoubtful.Any(x => char.IsLetter(x)))
                    {
                        Console.WriteLine("Invalid value max sum if client is doubtful!");
                        break;
                    }

                    _centralBank.CreateBank(name, commission, persentage, debtlimit, Convert.ToDouble(maxSumIfDoubtful));
                    Console.WriteLine("Bank is Created!");
                    break;

                case "2":
                    Console.WriteLine($"2. Change Comssion of a bank.\n");
                    Console.Write("Enter name of bank: ");
                    name = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(name))
                    {
                        Console.WriteLine("Inputed Bank does not exist!");
                        break;
                    }

                    Console.Write("Enter new commission of new bank: ");
                    string newValueCommission = Console.ReadLine();
                    if (newValueCommission.Any(x => char.IsLetter(x)))
                    {
                        Console.WriteLine("Invalid Input Data!");
                        break;
                    }

                    _centralBank.SetComission(name, Convert.ToDouble(newValueCommission));
                    Console.WriteLine("Commission is changed!");
                    break;

                case "3":
                    Console.WriteLine($"3. Change Persentage of a bank.\n");
                    Console.Write("Enter name of bank: ");
                    name = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(name))
                    {
                        Console.WriteLine("Inputed Bank does not exist!");
                        break;
                    }

                    Bank bank = _centralBank.BankServices.GetBankByName(name);

                    Console.Write("Enter  new low persentage of bank: ");
                    lowPersentage = Console.ReadLine();
                    Console.Write("Enter new medium persentage of bank: ");
                    mediumPersentage = Console.ReadLine();
                    Console.Write("Enter new high persentage of bank: ");
                    highPersentage = Console.ReadLine();

                    if (lowPersentage.Any(x => char.IsLetter(x)) || mediumPersentage.Any(x => char.IsLetter(x)) || highPersentage.Any(x => char.IsLetter(x)))
                    {
                        Console.WriteLine("Invalid Input Data!");
                        break;
                    }

                    Console.Write("Enter range of values we apply low percentage (0 -> x): x = ");
                    x = Console.ReadLine();
                    Console.Write("Enter range of values we apply medium percentage (x -> y): y = ");
                    y = Console.ReadLine();

                    if (x.Any(x => char.IsLetter(x)) || y.Any(x => char.IsLetter(x)))
                    {
                        Console.WriteLine("Invalid range of values we apply percentage!");
                        break;
                    }

                    bank.Persentage.SumWithLowPersentage = Convert.ToDouble(x);
                    bank.Persentage.SumWithMediumPersentage = Convert.ToDouble(y);
                    _centralBank.SetPersentage(name, Convert.ToDouble(lowPersentage), Convert.ToDouble(mediumPersentage), Convert.ToDouble(highPersentage));

                    Console.WriteLine("Persentage is changed!");
                    break;

                case "4":
                    Console.WriteLine($"3. Change debt limit of a bank.\n");
                    Console.Write("Enter name of new bank: ");
                    name = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(name))
                    {
                        Console.WriteLine("Inputed Bank does not exist!");
                        break;
                    }

                    Console.Write("Enter new debt limit of new bank: ");
                    string newDebtLimitValue = Console.ReadLine();
                    if (newDebtLimitValue.Any(x => char.IsLetter(x)))
                    {
                        Console.WriteLine("Invalid Input Data!");
                        break;
                    }

                    _centralBank.SetDebtLimit(name, Convert.ToDouble(newDebtLimitValue));
                    Console.WriteLine("Debt Limit is changed!");
                    break;

                case "5":

                    Console.WriteLine($"5. Get Information a a bank.\n");
                    Console.Write("Enter name of new bank: ");
                    name = Console.ReadLine();

                    if (!_centralBank.BankServices.FindBankIdByName(name))
                    {
                        Console.WriteLine("Inputed Bank does not exist!");
                        break;
                    }

                    bank = _centralBank.BankServices.GetBankByName(name);
                    Console.WriteLine("Bank Name: " + bank.Name);
                    Console.WriteLine("Bank ID: " + bank.Id);
                    Console.WriteLine("Bank Commission: " + bank.Commission);
                    Console.WriteLine("Bank Persentage: " + bank.Persentage);
                    Console.WriteLine("Bank Debt Limit: " + bank.DebtLimit);
                    break;

                case "6":
                    Console.WriteLine("List of all banks:");
                    _centralBank.ShowListAllBank();
                    break;

                case "7":
                    break;

                default:
                    Console.WriteLine("Please enter number in menu!");
                    break;
            }
        }
    }
}
