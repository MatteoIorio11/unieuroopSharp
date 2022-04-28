using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopSharp.Iorio
{
    interface Sale
    {
        DateTime GetDate();
        HashSet<Product> GetProducts();
        double GetTotalSpent();
        int GetQuantityOf(Product product);
        int GetTotalQuantity();
        int GetClient();
    }
}
