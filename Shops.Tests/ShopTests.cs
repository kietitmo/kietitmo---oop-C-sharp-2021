using Shops.Classes;
using Shops.ShopManagement;
using NUnit.Framework;
namespace Shops.Tests
{
    public class Tests
    {
        private ShopManager _shopManager;

        [SetUp]
        public void Setup()
        {
            _shopManager = new ShopManager();
        }

        [Test]
        public void AddNewShop_NewShopexists()
        {
            _shopManager.AddNewShop("adidas", "Russia");
            Assert.AreEqual(_shopManager.ShopList.Count, 1); //// 1 - this is quantity of shop after adding
        }

        [Test]
        public void AddNewProductToShop_ShopContainsProduct()
        {
            Shop adidas = _shopManager.AddNewShop("adidas", "Russia");
            double priceOfSneaker = 9.9;
            int quantityOfSneaker = 10;
            _shopManager.AddNewProduct(adidas, "sneaker", priceOfSneaker, quantityOfSneaker);
            Assert.AreEqual(adidas.Storage.ProcductStorage.Count, 1); //// 1 - this is quantity of product in shop adidas after adding
        }

        [Test]
        public void ChangePriceOfProductInShop()
        {
            Shop adidas = _shopManager.AddNewShop("adidas", "Russia");
            double priceOfSneaker = 9.9;
            int quantityOfSneaker = 10;
            _shopManager.AddNewProduct(adidas, "sneaker", priceOfSneaker, quantityOfSneaker); //// Add product "sneaker" into shop adidas
            double newPriceToChange = 1.1;
            _shopManager.ChangeProductPrice(adidas, "sneaker", newPriceToChange);
            Assert.AreEqual(adidas.Storage.FindProduct("sneaker").PricePerOne, newPriceToChange); //// check new Price
        }

        [Test]
        public void AddProductToAvailableProductInShop()
        {
            Shop adidas = _shopManager.AddNewShop("adidas", "Russia");
            double priceOfSneaker = 9.9;
            int quantityOfSneaker = 10;
            int quantityBeforeAdd = 10;
            _shopManager.AddNewProduct(adidas, "sneaker", priceOfSneaker, quantityOfSneaker); //// Add product "sneaker" into shop adidas
            int quantityToadd = 100;
            _shopManager.AddAvailableProduct(adidas, "sneaker", quantityToadd);
            Assert.AreEqual(adidas.Storage.FindProduct("sneaker").Quantity, quantityToadd + quantityBeforeAdd); //// check quantity after adding
        }

        [Test]
        public void CustomerBuyProduct()
        {
            //// Add shop and product
            Shop adidas = _shopManager.AddNewShop("adidas", "Russia");
            double priceOfSneaker = 9.9;
            int quantityOfSneaker = 10;
            Product sneaker = _shopManager.AddNewProduct(adidas, "sneaker", priceOfSneaker, quantityOfSneaker);
          
            //// create new customer
            double moneyBeforeOfCustomer = 1000;
            int quantityNeedToBuy = 10;
            var mrA = new Customer("mrA", moneyBeforeOfCustomer);           

            //// Customer buys product
            _shopManager.BuyProducts(adidas, "sneaker", quantityNeedToBuy, mrA);

            //// check wallet of customer after buying
            Assert.AreEqual(mrA.Wallet, moneyBeforeOfCustomer - sneaker.PricePerOne * quantityNeedToBuy);
        }

        [Test]
        public void CheapestShopToBuy()
        {
            //// add 3 shops
            Shop adidas = _shopManager.AddNewShop("adidas", "Russia");
            _shopManager.AddNewProduct(adidas, "sneaker", 5.9, 10);
            Shop nike = _shopManager.AddNewShop("nike", "Russia");
            _shopManager.AddNewProduct(nike, "sneaker", 7.9, 5);
            Shop puma = _shopManager.AddNewShop("puma", "Russia");
            _shopManager.AddNewProduct(puma, "sneaker", 9.9, 15);

            //// find cheapest store to buy
            int amountToBuy = 8;
            Shop cheapestShop = _shopManager.TheCheapestShopToBuy("sneaker", amountToBuy);
            Assert.AreEqual(cheapestShop,adidas);
        }
    }
}
