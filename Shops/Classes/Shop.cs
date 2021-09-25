using System;
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

        public Product AddNewProduct(Product product)
        {
            return Storage.AddNewProduct(product);
        }

        public Product AddNewProduct(string productName, double productPrice, int quantity)
        {
            return Storage.AddNewProduct(productName, productPrice, quantity);
        }

        public Product ChangeProductPrice(Product product, double newPrice)
        {
            return Storage.ChangePrice(product, newPrice);
        }

        public Product ChangeProductPrice(string productName, double newPrice)
        {
            return Storage.ChangePrice(productName, newPrice);
        }

        public Product AddAvailableProduct(Product product, int amount)
        {
            return Storage.AddAvailableProduct(product, amount);
        }

        public Product AddAvailableProduct(string productName, int amount)
        {
            return Storage.AddAvailableProduct(productName, amount);
        }

        public void DeleteProduct(Product product)
        {
            Storage.DeleteProduct(product);
        }

        public void DeleteProduct(string productName)
        {
            Storage.DeleteProduct(productName);
        }

        public void ShowProduct()
        {
            Console.WriteLine("\nStore: " + Name + " " + Adress);
            Console.WriteLine("Product" + "\t\t\tPrice/one: " + "\t\tAvailable Quantity: ");
            for (int i = 0; i < Storage.ProcductStorage.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + Storage.ProcductStorage[i].Name + "\t\t" + Storage.ProcductStorage[i].PricePerOne + "\t\t\t" + Storage.ProcductStorage[i].Quantity);
            }
        }
    }
}
