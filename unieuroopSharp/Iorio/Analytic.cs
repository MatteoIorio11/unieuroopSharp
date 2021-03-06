using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using unieuroopSharp.Iorio;
using unieuroopSharp.Vincenzi;

namespace unieuroopSharp.Iorio
{
    public class Analityc : IAnalityc
    {
        private readonly IShop _shop;

        public Analityc(IShop shop)
        {
            this._shop = shop;
        }

        private List<IProduct> GetTotal(Product.Category category)
        {
            return this._shop.Sales.SelectMany((sale) => sale.GetProducts().Select((product)=> product as IProduct)
                    .Where((product) => product.ProductCategory.Equals(category)))
                    .Distinct()
                    .ToList();
        }
        public Dictionary<Product.Category, int> GetCategoriesSold()
        {
            return this._shop.Sales.SelectMany((sale) => sale.GetProducts()
                        .Select((product)=>product.ProductCategory)
                        .Distinct())
                    .Distinct()
                    .ToDictionary((category) => category,
                        (category) => this.GetTotal(category).Count);
        }

        public Dictionary<IProduct, int> GetOrderedByCategory(Predicate<Product.Category> categories)
        {
            return this._shop.Sales.AsEnumerable().SelectMany((sale) => sale.GetProducts().AsEnumerable().Select((product)=> product as IProduct)
                    .Where((product) => categories.Invoke(product.ProductCategory)))
                .Distinct()
                .OrderBy((product) => product.Name)
                .ToDictionary((product) => product, (product) => this.GetQuantitySoldOf(product));
        }

        public HashSet<IProduct> GetProductByDate(Predicate<DateTime> date)
        {
            return this._shop.Sales.Where((sale) => date.Invoke(sale.GetDate()))
                    .SelectMany((sale) => sale.GetProducts().Select((product) => product as IProduct))
                    .Distinct()
                    .OrderBy((product) => product.Name)
                    .ToHashSet();
        }

        public int GetQuantitySoldOf(IProduct product)
        {
            return this._shop.Sales.SelectMany((sale) => sale.GetProducts().AsEnumerable()
                    .Where((productParallel) => product.Equals(productParallel))
                    .Select((product) => sale.GetQuantityOf(product)))
                .Sum();
        }

        public int GetQuantitySoldOf(IProduct product, Predicate<DateTime> date)
        {
            return this._shop.Sales.Where((sale) => date.Invoke(sale.GetDate()))
                .SelectMany((sale) => sale.GetProducts().Where((productParallel) => product.Equals(productParallel))
                    .Select((productParallel) => sale.GetQuantityOf(productParallel)))
                .Sum();
        }

        private int TotalQuantitySold(DateTime date)
        {
            return this._shop.Sales.Where((sale) => date.Equals(sale.GetDate()))
                .Select((sale) => sale.GetTotalQuantity())
                .Sum();
        }

        public Dictionary<DateTime, int> GetSoldOnDay(Predicate<DateTime> datePredicate)
        {
            return this._shop.Sales.AsEnumerable().Where((sale) => datePredicate.Invoke(sale.GetDate()))
                .Select((sale) => sale.GetDate())
                .Distinct()
                .OrderBy((date) => date)
                .ToDictionary((date) => date, (date) => this.TotalQuantitySold(date));
        }

        public double GetTotalAmountSpent()
        {
            return this._shop.Bills.Select((entry) => entry.Value)
                .Sum();
        }

        private double SpentInMonth(int month, Predicate<int> year)
        {
            return this._shop.Bills.AsEnumerable().Where((bill) => bill.Key.Month == month && year.Invoke(bill.Key.Year))
                .Select((bill) => bill.Value)
                .Sum();
        }

        private double EarnedInMonth(int month, Predicate<int> year)
        {
            return this._shop.Sales.Where((sale) => sale.GetDate().Month == month && year.Invoke(sale.GetDate().Year))
                .Select((sale) => sale.GetTotalSpent())
                .Sum();
        }

        public Dictionary<int, double> GetTotalEarnedByMonth(Predicate<int> year)
        {
            return this._shop.Sales.Where((sale) => year.Invoke(sale.GetDate().Year))
                .Select((sale) => sale.GetDate().Month)
                .Distinct()
                .ToDictionary((month) => month, (month) => this.EarnedInMonth(month, year));
        }

        private double EarnedInYear(int year)
        {
            return this._shop.Sales.Where((sale) => sale.GetDate().Year == year)
                .Select((sale) => sale.GetTotalSpent())
                .Sum();
        }

        public Dictionary<int, double> GetTotalEarnedByYear()
        {
            return this._shop.Sales.Select((sale) => sale.GetDate().Year)
                .Distinct()
                .ToDictionary((year) => year, (year) => this.EarnedInYear(year));
        }

        public HashSet<IProduct> GetTotalProductsSold()
        {
            return this._shop.Sales.SelectMany((sale) => sale.GetProducts().Select((product) => product as IProduct))
                .Distinct()
                .OrderBy((product) => product.Name)
                .ToHashSet();
        }

        public double GetTotalShopEarned()
        {
            return this._shop.Sales.Select((sale) => sale.GetTotalSpent())
                .Sum();
        }

        public Dictionary<int, double> GetTotalSpentByMonth(Predicate<int> year)
        {
            return this._shop.Bills.Where((entry) => year.Invoke(entry.Key.Year))
                    .Select((entry) => entry.Key.Month)
                    .Distinct()
                    .ToDictionary((month) => month, (month) => this.SpentInMonth(month, year));
        }

        private double SpentInYear(int year)
        {
            return this._shop.Bills.Where((entry)=>entry.Key.Year == year)
                   .Select((entry)=>entry.Value)
                   .Sum();
        }

        public Dictionary<int, double> GetTotalSpentByYear()
        {
            return this._shop.Bills.Select((entry)=>entry.Key.Year)
                            .Distinct()
                            .ToDictionary((year) => year, (year) => this.SpentInYear(year)); 
        }

        public double GetTotalStockPrice()
        {
            return this._shop.Stock.GetTotalStock().AsEnumerable().Select((entry)=>entry.Key.SellingPrice* entry.Value)
                     .Sum();
        }
    }
}
