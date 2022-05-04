using NUnit.Framework;
using Microsoft.VisualStudio.TestPlatform;
using unieuroopSharp.Iorio;
using unieuroopSharp.Ferri;
using unieuroopSharp.Vincenzi;
using System;
using System.Collections.Generic;
namespace IorioTest
{
    public class Tests
    {
        private static readonly int P1_TOTAL_SOLD = 31; /*sum of all p1s product*/
        private static readonly int P2_TOTAL_SOLD = 300; /*sum of all p2s product*/
        private static readonly int P3_TOTAL_SOLD = 11; /*sum of all p3s product*/
        /*All the money earned from sales*/
        private static readonly double TOTAL_SHOP_EARNED = 961_600;
        private static readonly double TOTAL_SPENT_NOW = 16;
        private static readonly int TOTAL_SOLD_NOW = 565;
        /*ERROR tolerance*/
        private static readonly double ERROR_TOLLERANCE = 0.01;
        /*Data for a temporary local date*/
        private static readonly int YEAR_TEST = 2001;
        private static readonly int YEAR_TEST2 = 2002;
        private static readonly int MONTH_TEST = 2;
        private static readonly int DAY_TEST = 11;

        private static readonly String APPLE_PRODUCT = "APPLE"; /*Brand of products*/
        private static readonly int TOTAL_PRODUCT_SOLD = 7;  /*all the total product sold , not the quantity*/
        private static readonly DateTime TIME_NOW = DateTime.Now;
        private Analityc _analytic;
        private Shop _shop = new Shop("prova");
        private readonly Product p1 = new Product(1, "iphone 13 pro", APPLE_PRODUCT,  1200.00,  900.00, "best phone ever created", Product.Category.SMARTPHONE);
        private readonly Product p2 = new Product(2, "applewatch", APPLE_PRODUCT, 500.00,  200.00, "best watch ever created", Product.Category.SMARTWATCH);
        private readonly Product p3 = new Product(3, "mac book pro 14 ", APPLE_PRODUCT,  3000.00, 2000.00, "best mac book ever created", Product.Category.PC);
        private readonly Product p4 = new Product(4, "mac book pro 16", APPLE_PRODUCT,  6000.00,  3000.00, "best mac book ever created", Product.Category.PC);
        private readonly Product p5 = new Product(5, "ipad Air ", APPLE_PRODUCT,  700.00,  300.00, "best ipad ever created", Product.Category.HOME);
        private readonly Product p6 = new Product(6, "ipad Pro", APPLE_PRODUCT, 1000.00, 500.00, "best ipad Pro ever created", Product.Category.HOME);
        private readonly Product p7 = new Product(7, "ipad Pro Max", APPLE_PRODUCT, 1200.00,  900.00, "best ipad pro max ever created", Product.Category.HOME);
        private readonly Product p8 = new Product(8, "ipad Pro Max v2", APPLE_PRODUCT, 1200.00, 900.00, "best ipad pro max ever created", Product.Category.HOME);
        /**
         * ALL THE SALES THAT WILL BE USED IN THIS TEST.
         */
        [SetUp]
        public void Setup()
        {
            Dictionary<Product, int> products = new Dictionary<Product, int>();
            products.Add(p1, 10);
            products.Add(p2, 100);
            products.Add(p5, 1);
            Sale sale1 = new Sale(TIME_NOW, new Dictionary<Product, int>(products), Optional<Client>.Empty());
            products.Clear();
            products.Add(p1, 10);
            products.Add(p2, 100);
            products.Add(p5, 1);
            products.Add(p7, 10);
            Sale sale2 = new Sale(TIME_NOW, new Dictionary<Product, int>(products), Optional<Client>.Empty());
            products.Clear();
            products.Add(p5, 10);
            products.Add(p2, 100);
            products.Add(p6, 1);
            Sale sale3 = new Sale(TIME_NOW, new Dictionary<Product, int>(products), Optional<Client>.Empty());
            products.Clear();
            products.Add(p3, 10);
            products.Add(p7, 100);
            products.Add(p1, 1);
            Sale sale4 = new Sale(TIME_NOW, new Dictionary<Product, int>(products), Optional<Client>.Empty());
            products.Clear();
            products.Add(p1, 10);
            products.Add(p4, 100);
            products.Add(p3, 1);
            Sale sale5 = new Sale(TIME_NOW, new Dictionary<Product, int>(products), Optional<Client>.Empty());

            this._shop.AddSale(sale1);
            this._shop.AddSale(sale2);
            this._shop.AddSale(sale3);
            this._shop.AddSale(sale3);
            this._shop.AddSale(sale4);
            this._shop.AddSale(sale5);
            this._shop.AddBills(TIME_NOW, 4);
            this._shop.AddBills(TIME_NOW, 10);
            this._shop.AddBills(TIME_NOW, 2);
            _analytic = new Analityc(_shop);
            Assert.True(this._analytic.GetTotalShopEarned() > 0);
        }

        [Test]
        public void testGetTotalProductsSold()
        {
            Assert.AreNotEqual(new HashSet<Product>(), this._analytic.GetTotalProductsSold());
            /*Check if all 7 product are contained in Analytic*/
            Assert.True(this._analytic.GetTotalProductsSold().Contains(p1));
            Assert.True(this._analytic.GetTotalProductsSold().Contains(p2));
            Assert.True(this._analytic.GetTotalProductsSold().Contains(p3));
            Assert.True(this._analytic.GetTotalProductsSold().Contains(p4));
            Assert.True(this._analytic.GetTotalProductsSold().Contains(p5));
            Assert.True(this._analytic.GetTotalProductsSold().Contains(p6));
            Assert.True(this._analytic.GetTotalProductsSold().Contains(p7));
            /*Check if a specific product that is not present in any Sale is contained in _analytic*/
            Assert.False(this._analytic.GetTotalProductsSold().Contains(p8));
            /*Check if all the seven product are inside the list of all product sold*/
            Assert.AreEqual(TOTAL_PRODUCT_SOLD, this._analytic.GetTotalProductsSold().Count);
        }
        [Test]
        public void testQuantitySoldOf()
        {
            Assert.AreEqual(P1_TOTAL_SOLD, this._analytic.GetQuantitySoldOf(p1));
            Assert.AreEqual(0, this._analytic.GetQuantitySoldOf(p8)); /*p8 does not exist in all the sales*/

            /*Add the new sale inside the analytic with the product p8*/
            Sale sale6 = new Sale(DateTime.Now, new Dictionary<Product, int>() { [p8] =  100 }, Optional<Client>.Empty());
            this._shop.AddSale(sale6);
            Assert.AreEqual(100, this._analytic.GetQuantitySoldOf(p8));
            Assert.AreEqual(P2_TOTAL_SOLD, this._analytic.GetQuantitySoldOf(p2));
            Assert.AreNotEqual(0, this._analytic.GetQuantitySoldOf(p5));
        }
        [Test]
        public void testQuantitySoldOf2()
        {
            DateTime dateTemp = new DateTime(YEAR_TEST, MONTH_TEST, DAY_TEST);
            int quantityP1 = this._analytic.GetQuantitySoldOf(p1,
                    (date)=>date.Equals(TIME_NOW));
            int quantityP2 = this._analytic.GetQuantitySoldOf(p2,
                    (date)=>date.Equals(TIME_NOW));
            int quantityP3 = this._analytic.GetQuantitySoldOf(p3,
                    (date)=>date.Equals(dateTemp));

            Assert.True(quantityP1 > 0);
            Assert.True(quantityP2 > 0);
            Assert.AreEqual(0, quantityP3);
            Assert.AreEqual(P1_TOTAL_SOLD, quantityP1);
            Assert.AreEqual(P2_TOTAL_SOLD, quantityP2);

            quantityP3 = this._analytic.GetQuantitySoldOf(p3,
                    (date)=>date.Equals(TIME_NOW));
            Assert.True(quantityP3 > 0);
            Assert.AreEqual(P3_TOTAL_SOLD, quantityP3);
        }
        [Test]
        public void testOrderedByCategory1()
        {
            HashSet<Product.Category> categories = new HashSet<Product.Category> () {Product.Category.HOME, Product.Category.PC,
                    Product.Category.SMARTPHONE, Product.Category.SMARTWATCH };

            Assert.AreNotEqual(new Dictionary<Product.Category, int>(),
                    this._analytic.GetOrderedByCategory((category)=>categories.Contains(category)));

            Assert.AreNotEqual(new Dictionary<Product.Category, int>(),
                    this._analytic.GetOrderedByCategory((category)=>category == Product.Category.SMARTPHONE));

            Assert.AreNotEqual(new Dictionary<Product.Category, int>(),
                    this._analytic.GetOrderedByCategory((category)=>category == Product.Category.HOME));

            Assert.AreNotEqual(new Dictionary<Product.Category, int>(),
                    this._analytic.GetOrderedByCategory((category)=>category == Product.Category.SMARTWATCH));

            Assert.AreNotEqual(new Dictionary<Product.Category, int>(),
                    this._analytic.GetOrderedByCategory((category)=>category == Product.Category.PC));

            /*we don't have any product of type Tablet*/
            Assert.AreEqual(new Dictionary<Product.Category, int>(),
                    this._analytic.GetOrderedByCategory((category)=>category == Product.Category.TABLET));
        }
        /**
         * TEST FOR : analytic.GetOrderedByCategory(Predicate<Category> c); {@link Analytic}
         * Test of GetOrderedByCategory, this method return a Map contain a Product and it's quantity sold.
         * Test if every categories on sale are present in Analytic's result. By adding or removing some categories
         * in the Predicate of the method
         */
        [Test]
        public void testOrderedByCategory2()
            {
                HashSet<Product.Category> categories = new HashSet<Product.Category>() { Product.Category.SMARTPHONE, Product.Category.SMARTWATCH };
                Dictionary<Product, int> products = this._analytic.GetOrderedByCategory((category)=>category == Product.Category.SMARTPHONE);

                Assert.AreEqual(1, products.Count);
                Assert.AreEqual(new HashSet<Product>() { p1 }, products.Keys);

                products = this._analytic.GetOrderedByCategory((category)=>categories.Contains(category));
                int totalP1products = products[p1];
                int totalP2products = products[p2];

                Assert.AreEqual(new HashSet<Product>() { p1, p2 }, products.Keys);
                Assert.True(this._analytic.GetOrderedByCategory((category)=>category == Product.Category.SMARTPHONE)[p1] > 0);
                Assert.AreEqual(P1_TOTAL_SOLD, totalP1products);
                Assert.AreEqual(P2_TOTAL_SOLD, totalP2products);

                categories.Add(Product.Category.PC);
                products = this._analytic.GetOrderedByCategory((category)=>categories.Contains(category));
                int totalP3products = products[p3];
                Assert.AreEqual(new HashSet<Product>() { p1, p2, p3, p4 }, products.Keys);
                Assert.AreEqual(P3_TOTAL_SOLD, totalP3products);

                categories.Add(Product.Category.TABLET);
                products = this._analytic.GetOrderedByCategory((category)=>categories.Contains(category));
                Assert.AreEqual(new HashSet<Product>() { p1, p2, p3, p4 }, products.Keys);

                categories.Remove(Product.Category.SMARTPHONE);
                products = this._analytic.GetOrderedByCategory((category)=>categories.Contains(category));
                Assert.AreEqual(new HashSet<Product>() { p2, p3, p4 }, products.Keys);

                categories.Remove(Product.Category.SMARTWATCH);
                products = this._analytic.GetOrderedByCategory((category)=>categories.Contains(category));
                Assert.AreEqual(new HashSet<Product>() { p3, p4 }, products.Keys);

                categories.Remove(Product.Category.PC);
                products = this._analytic.GetOrderedByCategory((category)=>categories.Contains(category));
                Assert.AreEqual(new HashSet<Product>(), products.Keys);;

                categories.Add(Product.Category.TABLET);
                Assert.AreEqual(new HashSet<Product>(), products.Keys);
            }
        /**
         * TEST FOR : analytic.GetOrderedByDate(Predicate<DateTime> c); {@link Analytic}
         *  Testing the method GetProductByDate where we specified a Date or a time lapse,
         *  and we Get a Set of all different products sold in the Date or in the time lapse.
         */
        [Test]
        public void testProductByDate()
            {
                HashSet<DateTime> dates = new HashSet<DateTime>() { TIME_NOW };
                HashSet<Product> products = this._analytic.GetProductByDate((date)=>dates.Contains(date));
                DateTime dateTemp = new DateTime(YEAR_TEST, MONTH_TEST, DAY_TEST);
                DateTime dateTemp2 = new DateTime(YEAR_TEST2, MONTH_TEST, DAY_TEST);
                Sale saleTest = new Sale(dateTemp, new Dictionary<Product, int>(){ [p8] =  1 }, Optional<Client>.Empty());
                Sale saleTest2 = new Sale(dateTemp2, new Dictionary<Product, int>(){ [p1] = 100 }, Optional<Client>.Empty());
                Sale saleTest3 = new Sale(dateTemp2, new Dictionary<Product, int>() { [p2] = 100 }, Optional<Client>.Empty());

                Assert.AreNotEqual(new HashSet<Product>(), products);
                Assert.AreEqual(new HashSet<Product>() { p1, p2, p3, p4, p5, p6, p7 }, products);

                products = this._analytic.GetProductByDate((date)=>date == dateTemp);
                Assert.AreEqual(new HashSet<Product>(), products);

                this._shop.AddSale(saleTest);
                products = this._analytic.GetProductByDate((date)=>date == dateTemp);
                Assert.AreEqual(new HashSet<Product>() { p8 }, products);

                products = this._analytic.GetProductByDate((date)=>date.Year > DateTime.MinValue.Year);
                Assert.AreEqual(new HashSet<Product>() { p1, p2, p3, p4, p5, p6, p7, p8 }, products);

                this._shop.AddSale(saleTest2);
                this._shop.AddSale(saleTest3);
                products = this._analytic.GetProductByDate((date)=>date.Year >= YEAR_TEST && date.Year <= YEAR_TEST2);
                Assert.AreEqual(new HashSet<Product>() { p1, p2, p8 }, products);
            }
        /**
         * TEST FOR : analytic.GetSoldOnDay(Predicate<DateTime> d);{@link Analytic}
         * This method use a Date or a time lapse for return a Map where we find in the key
         * the DateTime and in the Value we find all the different products sold in that day.
         */
        [Test]
    public void testSoldDays()
        {
            HashSet<DateTime> dates = new HashSet<DateTime> { TIME_NOW };
            Dictionary<DateTime, int> products = this._analytic.GetSoldOnDay((date)=>dates.Contains(date));
            DateTime dateTemp = new DateTime(YEAR_TEST, MONTH_TEST, DAY_TEST);
            Sale saleTest = new Sale(dateTemp, new Dictionary<Product, int>(){ [p8] = 1 }, Optional<Client>.Empty());
            int totalProducts = products[DateTime.Now];

            Assert.AreNotEqual(new Dictionary<Product, int>(), products);
            Assert.AreEqual(1, products.Count);
            Assert.AreEqual(TOTAL_SOLD_NOW, totalProducts);

            this._shop.AddSale(saleTest);
            dates.Add(dateTemp);
            products = this._analytic.GetSoldOnDay((date)=>dates.Contains(date));
            totalProducts = products[DateTime.Now];
            Assert.AreNotEqual(new Dictionary<Product, int>(), products);
            Assert.AreEqual(2, products.Count);
            Assert.AreEqual(TOTAL_SOLD_NOW, totalProducts);
        }

        /**
         * TEST FOR : analytic.GetCategoriesSold(); {@link Analytic}
         * This test is for the method GetCategoriesSold, where the method return a Map
         * with Key the category and the Value is all the set of values. 
         */
        [Test]
        public void testCategoriesSold()
            {
                Dictionary<Product.Category, int> categoriesSold = this._analytic.GetCategoriesSold();
                Dictionary<Product.Category, int> testMap = new Dictionary<Product.Category, int>();

                testMap.Add(Product.Category.HOME, 3);
                testMap.Add(Product.Category.PC, 2);
                testMap.Add(Product.Category.SMARTPHONE, 1);
                testMap.Add(Product.Category.SMARTWATCH, 1);

                Assert.AreNotEqual(new Dictionary<Product, int>(), categoriesSold);
                Assert.AreEqual(testMap[Product.Category.HOME], categoriesSold[Product.Category.HOME]);
                Assert.AreEqual(testMap[Product.Category.PC], categoriesSold[Product.Category.PC]);
                Assert.AreEqual(testMap[Product.Category.SMARTPHONE], categoriesSold[Product.Category.SMARTPHONE]);
                Assert.AreEqual(testMap[Product.Category.SMARTWATCH], categoriesSold[Product.Category.SMARTWATCH]);
                Assert.AreEqual(testMap[Product.Category.TABLET], categoriesSold[Product.Category.TABLET]);
            }
        /**
         * TEST FOR : analytic.GetTotalStockPrice(); {@link Analytic}
         * test the stock price of all products.
         */
        [Test]
        public void testTotalStockPrice()
        {
            var dictionary = new Dictionary<Product, int>()
            { 
                [p1] =  10 ,
                [p2] = 10 ,
                [p3] = 3  
            };
            this._shop.Stock.AddProducts(dictionary);
            double total = this._analytic.GetTotalStockPrice();
            double totalCheck = p1.SellingPrice * 10
                        + p2.SellingPrice * 10
                        + p3.SellingPrice * 3;
                Assert.True(total > 0);
                Assert.AreEqual(totalCheck, total, ERROR_TOLLERANCE);
            }
        /**
         * TEST FOR : analytic.GetTotalShopEarned(); {@link Analytic}
         * test where analytic return all the money resulting from sales.
         */
        [Test]
        public void testTotalShopEarned()
            {
                double totalEarned = this._analytic.GetTotalShopEarned();
                Assert.True(totalEarned > 0);
                Assert.AreEqual(TOTAL_SHOP_EARNED, totalEarned, ERROR_TOLLERANCE);
            }
        /**
         * TEST FOR : analytic.GetTotalSpentByYear(); {@link Analytic}
         * test where analytic return a map where we find the year and the total spent in that year.
         */
        [Test]
        public void testTotalSpentByYear()
            {
                Dictionary<int, Double> spentYear = this._analytic.GetTotalSpentByYear();
                double value = spentYear[TIME_NOW.Year];

                Assert.False(spentYear.Count == 0);
                Assert.True(spentYear.ContainsKey(TIME_NOW.Year));
                Assert.AreEqual(TOTAL_SPENT_NOW, value, ERROR_TOLLERANCE);
            }
        /**
         * TEST FOR : analytic.GetTotalEarnedByYear(); {@link Analytic}
         * test where analytic return a Map where we can find in the Key the year and in the value the total earned in that year.
         */
        [Test]
        public void testTotalEarnedByYear()
            {
                Dictionary<int, Double> spentYear = this._analytic.GetTotalEarnedByYear();
                double value = spentYear[TIME_NOW.Year];

                Assert.False(spentYear.Count == 0);
                Assert.True(spentYear.ContainsKey(TIME_NOW.Year));
                Assert.AreEqual(TOTAL_SHOP_EARNED, value, ERROR_TOLLERANCE);
            }
        /**
         *  TEST FOR : analytic.GetTotalEarnedByMonth(Predicate<Integer> year); {@link Analytic}
         *  test where analytic return a Map where we can find in the key the month and in the value the total earned in that month. 
         */
        [Test]
        public void testTotalEarnedByMonth()
            {
                Dictionary<int, Double> totalEarnedMonth = this._analytic.GetTotalEarnedByMonth((year)=>TIME_NOW.Year == year);
                Assert.False(totalEarnedMonth.Count == 0);
                double spentInThisMonth = totalEarnedMonth[TIME_NOW.Month];

                Assert.True(spentInThisMonth > 0);
                Assert.AreEqual(TOTAL_SHOP_EARNED, spentInThisMonth, ERROR_TOLLERANCE);
            }
        /**
         * TEST FOR : analytic.GetTotalSpentByMonth(Predicate<Integer> year); {@link Analytic}
         * test where analytic return a Map where in the Key there is the month and in the value the total spent in that month.
         */
        [Test]
        public void testTotalSpentByMonth()
            {
                Dictionary<int, Double> spentTotalMonth = this._analytic.GetTotalSpentByMonth((year)=>TIME_NOW.Year== year);
                Assert.False(spentTotalMonth.Count == 0);

                double spent = spentTotalMonth[TIME_NOW.Month];

                Assert.True(spent > 0);
                Assert.AreEqual(spent, TOTAL_SPENT_NOW, ERROR_TOLLERANCE);
            }
    }
}