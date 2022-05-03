using System;
using System.Collections.Generic;
using System.Text;
using unieuroopSharp.Strada;
using unieuroopSharp.Vincenzi;

namespace unieuroopSharp.Strada
{
    interface IStock
    {
        /// <summary>
        ///  This method is used to get the quantity sold of a specific product.
        /// </summary>
        /// <param name="products"> products </param>
        /// <returns> </returns>
        void AddProducts(Dictionary<Product, int> products);

        /// <summary>
        ///  Return the entire Stock.
        /// </summary>
        /// <returns> The total Stock of Products and Quantities  "prducts" </returns>
        Dictionary<Product, int> GetTotalStock();

        /// <summary>
        /// Return the Dictionary of the products taken from the stock, then they will be putted in the Department.
        /// </summary>
        /// <param name="productsTaken"></param>
        /// <returns> productsTaken returns>
        Dictionary<Product, int> TakeFromStock(Dictionary<Product, int> productsTaken);

        /// <summary>
        /// Permanent delete a set of Products.
        /// </summary>
        /// <param name="productsDelete"> Set of products to permanent delete </param>
        /// <returns> productsDelete </returns>
        void DeleteProducts(HashSet<Product> productsDelete);

        /// <summary>
        /// Return the products filter by a Predicate with a KeyValuePair of Quantity and category.
        /// </summary>
        /// <param name="filter"> </param>
        /// <returns> List of FilteredProducts </returns>
        List<Product> GetFilterProducts(Predicate<KeyValuePair<int, Product.Category>> filter);

        /// <summary>
        ///  Return the list of products sorted by increasing or decreasing.
        /// </summary>
        /// <param name="sorting"> specifies how to sort the list of Products returned </param>
        /// <returns> List of Products sorted </returns>
        List<Product> GetProductsSorted(Comparer<Product> sorting);

        /// <summary>
        ///  Return the max amount of a product present in the Stock.
        /// </summary>
        /// <returns> MaxAmount of a product's quantities in the Stock </returns>
        int GetMaxAmountOfProducts();
    }
}
