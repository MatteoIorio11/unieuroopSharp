using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using unieuroopSharp.Iorio;

namespace unieuroopSharp.Iorio
{
    class ShopImpl
    {
        private readonly HashSet<SaleImpl> _sales;

        public HashSet<SaleImpl> GetSales()
        {
            return new HashSet<SaleImpl>(this._sales);
        }
        public HashSet<SaleImpl> GetSales(Predicate<DateTime> predicate)
        {
            return this._sales.AsParallel()
                .Where((sale) => predicate.Invoke(sale.GetDate()))
                .ToHashSet();
        }
    }
}
