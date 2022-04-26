
using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopCSharp1
{
    interface Analityc
    {
        HashSet<Product> getTotalProductsSold();
        int getQuantitySoldOf(Product product);
        int getQuantitySoldOf(Product product, Predicate<DateTime> date);

    }
}
