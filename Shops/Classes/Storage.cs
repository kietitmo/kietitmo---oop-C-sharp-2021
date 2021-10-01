using System.Collections.Generic;
using Shops.Tools;

namespace Shops.Classes
{
    public class Storage
    {
        private List<Product> _procductStorage = null;
        public Storage()
        {
            ProcductStorage = new List<Product>();
        }

        public List<Product> ProcductStorage { get => _procductStorage; set => _procductStorage = value; }

        //// Add new product to Storage
        public Product AddNewProduct(Product newProduct)
        {
            if (FindProduct(newProduct.Name) != null)
            {
                throw new ShopException("Adding Available Product Exception");
            }

            ProcductStorage.Add(newProduct);
            return newProduct;
        }

        public Product AddNewProduct(string productName, double productPrice, int quantity)
        {
            if (FindProduct(productName) != null)
            {
                throw new ShopException("Adding Available Product Exception");
            }

            var newProduct = new Product(productName, productPrice, quantity);
            ProcductStorage.Add(newProduct);
            return newProduct;
        }

        //// Change price of availabe product in Storage
        public Product ChangePrice(Product product, double newPrice)
        {
            Product tempProduct = FindProduct(product.Name);
            if (tempProduct != null)
            {
                tempProduct.PricePerOne = newPrice;
                return tempProduct;
            }
            else
            {
                throw new ShopException("Not Fount To Change Price Exception");
            }
        }

        public Product ChangePrice(string productName, double newPrice)
        {
            Product tempProduct = FindProduct(productName);
            if (tempProduct != null)
            {
                tempProduct.PricePerOne = newPrice;
                return tempProduct;
            }
            else
            {
                throw new ShopException("Not Fount To Change Price Exception");
            }
        }

        //// add a quantity of available product to storage
        public Product AddAvailableProduct(Product product, int amount)
        {
            Product tempProduct = FindProduct(product);
            if (tempProduct != null)
            {
                tempProduct.Quantity += amount;
                return tempProduct;
            }
            else
            {
                throw new ShopException("Not Fount To Change Quantity Exception");
            }
        }

        public Product AddAvailableProduct(string productName, int amount)
        {
            Product tempProduct = FindProduct(productName);
            if (tempProduct != null)
            {
                tempProduct.Quantity += amount;
                return tempProduct;
            }
            else
            {
                throw new ShopException("Not Fount To Change Quantity Exception");
            }
        }

        //// Delete product
        public void DeleteProduct(string productName)
        {
            for (int i = 0; i < ProcductStorage.Count; i++)
            {
                if (productName == ProcductStorage[i].Name)
                {
                    ProcductStorage.RemoveAt(i);
                    return;
                }
            }

            return;
            throw new ShopException("Not Fount To Delete Exception");
        }

        public void DeleteProduct(Product product)
        {
            for (int i = 0; i < ProcductStorage.Count; i++)
            {
                if (product.Name == ProcductStorage[i].Name)
                {
                    ProcductStorage.RemoveAt(i);
                    return;
                }
            }

            return;
            throw new ShopException("Not Fount To Delete Exception");
        }

        //// Find a product
        public Product FindProduct(string productName)
        {
            for (int i = 0; i < ProcductStorage.Count; i++)
            {
                if (productName == ProcductStorage[i].Name)
                {
                    return ProcductStorage[i];
                }
            }

            return null;
            throw new ShopException("Product not Found");
        }

        public Product FindProduct(Product product)
        {
            for (int i = 0; i < ProcductStorage.Count; i++)
            {
                if (product.Name == ProcductStorage[i].Name)
                {
                    return ProcductStorage[i];
                }
            }

            return null;
            throw new ShopException("Product not Found");
        }
    }
}
