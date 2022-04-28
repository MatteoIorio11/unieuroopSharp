using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopSharp.Iorio
{
    class SaleImpl : Sale
    {
        private readonly Dictionary<Product, int> _products;
        private readonly int? _client;
        private readonly DateTime _date;
        public SaleImpl(DateTime date, Dictionary<Product, int> products, int client)
        {
            this._date = date;
            this._products = new Dictionary<Product, int>(products);
            this._client = client;
        }

        public int GetClient()
        {
            throw new NotImplementedException();
        }

        public DateTime GetDate()
        {
            throw new NotImplementedException();
        }

        public HashSet<Product> GetProducts()
        {
            return new HashSet<Product>(this._products.Keys);
        }

        public int GetQuantityOf(Product product)
        {
            throw new NotImplementedException();
        }

        public int GetTotalQuantity()
        {
            throw new NotImplementedException();
        }

        public double GetTotalSpent()
        {
            throw new NotImplementedException();
        }
    }
}
