using NUnit.Framework;
using Microsoft.VisualStudio.TestPlatform;
using unieuroopSharp.Iorio;
using unieuroopSharp.Ferri;
using unieuroopSharp.Vincenzi;
using unieuroopSharp.Strada;
using System;
using System.Linq;
using System.Collections.Generic;
 
namespace StradaTest
{
    public class Tests
    {
        private static readonly String APPLE_PRODUCT = "Apple";
        private static readonly String SAMSUNG_PRODUCT = "Samsung";
        private static readonly String IPHONE_13_PRO = "Iphone 13 Pro";
        private static readonly String SAMSUNG_S7 = "Samsung S7";
        private static readonly String APPLEWATCH = "Applewatch";
        private static readonly String IPAD_AIR = "Ipad Air";
        private static readonly String IPAD_PRO = "Ipad Pro";
        private static readonly String MAC_BOOK_14 = "MacBook Pro 14";
        private static readonly String MAC_BOOK_16 = "MacBook Pro 16";
        private static readonly String DESCRIPTION_P1 = "Best Phone Ever";
        private static readonly String DESCRIPTION_P2 = "Best Phone Ever Created";
        private static readonly String DESCRIPTION_P3 = "Best MacBook Ever Created";
        private static readonly String DESCRIPTION_P4 = "Best Ipad Ever";
        private static readonly String DESCRIPTION_P5 = "Best Samsung Phone Ever";
        private IShop shop;
        Dictionary<IProduct, int> products;
 
        private readonly IProduct product1 = new Product(1, IPHONE_13_PRO, APPLE_PRODUCT,  1200.00,  900.00, DESCRIPTION_P1, Product.Category.SMARTPHONE);
        private readonly IProduct product2 = new Product(2, APPLEWATCH, APPLE_PRODUCT, 500.00,  200.00, DESCRIPTION_P2, Product.Category.SMARTWATCH);
        private readonly IProduct product3 = new Product(3, MAC_BOOK_14, APPLE_PRODUCT,  3000.00, 2000.00, DESCRIPTION_P3, Product.Category.PC);
        private readonly IProduct product4 = new Product(4, MAC_BOOK_16, APPLE_PRODUCT,  6000.00,  3000.00, DESCRIPTION_P3, Product.Category.PC);
        private readonly IProduct product5 = new Product(5, IPAD_AIR, APPLE_PRODUCT,  700.00,  300.00, DESCRIPTION_P4, Product.Category.TABLET);
        private readonly IProduct product6 = new Product(6, IPAD_PRO, APPLE_PRODUCT, 1000.00, 500.00, DESCRIPTION_P4, Product.Category.TABLET);
        private readonly IProduct product7 = new Product(7, SAMSUNG_S7, SAMSUNG_PRODUCT, 1200.00,  900.00, DESCRIPTION_P5, Product.Category.HOME);
 
        /**
         * ALL THE SALES THAT WILL BE USED IN THIS TEST.
        */
 
        [SetUp]
        public void Setup()
        {
            products = new Dictionary<IProduct, int>();
            shop = new Shop("Shop Test");
            products.Add(product1, 1);
            products.Add(product2, 2);
            products.Add(product3, 1);
            products.Add(product4, 2);
            products.Add(product5, 3);
            products.Add(product6, 30);
            products.Add(product7, 5);
            this.shop.Stock.AddProducts(products);
        }
 
        [Test]
        public void TestAddProducts()
        {
            IProduct product8 = new Product(8, SAMSUNG_S7, SAMSUNG_PRODUCT, 1200.00, 900.00, DESCRIPTION_P5, Product.Category.DOMESTIC_APPLIANCE);
            Dictionary<IProduct, int> p8 = new Dictionary<IProduct, int>();
            p8.Add(product8,1);
            this.products.Add(product8,1);
            this.shop.Stock.AddProducts(p8);
            Assert.AreEqual(this.products, this.shop.Stock.GetTotalStock());
            this.shop = null;
        }
 
        [Test]
        public void TestQuantityOf()
        {
            Assert.AreEqual(1, this.shop.Stock.GetQuantityOfProduct(product1));
            Assert.AreEqual(2, this.shop.Stock.GetQuantityOfProduct(product2));
            Assert.AreEqual(1, this.shop.Stock.GetQuantityOfProduct(product3));
            Assert.AreEqual(2, this.shop.Stock.GetQuantityOfProduct(product4));
            this.shop = null;
        }
 
        [Test]
        public void TestTakeFromStock1()
        {
            Dictionary<IProduct, int> productTaken = new Dictionary<IProduct, int>();
            productTaken.Add(product1, 1);
            this.products[product1] -= 1;
            try
            {
                this.shop.Stock.TakeFromStock(productTaken);
                Assert.AreEqual(this.products, this.shop.Stock.GetTotalStock());
            }
            catch (ArgumentException e)
            {
                Assert.Fail("No exception have to be thrown" + e.Message);
            }
            this.shop = null;
        }
 
        [Test]
        public void TestTakeFromStock2()
        {
            Dictionary<IProduct, int> productTaken = new Dictionary<IProduct, int>();
            productTaken.Add(product1, 100);
            try
            {
                this.shop.Stock.TakeFromStock(productTaken);
                Assert.Fail("Exception have to be thrown");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Some products can not be taken", e.Message);
            }
            this.shop = null;
        }
 
        [Test]
        public void TestDeleteProduct1()
        {
            HashSet<IProduct> productsDeleted = new HashSet<IProduct>();
            productsDeleted.Add(this.product7);
            try
            {
                this.shop.Stock.DeleteProducts(productsDeleted);
            }
            catch (ArgumentException e)
            {
                Assert.Fail("Product product1 exist inside the stock." + e.Message);
            }
            this.shop = null;
        }
 
        [Test]
        public void TestDeleteProduct2()
        {
            HashSet<IProduct> productsDeleted = new HashSet<IProduct>();
            IProduct product8 = new Product(8, SAMSUNG_S7, SAMSUNG_PRODUCT, 1200.00,  900.00, DESCRIPTION_P5, Product.Category.HOME);
            productsDeleted.Add(product8);
            try
            {
                this.shop.Stock.DeleteProducts(productsDeleted);
                Assert.Fail("Product product8 does not exist inside the stock.");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Some products can not be Deleted", e.Message);
            }
            this.shop = null;
        }
 
        [Test]
        public void TestFilterProducts()
        {
            IProduct p1 = new Product(1, IPHONE_13_PRO, APPLE_PRODUCT, 1200.00, 900.00, "best phone ever created", Product.Category.SMARTPHONE);
            IProduct p2 = new Product(2, APPLEWATCH, APPLE_PRODUCT, 500.00, 200.00, DESCRIPTION_P2, Product.Category.SMARTWATCH);
            IProduct p3 = new Product(3, MAC_BOOK_14, APPLE_PRODUCT, 3000.00, 2000.00, DESCRIPTION_P3, Product.Category.PC);
            var dictionary = new Dictionary<IProduct, int>();
            dictionary.Add(p1, 1);
            dictionary.Add(p2, 2);
            dictionary.Add(p3, 1);
            this.shop.Stock.AddProducts(dictionary);
            Assert.True(this.shop.Stock.GetFilterProducts((tuple) => tuple.Item2 == Product.Category.SMARTPHONE).All((element) => element.ProductCode == p1.ProductCode));
            Assert.True(this.shop.Stock.GetFilterProducts((tuple) => tuple.Item2 == Product.Category.SMARTWATCH).All((element) => element.ProductCode == p2.ProductCode));
            var list = new List<IProduct>();
            list.Add(p1);
            list.Add(p2);
            Assert.True(this.shop.Stock.GetFilterProducts((tuple) => tuple.Item1 == 1).All((element) => list.Any((product) => product.ProductCode == element.ProductCode)));
            Assert.True(this.shop.Stock.GetFilterProducts((tuple) => tuple.Item1 == 1 && tuple.Item2 == Product.Category.DOMESTIC_APPLIANCE).Count == 0);
            this.shop = null;
        }
 
        [Test]
        public void TestSortProducts()
        {
            List<IProduct> productsNotSorted = new List<IProduct>();
            productsNotSorted.Add(this.product1);
            productsNotSorted.Add(this.product3);
            productsNotSorted.Add(this.product2);
            productsNotSorted.Add(this.product4);
            productsNotSorted.Add(this.product5);
            productsNotSorted.Add(this.product6);
            productsNotSorted.Add(this.product7);
            //productsSortedIncreasing.ForEach(a => Console.WriteLine();
            var list = this.shop.Stock
            .GetProductsSorted(Comparer<IProduct>.Create((p1, p2) => p1.ProductCode.CompareTo(p2.ProductCode)));
            Assert.AreNotEqual(productsNotSorted, list);
            var productsSorted = new List<IProduct>();
            productsSorted.Add(this.product1);
            productsSorted.Add(this.product2);
            productsSorted.Add(this.product3);
            productsSorted.Add(this.product4);
            productsSorted.Add(this.product5);
            productsSorted.Add(this.product6);
            productsSorted.Add(this.product7);
            Assert.AreEqual(list, productsSorted);
            this.shop = null;
        }
 
        [Test]
        public void TestGetMax()
        {
            Assert.AreEqual(30, this.shop.Stock.GetMaxAmountOfProducts());
            this.shop = null;
        }
    }   
}