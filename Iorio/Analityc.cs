
using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopCSharp1
{
    interface Analityc
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HashSet<Product> getTotalProductsSold();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int getQuantitySoldOf(Product product);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int getQuantitySoldOf(Product product, Predicate<DateTime> date);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<Product, int> getOrderedByCategory(Predicate<Product.Category> categories);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HashSet<Product> getProductByDate(Predicate<DateTime> date);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<DateTime, int> getSoldOnDay(Predicate<DateTime> datePredicate);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<Product.Category, int> getCategoriesSold();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<int, Double> getTotalSpentByYear();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<int, Double> getTotalEarnedByYear();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<DateTime, Double> getTotalEarnedByMonth(Predicate<int> year);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<DateTime, Double> getTotalSpentByMonth(Predicate<int> year);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double getTotalStockPrice();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double getTotalShopEarned();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double getTotalAmountSpent();
    }
}
