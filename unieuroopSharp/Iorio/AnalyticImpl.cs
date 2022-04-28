using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using unieuroopSharp.Iorio;

namespace unieuroopSharp.Iorio
{
    class AnalitycImpl : Analityc
    {
        private readonly ShopImpl _shop;

        public AnalitycImpl(ShopImpl shop)
        {
            this._shop = shop;
        }
        private List<Product> getTotal(Product.Category category)
        {
            return this._shop.getSales().AsParallel()
                .SelectMany((sale) => sale.getProducts()
                    .AsParallel().Where((product) => product.Key.getCategory().Equals(category))
                    .Distinct()
                    .ToList();
        }
        public Dictionary<Product.Category, int> getCategoriesSold()
        {
            return this._shop.getSales().AsParallel()
                    .SelectMany((sale) => sale.getProducts().AsParallel().Select((sale2) => sale2.Key))
                    .Distinct()
                    .ToDictionary((product) => product.getCategory(), (product) => this.getTotal(product.getCategory()).Count);
        }

        public Dictionary<Product, int> getOrderedByCategory(Predicate<Product.Category> categories)
        {
            throw new NotImplementedException();
        }

        public HashSet<Product> getProductByDate(Predicate<DateTime> date)
        {
            throw new NotImplementedException();
        }

        public int getQuantitySoldOf(Product product)
        {
            throw new NotImplementedException();
        }

        public int getQuantitySoldOf(Product product, Predicate<DateTime> date)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, int> getSoldOnDay(Predicate<DateTime> datePredicate)
        {
            throw new NotImplementedException();
        }

        public double getTotalAmountSpent()
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, double> getTotalEarnedByMonth(Predicate<int> year)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, double> getTotalEarnedByYear()
        {
            throw new NotImplementedException();
        }

        public HashSet<Product> getTotalProductsSold()
        {
            throw new NotImplementedException();
        }

        public double getTotalShopEarned()
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, double> getTotalSpentByMonth(Predicate<int> year)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, double> getTotalSpentByYear()
        {
            throw new NotImplementedException();
        }

        public double getTotalStockPrice()
        {
            throw new NotImplementedException();
        }
    }
}
