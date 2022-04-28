using System;
using System.Collections.Generic;
using System.Text;
using unieuroopSharp.Iorio;

namespace unieuroopSharp.Iorio
{
    interface Analityc
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HashSet<Product> GetTotalProductsSold();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetQuantitySoldOf(Product product);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetQuantitySoldOf(Product product, Predicate<DateTime> date);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<Product, int> GetOrderedByCategory(Predicate<Product.Category> categories);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HashSet<Product> GetProductByDate(Predicate<DateTime> date);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<DateTime, int> GetSoldOnDay(Predicate<DateTime> datePredicate);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<Product.Category, int> GetCategoriesSold();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<int, Double> GetTotalSpentByYear();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<int, Double> GetTotalEarnedByYear();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<int, Double> GetTotalEarnedByMonth(Predicate<int> year);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<int, Double> GetTotalSpentByMonth(Predicate<int> year);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double GetTotalStockPrice();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double GetTotalShopEarned();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double GetTotalAmountSpent();
    }
}
