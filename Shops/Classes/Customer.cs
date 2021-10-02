using Shops.Tools;

namespace Shops.Classes
{
    public class Customer
    {
        private static int _createID = 0;
        private string _name;
        private double _wallet;
        private int _iD;
        public Customer(string name, double wallet)
        {
            Name = name;
            Wallet = wallet;
            _iD = ++_createID;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ShopException("Name Of Custumer Is Null Exception");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public double Wallet { get => _wallet; set => _wallet = value; }
        public int ID { get => _iD; }
    }
}
