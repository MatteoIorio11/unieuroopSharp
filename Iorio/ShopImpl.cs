using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopCSharp1
{
    class ShopImpl
    {
        private readonly HashSet<SaleImpl> _sales;

        public HashSet<SaleImpl> getSales()
        {
            return new HashSet<SaleImpl>(this._sales);
        }
    }
}
