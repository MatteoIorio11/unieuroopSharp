using System;
using System.Collections.Generic;
using System.Text;
using unieuroopSharp.Iorio;

namespace unieuroopSharp.Iorio
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
