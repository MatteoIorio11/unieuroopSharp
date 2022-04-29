using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using unieuroopSharp.Iorio;

namespace unieuroopSharp.Iorio
{
    public class Analityc : IAnalityc
    {
        private readonly ShopImpl _shop;

        public Analityc(ShopImpl shop)
        {
            this._shop = shop;
        }

        private List<Product> GetTotal(Product.Category category)
        {
            return this._shop.GetSales().AsParallel()
                .SelectMany((sale) => sale.GetProducts()
                    .AsParallel().Where((product) => product.GetCategory().Equals(category)))
                    .Distinct()
                    .ToList();
        }
        public Dictionary<Product.Category, int> GetCategoriesSold()
        {
            return this._shop.GetSales().AsParallel()
                    .SelectMany((sale) => sale.GetProducts().AsParallel())
                    .Distinct()
                    .ToDictionary((product) => product.GetCategory(),
                        (product) => this.GetTotal(product.GetCategory()).Count);
        }

        public Dictionary<Product, int> GetOrderedByCategory(Predicate<Product.Category> categories)
        {
            return this._shop.GetSales().AsParallel()
                .SelectMany((sale) => sale.GetProducts().AsParallel()
                    .Where((product) => categories.Invoke(product.GetCategory())))
                .Distinct()
                .OrderBy((product) => product.GetName())
                .ToDictionary((product) => product, (product) => this.GetQuantitySoldOf(product));
        }

        public HashSet<Product> GetProductByDate(Predicate<DateTime> date)
        {
            return this._shop.GetSales(date)
                    .SelectMany((sale) => sale.GetProducts().AsParallel())
                    .Distinct()
                    .OrderBy((product) => product.GetName())
                    .ToHashSet();
        }

        public int GetQuantitySoldOf(Product product)
        {
            return this._shop.GetSales().AsParallel()
                .SelectMany((sale) => sale.GetProducts().AsParallel()
                    .Where((productParallel) => product.Equals(productParallel))
                    .Select((product) => sale.GetQuantityOf(product)))
                .Sum();
        }

        public int GetQuantitySoldOf(Product product, Predicate<DateTime> date)
        {
            return this._shop.GetSales().AsParallel()
                .Where((sale) => date.Invoke(sale.GetDate()))
                .SelectMany((sale) => sale.GetProducts().AsParallel()
                    .Where((productParallel) => product.Equals(productParallel))
                    .Select((productParallel) => sale.GetQuantityOf(productParallel)))
                .Sum();
        }

        private int TotalQuantitySold(DateTime date)
        {
            return this._shop.GetSales((dateStream) => dateStream.Equals(date)).AsParallel()
                .Select((sale) => sale.GetTotalQuantity())
                .Sum();
        }

        public Dictionary<DateTime, int> GetSoldOnDay(Predicate<DateTime> datePredicate)
        {
            return this._shop.GetSales(datePredicate).AsParallel()
                .Select((sale) => sale.GetDate())
                .Distinct()
                .OrderBy((date) => date)
                .ToDictionary((date) => date, (date) => this.TotalQuantitySold(date));
        }

        public double GetTotalAmountSpent()
        {
            return -1;
        }

        private double SpentInMonth(int month, Predicate<int> year)
        {
            return this._shop.GetSales().AsParallel()
                .Where((sale) => sale.GetDate().Month == month && year.Invoke(sale.GetDate().Year))
                .Select((sale) => sale.GetTotalSpent())
                .Sum();
        }

        public Dictionary<int, double> GetTotalEarnedByMonth(Predicate<int> year)
        {
            return this._shop.GetSales().AsParallel()
                .Where((sale) => year.Invoke(sale.GetDate().Year))
                .Select((sale) => sale.GetDate().Month)
                .Distinct()
                .ToDictionary((month) => month, (month) => this.SpentInMonth(month, year));
        }

        private double EarnedInYear(int year)
        {
            return this._shop.GetSales().AsParallel()
                .Where((sale) => sale.GetDate().Year == year)
                .Select((sale) => sale.GetTotalSpent())
                .Sum();
        }

        public Dictionary<int, double> GetTotalEarnedByYear()
        {
            return this._shop.GetSales().AsParallel()
                .Select((sale) => sale.GetDate().Year)
                .Distinct()
                .ToDictionary((year) => year, (year) => this.EarnedInYear(year));
        }

        public HashSet<Product> GetTotalProductsSold()
        {
            return this._shop.GetSales().AsParallel()
                .SelectMany((sale) => sale.GetProducts().AsParallel())
                .Distinct()
                .OrderBy((product) => product.GetName())
                .ToHashSet();
        }

        public double GetTotalShopEarned()
        {
            return this._shop.GetSales().AsParallel()
                .Select((sale) => sale.GetTotalSpent())
                .Sum();
        }

        public Dictionary<int, double> GetTotalSpentByMonth(Predicate<int> year)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, double> GetTotalSpentByYear()
        {
            throw new NotImplementedException();
        }

        public double GetTotalStockPrice()
        {
            throw new NotImplementedException();
        }
    }
}
