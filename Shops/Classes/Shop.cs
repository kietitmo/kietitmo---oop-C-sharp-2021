using Shops.Tools;

namespace Shops.Classes
{
    public class Shop
    {
        private static int count = 0;
        private string name;
        private int iD = ++count;
        private string adress;
        private Storage storage;
        public Shop(string shopName, string shopAdress)
        {
            Name = shopName;
            Adress = shopAdress;
            storage = new Storage();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
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
                return adress;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    adress = value;
                }
                else
                {
                    throw new ShopException("Adress Cann't Be Null Exception");
                }
            }
        }

        public Storage Storage { get => storage; set => storage = value; }
    }
}
