using Shops.Tools;

namespace Shops.Classes
{
    public class Product
    {
        private string name;
        private double pricePerOne = 0;
        private int quantity = 0;
        public Product(string productName, double productPrice, int productQuantity)
        {
            Name = productName;
            PricePerOne = productPrice;
            Quantity = productQuantity;
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
                    throw new ShopException("NameOfProductNullException");
                }
            }
        }

        public double PricePerOne
        {
            get
            {
                return pricePerOne;
            }
            set
            {
                if (value > 0)
                {
                    pricePerOne = value;
                }
                else
                {
                    throw new ShopException("PriceNegativeException");
                }
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value > 0)
                {
                    quantity = value;
                }
                else
                {
                    throw new ShopException("AmountNegativeException");
                }
            }
        }
    }
}
