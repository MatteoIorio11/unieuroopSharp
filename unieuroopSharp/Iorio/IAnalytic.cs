using System;
using System.Collections.Generic;
using System.Text;
using unieuroopSharp.Iorio;

namespace unieuroopSharp.Iorio
{
    interface IAnalityc
    {
        /// <summary>
        /// This method has to return the Set of all product sold in the shop.
        /// </summary>
        /// <returns> all the product sold in all the different sales </returns>
        HashSet<Product> GetTotalProductsSold();
        /// <summary>
        ///  This method is used to get the quantity sold of a specific product.
        /// </summary>
        /// <param name="product"> product </param>
        /// <returns> the total quantity sold of the "product"</returns>
        int GetQuantitySoldOf(Product product);
        /// <summary>
        /// This method return all the quantity sold of a specific product in a specific date.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="date"></param>
        /// <returns> all the quantity of a single product sold in Date.</returns>
        int GetQuantitySoldOf(Product product, Predicate<DateTime> date);
        /// <summary>
        /// This method returns the Map with only the products that are positive to the predicate's test.
        /// </summary>
        /// <param name="categories">specifies which categories we have to consider</param>
        /// <returns> a Dictionary that contains all the Product of the specified categories with their quantity </returns>
        Dictionary<Product, int> GetOrderedByCategory(Predicate<Product.Category> categories);
        /// <summary>
        /// All the products sold in date, it can be also in a range like: x between 02/11/2022 and 10/27/2022.
        /// </summary>
        /// <param name="date"> specifies which dates we have to consider</param>
        /// <returns> the Set of all products sold in the specific date</returns>
        HashSet<Product> GetProductByDate(Predicate<DateTime> date);
        /// <summary>
        /// This method return the a Map contains a LocalDate and a Set of all products sold in that day.
        /// </summary>
        /// <param name="datePredicate"> specifies which dates we have to consider</param>
        /// <returns> a Dictionary with key a Date and value the Set of all products sold in that specific day</returns>
        Dictionary<DateTime, int> GetSoldOnDay(Predicate<DateTime> datePredicate);
        /// <summary>
        ///  This method return all categories sold with the complete Set of all product .
        /// </summary>
        /// <returns> the Dictionary contains the Category and the complete Set of all product sold of that specific Category</returns>
        Dictionary<Product.Category, int> GetCategoriesSold();
        /// <summary>
        ///  This method return the sum of all bills in the same year.
        /// </summary>
        /// <returns>a Dictionary where the Key is the Year and in the Value we can find the total spent in that year.</returns>
        Dictionary<int, Double> GetTotalSpentByYear();
        /// <summary>
        /// This method calculate the total Earned in one year.
        /// </summary>
        /// <returns>a Dictionary where the key is Year and the Value is the sum of all sales by that year</returns>
        Dictionary<int, Double> GetTotalEarnedByYear();
        /// <summary>
        /// This method calculate the total Earned in one year.
        /// </summary>
        /// <returns>a Dictionary where the key is Year and the Value is the sum of all sales by that year</returns>
        Dictionary<int, Double> GetTotalEarnedByMonth(Predicate<int> year);
        /// <summary>
        /// This method calculate the total spent in a specific Month by the year/years in the predicate.
        /// </summary>
        /// <param name="year">which year we have to consider</param>
        /// <returns>a Map where the Key is the Month and the Value is the sum of all spent in that month.</returns>
        Dictionary<int, Double> GetTotalSpentByMonth(Predicate<int> year);
        /// <summary>
        /// 
        /// </summary>
        /// <returns> the total value of all products inside the stock</returns>
        double GetTotalStockPrice();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>all the total value of all sales</returns>
        double GetTotalShopEarned();
        /// <summary>
        /// 
        /// </summary>
        /// <returns> the total spent in the Shop</returns>
        double GetTotalAmountSpent();
    }
}
