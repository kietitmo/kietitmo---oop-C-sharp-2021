using System;
using System.Collections.Generic;
using Shops.Classes;
using Shops.Tools;

namespace Shops.ShopManagement
{
    public class ShopManager
    {
        private List<Shop> shopList = null;
        public ShopManager()
        {
            ShopList = new List<Shop>();
        }

        internal List<Shop> ShopList { get => shopList; set => shopList = value; }
        public Shop AddNewShop(string shopName, string shopAdress)
        {
            var newShop = new Shop(shopName, shopAdress);
            ShopList.Add(newShop);
            return newShop;
        }

        public void ChangeProductPrice(Shop shop, Product product, double newPrice)
        {
            shop.Storage.ChangePrice(product, newPrice);
            return;
        }

        public void ChangeProductPrice(Shop shop, string productName, double newPrice)
        {
            shop.Storage.ChangePrice(productName, newPrice);
            return;
        }

        public Product AddNewProduct(Shop shop, Product product)
        {
            return shop.Storage.AddNewProduct(product);
        }

        public Product AddNewProduct(Shop shop, string productName, double productPrice, int quantity)
        {
            return shop.Storage.AddNewProduct(productName, productPrice, quantity);
        }

        public Product AddAvailableProduct(Shop shop, Product product, int amount)
        {
            return shop.Storage.AddAvailableProduct(product, amount);
        }

        public Product AddAvailableProduct(Shop shop, string productName, int amount)
        {
            return shop.Storage.AddAvailableProduct(productName, amount);
        }

        public void DeleteProduct(Shop shop, Product product)
        {
            shop.Storage.DeleteProduct(product);
        }

        public void DeleteProduct(Shop shop, string productName)
        {
            shop.Storage.DeleteProduct(productName);
        }

        public Shop TheCheapestShopToBuy(Product product, int amount)
        {
            var listProductTemp = new List<KeyValuePair<Product, Shop>>();
            for (int i = 0; i < shopList.Count; i++)
            {
                for (int j = 0; j < shopList[i].Storage.ProcductStorage.Count; j++)
                {
                    if (shopList[i].Storage.ProcductStorage[j].Name == product.Name && shopList[i].Storage.ProcductStorage[j].Quantity >= amount)
                    {
                        listProductTemp.Add(new KeyValuePair<Product, Shop>(shopList[i].Storage.ProcductStorage[j], shopList[i]));
                    }
                }
            }

            if (listProductTemp.Count == 0)
            {
                return null;
                throw new ShopException("Product Is Not Enough in any shop");
            }
            else
            {
                KeyValuePair<Product, Shop> minPrice = listProductTemp[0];
                for (int i = 1; i < listProductTemp.Count; i++)
                {
                    if (minPrice.Key.PricePerOne > listProductTemp[i].Key.PricePerOne)
                    {
                        minPrice = listProductTemp[i];
                    }
                }

                return minPrice.Value;
            }
        }

        public Shop TheCheapestShopToBuy(string productName, int amount)
        {
            var listProductTemp = new List<KeyValuePair<Product, Shop>>();
            for (int i = 0; i < shopList.Count; i++)
            {
                for (int j = 0; j < shopList[i].Storage.ProcductStorage.Count; j++)
                {
                    if (shopList[i].Storage.ProcductStorage[j].Name == productName && shopList[i].Storage.ProcductStorage[j].Quantity >= amount)
                    {
                        listProductTemp.Add(new KeyValuePair<Product, Shop>(shopList[i].Storage.ProcductStorage[j], shopList[i]));
                    }
                }
            }

            if (listProductTemp.Count == 0)
            {
                return null;
                throw new ShopException("Product Is Not Enough in any shop");
            }
            else
            {
                KeyValuePair<Product, Shop> minPrice = listProductTemp[0];
                for (int i = 1; i < listProductTemp.Count; i++)
                {
                    if (minPrice.Key.PricePerOne > listProductTemp[i].Key.PricePerOne)
                    {
                        minPrice = listProductTemp[i];
                    }
                }

                Console.Write("\nCheapest Shops To Buy: ");
                Console.WriteLine("\nStore: " + minPrice.Value.Name + " " + minPrice.Value.Adress + "\tProduct: " + minPrice.Key.Name + "\tPrice/one: " + minPrice.Key.PricePerOne + "\t\tAvailable Quantity: " + minPrice.Key.Quantity);
                return minPrice.Value;
            }
        }

        public void BuyProducts(Shop shop, string productName, int amount, Customer customer)
        {
            Product productNeedToBuy = shop.Storage.FindProduct(productName);
            if (productNeedToBuy == null)
            {
                Console.WriteLine("chuan cmnr");
                return;
            }

            if (productNeedToBuy.Quantity < amount)
            {
                throw new ShopException("Not Enough Products");
            }

            if ((double)(productNeedToBuy.PricePerOne * amount) > customer.Wallet)
            {
                throw new ShopException("Customer Is Not Enough Monney");
            }

            productNeedToBuy.Quantity -= amount;
            customer.Wallet -= (double)(productNeedToBuy.PricePerOne * amount);
            return;
        }

        public void ShowProduct(Shop shop)
        {
            Console.WriteLine("\nStore: " + shop.Name + " " + shop.Adress);
            Console.WriteLine("Product" + "\t\t\tPrice/one: " + "\t\tAvailable Quantity: ");
            for (int i = 0; i < shop.Storage.ProcductStorage.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + shop.Storage.ProcductStorage[i].Name + "\t\t" + shop.Storage.ProcductStorage[i].PricePerOne + "\t\t\t" + shop.Storage.ProcductStorage[i].Quantity);
            }
        }
    }
}
