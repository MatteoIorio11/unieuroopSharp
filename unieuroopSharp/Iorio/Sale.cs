using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using unieuroopSharp.Ferri;
using unieuroopSharp.Vincenzi;

namespace unieuroopSharp.Iorio
{
    public class Sale : ISale
    {
        private readonly Dictionary<Product, int> _products;
        private readonly Optional<Client> _client;
        private readonly DateTime _date;
        public Sale(DateTime date, Dictionary<Product, int> products, Optional<Client> client)
        {
            this._date = date;
            this._products = new Dictionary<Product, int>(products);
            this._client = client;
        }

        public Optional<Client> GetClient()
        {
            return this._client;
        }

        public DateTime GetDate()
        {
            return this._date;
        }

        public HashSet<Product> GetProducts()
        {
            return new HashSet<Product>(this._products.Keys);
        }

        public int GetQuantityOf(Product product)
        {
            return this._products.ContainsKey(product) ? this._products[product] : 0;
        }

        public int GetTotalQuantity()
        {
            return this._products.Values.AsParallel()
                .Sum();
        }

        public double GetTotalSpent()
        {
            return this._products.AsParallel()
                .Select((entry) => entry.Key.GetSellingPrice() * entry.Value)
                .Sum();

        }

        public override string ToString()
        {
            String clientString = this._client.IsEmpty ? " Not a Registered Client" : this._client.Get.ToString(); ;
            String date = " date : " + this._date;
            String totalEarned = this.GetTotalSpent() + " euros ";
            return date + " " + totalEarned + " Client : " + clientString;
        }
    }
}
