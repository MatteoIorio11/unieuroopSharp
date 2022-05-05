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
        private readonly IShop shop = new Shop("Shop Test");

        private readonly IProduct product1 = new Product(1, IPHONE_13_PRO, APPLE_PRODUCT,  1200.00,  900.00, DESCRIPTION_P1, Product.Category.SMARTPHONE);
        private readonly IProduct product2 = new Product(2, APPLEWATCH, APPLE_PRODUCT, 500.00,  200.00, DESCRIPTION_P2, Product.Category.SMARTWATCH);
        private readonly IProduct product3 = new Product(3, MAC_BOOK_14, APPLE_PRODUCT,  3000.00, 2000.00, DESCRIPTION_P3, Product.Category.PC);
        private readonly IProduct product4 = new Product(4, MAC_BOOK_16, APPLE_PRODUCT,  6000.00,  3000.00, DESCRIPTION_P3, Category.PC);
        private readonly IProduct product5 = new Product(5, IPAD_AIR, APPLE_PRODUCT,  700.00,  300.00, DESCRIPTION_P4, Category.HOME);
        private readonly IProduct product6 = new Product(6, IPAD_PRO, APPLE_PRODUCT, 1000.00, 500.00, DESCRIPTION_P4, Category.HOME);
        private readonly IProduct product7 = new Product(7, SAMSUNG_S7, SAMSUNG_PRODUCT, 1200.00,  900.00, "best ipad pro max ever created", Category.HOME);

        /**
         * ALL THE SALES THAT WILL BE USED IN THIS TEST.
        */

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}