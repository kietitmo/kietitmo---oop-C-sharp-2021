using System;
using Shops.Classes;
using Shops.ShopManagement;

namespace Shops
{
    internal class Program
    {
        private static void Main()
        {
            var a = new ShopManager();
            Shop adidas = a.AddNewShop("Adidas", "Vietnam");
            Shop nike = a.AddNewShop("Nike", "Russia");
            Console.WriteLine(adidas.Name + " " + adidas.Adress);
            adidas.AddNewProduct("sneaker", 100, 10);
            adidas.ShowProduct();
            nike.AddNewProduct("sneaker", 99, 9);
            nike.AddNewProduct("T-shirt", 80, 7);
            nike.ShowProduct();
            a.ChangeProductPrice(nike, "sneaker", 200);
            a.TheCheapestShopToBuy("sneaker", 10);
            nike.ShowProduct();
            nike.AddAvailableProduct("sneaker", 69);
            nike.ShowProduct();
            var mrA = new Customer("A", 1000);
            a.BuyProducts(nike, "T-shirt", 5, mrA);
            nike.ShowProduct();
            Console.WriteLine(mrA.Wallet);
        }
    }
}
