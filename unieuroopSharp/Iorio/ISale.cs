using System;
using System.Collections.Generic;
using System.Text;
using unieuroopSharp.Ferri;
using unieuroopSharp.Vincenzi;

namespace unieuroopSharp.Iorio
{
    public interface ISale
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>the specific Date of the sale</returns>
        DateTime GetDate();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>the copy of all products buyed, stored in a Set</returns>
        HashSet<IProduct> GetProducts();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>the total price of the sale</returns>
        double GetTotalSpent();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns>the total quantity of the specified product, if the product is not contained, 
        /// It return 0</returns>
        int GetQuantityOf(IProduct product);
        /// <summary>
        /// 
        /// </summary>
        /// <returns>the sum of all Product's quantity.</returns>
        int GetTotalQuantity();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>the client of this specific Sale, is optional</returns>
        Optional<IClient> GetClient();
    }
}
