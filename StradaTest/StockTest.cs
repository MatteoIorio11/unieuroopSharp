using NUnit.Framework;
using Microsoft.VisualStudio.TestPlatform;
using unieuroopSharp.Iorio;
using unieuroopSharp.Ferri;
using unieuroopSharp.Vincenzi;
using System;
using System.Linq;
using System.Collections.Generic;

namespace StradaTest
{
    public class Tests
    {
        private static readonly String APPLE_PRODUCT = "Apple";
        private static readonly String IPHONE_13_PRO = "Iphone 13 Pro";
        private static readonly String APPLEWATCH = "Applewatch";
        private static readonly String MAC_BOOK_14 = "MacBook Pro 14 ";
        private static readonly String DESCRIPTION_P1 = "Best Phone Ever";
        private static readonly String DESCRIPTION_P2 = "Best Phone Ever Created";
        private static readonly String DESCRIPTION_P3 = "Best MacBook Ever Created";
        private readonly Shop shop = new ShopImpl("Shop Test");

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