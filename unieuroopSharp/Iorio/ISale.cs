using System;
using System.Collections.Generic;
using System.Text;
using unieuroopSharp.Ferri;
namespace unieuroopSharp.Iorio
{
    interface ISale
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DateTime GetDate();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HashSet<Product> GetProducts();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double GetTotalSpent();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        int GetQuantityOf(Product product);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetTotalQuantity();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Optional<Client> GetClient();
    }
}
