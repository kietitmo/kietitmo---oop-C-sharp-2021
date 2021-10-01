using System;
using System.Collections.Generic;
using Shops.Classes;
using Shops.Tools;

namespace Shops.ShopManagement
{
    public class ShopManager
    {
        private List<Shop> _shopList = null;
        public ShopManager()
        {
            ShopList = new List<Shop>();
        }

        public List<Shop> ShopList { get => _shopList; set => _shopList = value; }

        //// Add new shop
        public Shop AddNewShop(string shopName, string shopAdress)
        {
            var newShop = new Shop(shopName, shopAdress);
            ShopList.Add(newShop);
            return newShop;
        }

        //// Add new product in a shop
        public Product AddNewProduct(Shop shop, Product product)
        {
            return shop.Storage.AddNewProduct(product);
        }

        public Product AddNewProduct(Shop shop, string productName, double productPrice, int quantity)
        {
            return shop.Storage.AddNewProduct(productName, productPrice, quantity);
        }

        //// Change price of product in a shop
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

        //// Add a quantity of available product to storage
        public Product AddAvailableProduct(Shop shop, Product product, int amount)
        {
            return shop.Storage.AddAvailableProduct(product, amount);
        }

        public Product AddAvailableProduct(Shop shop, string productName, int amount)
        {
            return shop.Storage.AddAvailableProduct(productName, amount);
        }

        //// Delete a product
        public void DeleteProduct(Shop shop, Product product)
        {
            shop.Storage.DeleteProduct(product);
        }

        public void DeleteProduct(Shop shop, string productName)
        {
            shop.Storage.DeleteProduct(productName);
        }

        //// Find cheapest shop with amount of product
        public Shop TheCheapestShopToBuy(Product product, int amount)
        {
            var listProductTemp = new List<KeyValuePair<Product, Shop>>();
            for (int i = 0; i < ShopList.Count; i++)
            {
                for (int j = 0; j < ShopList[i].Storage.ProcductStorage.Count; j++)
                {
                    //// Find shop contains enough quantity product
                    if (ShopList[i].Storage.ProcductStorage[j].Name == product.Name && ShopList[i].Storage.ProcductStorage[j].Quantity >= amount)
                    {
                        listProductTemp.Add(new KeyValuePair<Product, Shop>(ShopList[i].Storage.ProcductStorage[j], ShopList[i]));
                    }
                }
            }

            if (listProductTemp.Count == 0) //// If listProductTemp == null, it means No products were found
            {
                return null;
                throw new ShopException("Product Is Not Enough in any shop");
            }
            else
            {
                //// find Shop with min Price
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
            for (int i = 0; i < ShopList.Count; i++)
            {
                for (int j = 0; j < ShopList[i].Storage.ProcductStorage.Count; j++)
                {
                    if (ShopList[i].Storage.ProcductStorage[j].Name == productName && ShopList[i].Storage.ProcductStorage[j].Quantity >= amount)
                    {
                        listProductTemp.Add(new KeyValuePair<Product, Shop>(ShopList[i].Storage.ProcductStorage[j], ShopList[i]));
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

        //// Customer buy amount of product
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

        //// Show products in a shop
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
