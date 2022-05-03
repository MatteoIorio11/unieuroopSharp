using NUnit.Framework;
using System;
using System.Collections.Generic;
using unieuroopSharp.Ferri;
using unieuroopSharp.Vincenzi;
using static unieuroopSharp.Vincenzi.Product;

namespace VincenziTest
{
    public class Tests
    {
        private readonly static string ERROR_MESSAGE = "ERROR : exception must be throwned";
        private readonly static string APPLE_PRODUCT = "APPLE"; /*Brand of products*/
        private readonly static DateTime DATE_NOW = DateTime.Now;
        private readonly static DateTime TIME_START = DateTime.Now;
        private readonly static DateTime TIME_FINISH = DateTime.Now;
        private readonly IDepartment department1;
        private readonly IDepartment department2;
        private readonly IDepartment department3;
        private readonly IShop shop01;
        private readonly HashSet<Department> departments = new HashSet<Department>();
        /**
         * ALL THE STAFF THAT WILL BE USED IN THIS TEST.
         */
        private readonly Staff staff1 = new Staff("Nome1", "Cognome1", DATE_NOW,
                "a", "email1@gmail.com", 111, new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>()
                {
                    {DayOfWeek.Monday,new KeyValuePair<DateTime, DateTime>(TIME_START, TIME_FINISH)}
                });
        private readonly Staff staff2 = new Staff("Nome2", "Cognome2", DATE_NOW,
                "b", "email2@gmail.com", 222, new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>()
                {
                    {DayOfWeek.Monday,new KeyValuePair<DateTime, DateTime>(TIME_START, TIME_FINISH)}
                });
        private readonly Staff staff3 = new Staff("Nome3", "Cognome3", DATE_NOW,
                "c", "email1@gmail.com", 333, new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>()
                {
                    {DayOfWeek.Monday,new KeyValuePair<DateTime, DateTime>(TIME_START, TIME_FINISH)}
                });
        private readonly Staff staff4 = new Staff("Nome4", "Cognome4", DATE_NOW,
                "d", "email4@gmail.com", 444, new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>()
                {
                    {DayOfWeek.Monday,new KeyValuePair<DateTime, DateTime>(TIME_START, TIME_FINISH)}
    /*
      ALL THE PRODUCTS THAT WILL BE USED IN THIS TEST.
     */
    private readonly Product p1 = new Product(1, "iphone 13 pro", APPLE_PRODUCT,  1200.00,  900.00, "best phone ever created", Category.SMARTPHONE);
        private readonly Product p2 = new Product(2, "applewatch", APPLE_PRODUCT, 500.00,  200.00, "best watch ever created", Category.SMARTWATCH);
        private readonly Product p3 = new Product(3, "mac book pro 14 ", APPLE_PRODUCT,  3000.00, 2000.00, "best mac book ever created", Category.PC);
        private readonly Product p4 = new Product(4, "mac book pro 16", APPLE_PRODUCT,  6000.00,  3000.00, "best mac book ever created", Category.PC);

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