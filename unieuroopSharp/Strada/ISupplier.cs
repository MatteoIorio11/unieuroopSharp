using System;
using System.Collections.Generic;
using System.Text;
using unieuroopSharp.Strada;
using unieuroopSharp.Vincenzi;

namespace unieuroopSharp.Strada
{
    public interface ISupplier
    {
        /// <summary>
        /// Return the price of the product by their quantities.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        /// <returns> ProductPrice returns>
        double GetPriceOf(Product product, int amount);

        /// <summary>
        /// Return the total prices of the products purchased.
        /// </summary>
        /// <param name="productsPurchased"> Dictiobary of Products purchase from the Supplier </param>
        /// <returns> TotalPrice </returns>
        double GetTotalPriceByProducts(Dictionary<Product, int> productsPurchased);

        /// <summary>
        /// Sell given products.
        /// </summary>
        /// <param name="productsPurchased"> All the products bought from the Supplier </param>
        /// <returns> productsPurchased from the Supplier </returns>
        Dictionary<Product, int> SellProduct(Dictionary<Product, int> productsPurchased);
    }
}
