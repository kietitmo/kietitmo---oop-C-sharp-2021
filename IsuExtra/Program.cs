using System;
using IsuExtra.Classes;
namespace IsuExtra
{
    internal class Program
    {
        private static void Main()
        {
            var paratemp1 = new Para(4, 5);
            var paratemp2 = new Para(1, 6);
            var schedule = new Schedule();
            schedule.AddPara(paratemp1, "monday");
            schedule.AddPara(paratemp2, "monday");
            Console.WriteLine("done");
        }
    }
}
