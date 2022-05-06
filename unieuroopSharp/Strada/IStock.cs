using System;
using System.Collections.Generic;
using System.Text;
using unieuroopSharp.Strada;
using unieuroopSharp.Vincenzi;

namespace unieuroopSharp.Strada
{
    public interface IStock
    {
        /// <summary>
        ///  This method is used to add products in the Stock.
        /// </summary>
        /// <param name="products"> products </param>
        /// <returns> </returns>
        void AddProducts(Dictionary<IProduct, int> products);

        /// <summary>
        ///  This method return the quantity of a product.
        /// </summary>
        /// <param name="products"> product </param>
        /// <returns> Quantity of Product </returns>
        int GetQuantityOfProduct(IProduct product);

        /// <summary>
        ///  Return the entire Stock.
        /// </summary>
        /// <returns> The total Stock of Products and Quantities  "prducts" </returns>
        Dictionary<IProduct, int> GetTotalStock();

        /// <summary>
        /// Return the Dictionary of the products taken from the stock, then they will be putted in the Department.
        /// </summary>
        /// <param name="productsTaken"></param>
        /// <returns> productsTaken returns>
        Dictionary<IProduct, int> TakeFromStock(Dictionary<IProduct, int> productsTaken);

        /// <summary>
        /// Permanent delete a set of Products.
        /// </summary>
        /// <param name="productsDelete"> Set of products to permanent delete </param>
        /// <returns> productsDelete </returns>
        void DeleteProducts(HashSet<IProduct> productsDelete);

        /// <summary>
        /// Return the products filter by a Predicate with a KeyValuePair of Quantity and category.
        /// </summary>
        /// <param name="filter"> </param>
        /// <returns> List of FilteredProducts </returns>
        List<IProduct> GetFilterProducts(Predicate<KeyValuePair<int, Product.Category>> filter);

        /// <summary>
        ///  Return the list of products sorted by increasing or decreasing.
        /// </summary>
        /// <param name="sorting"> specifies how to sort the list of Products returned </param>
        /// <returns> List of Products sorted </returns>
        List<IProduct> GetProductsSorted(Comparer<IProduct> sorting);

        /// <summary>
        ///  Return the max amount of a product present in the Stock.
        /// </summary>
        /// <returns> MaxAmount of a product's quantities in the Stock </returns>
        int GetMaxAmountOfProducts();
    }
}
