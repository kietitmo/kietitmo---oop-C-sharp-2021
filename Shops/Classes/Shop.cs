using Shops.Tools;

namespace Shops.Classes
{
    public class Shop
    {
        private static int _count = 0;
        private string _name;
        private int iD = ++_count;
        private string _adress;
        private Storage _storage;
        public Shop(string shopName, string shopAdress)
        {
            Name = shopName;
            Adress = shopAdress;
            _storage = new Storage();
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
                else
                {
                    throw new ShopException("Name Of Shop Cann't Be Null Exception");
                }
            }
        }

        public string Adress
        {
            get
            {
                return _adress;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _adress = value;
                }
                else
                {
                    throw new ShopException("Adress Cann't Be Null Exception");
                }
            }
        }

        public Storage Storage { get => _storage; set => _storage = value; }
    }
}
