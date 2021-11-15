using System;
using Banks.Models.CentralBank;

namespace Banks.UI
{
    public class BanksManagerment
    {
        private CentralBankStartUp _centralBankStartUp;
        private CentralWorksMenu _cetralBankMenu;
        private BanksWorkMenu _banksServicesMenu;
        private TimeMachineWorkMenu _timeMachineWorkMenu;
        public BanksManagerment()
        {
            _centralBankStartUp = new CentralBankStartUp();
            _cetralBankMenu = new CentralWorksMenu(_centralBankStartUp);
            _banksServicesMenu = new BanksWorkMenu(_centralBankStartUp);
            _timeMachineWorkMenu = new TimeMachineWorkMenu(_centralBankStartUp.CentralBank.TimeMachine);
        }

        public void Run()
        {
            while (true)
            {
                _centralBankStartUp.CentralBank.UpdateBalanceOfAllAccount();
                Console.WriteLine("\n====== WELCOME TO BANKS MANAGEMENT ======");
                Console.WriteLine("You want to work with:");
                Console.WriteLine("1. Central Bank");
                Console.WriteLine("2. Banks Service");
                Console.WriteLine("3. Setup Time");
                Console.Write("Enter your choice by number (1, 2 or 3): ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _cetralBankMenu.Show();
                        break;

                    case "2":
                        _banksServicesMenu.Show();
                        break;

                    case "3":
                        _timeMachineWorkMenu.Show();
                        break;

                    default:
                        Console.WriteLine("Please Only enter numner in menu!");
                        break;
                }
            }
        }
    }
}
