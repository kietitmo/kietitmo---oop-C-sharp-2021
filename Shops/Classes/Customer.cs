using Shops.Tools;

namespace Shops.Classes
{
    public class Customer
    {
        private static int createID = 0;
        private string name;
        private double wallet;
        private int iD;
        public Customer(string name, double wallet)
        {
            Name = name;
            Wallet = wallet;
            iD = ++createID;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ShopException("Name Of Custumer Can Be Null");
                }
                else
                {
                    name = value;
                }
            }
        }

        public double Wallet { get => wallet; set => wallet = value; }
        public int ID { get => iD; }
    }
}
