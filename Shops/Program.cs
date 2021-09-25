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
            a.AddNewProduct(adidas, "sneaker", 100, 10);
            a.ShowProduct(adidas);
            a.AddNewProduct(nike, "sneaker", 99, 9);
            a.AddNewProduct(nike, "T-shirt", 80, 7);
            a.ShowProduct(nike);
            a.ChangeProductPrice(nike, "sneaker", 169);
            a.TheCheapestShopToBuy("sneaker", 10);
            a.ShowProduct(nike);
            a.AddAvailableProduct(nike, "sneaker", 69);
            a.ShowProduct(nike);
            var mrA = new Customer("A", 1000);
            a.BuyProducts(nike, "T-shirt", 5, mrA);
            a.ShowProduct(nike);
            Console.WriteLine(mrA.Wallet);
        }
    }
}
