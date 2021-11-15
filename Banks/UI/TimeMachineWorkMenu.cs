using System;
using Banks.Timer;

namespace Banks.UI
{
    public class TimeMachineWorkMenu : IMenuOfWork
    {
        public TimeMachineWorkMenu(TimeMachine timeMachine)
        {
            TimeMachine = timeMachine;
        }

        public TimeMachine TimeMachine { get; set; }
        public void Show()
        {
            Console.WriteLine($"================================");
            Console.WriteLine("BACK TO THE FUTURE \n");
            Console.WriteLine($"1. Go to next some days.");
            Console.WriteLine($"2. Show Date now.");
            Console.WriteLine($"3. Return.");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter quantity days: ");
                    string quantityDay = Console.ReadLine();
                    TimeMachine.AddSomeDays(Convert.ToInt32(quantityDay));
                    break;

                case "2":
                    Console.WriteLine("Today: " + TimeMachine.Date);
                    break;

                case "3":
                    break;
            }
        }
    }
}
