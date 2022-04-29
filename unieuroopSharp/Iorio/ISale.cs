using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopSharp.Iorio
{
    interface ISale
    {
        DateTime GetDate();
        HashSet<Product> GetProducts();
        double GetTotalSpent();
        int GetQuantityOf(Product product);
        int GetTotalQuantity();
        Client GetClient();
    }
}
