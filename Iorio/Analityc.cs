
using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopCSharp1
{
    interface Analityc
    {
        HashSet<Product> getTotalProductsSold();
        int getQuantitySoldOf(Product product);
        int getQuantitySoldOf(Product product, Predicate<DateTime> date);
        Dictionary<Product, int> getOrderedByCategory(Predicate<Product.Category> categories);
        HashSet<Product> getProductByDate(Predicate<DateTime> date);
        Dictionary<DateTime, int> getSoldOnDay(Predicate<DateTime> datePredicate);
        Dictionary<Product.Category, int> getCategoriesSold();
        Dictionary<int, Double> getTotalSpentByYear();
        Dictionary<int, Double> getTotalEarnedByYear();
        Dictionary<DateTime.Month, Double> getTotalEarnedByMonth(Predicate<int> year);

    }
}
