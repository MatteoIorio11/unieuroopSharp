using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopCSharp1
{
    class AnalitycImpl : Analityc
    {
        public Dictionary<Product.Category, int> getCategoriesSold()
        {
            throw new NotImplementedException();
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
