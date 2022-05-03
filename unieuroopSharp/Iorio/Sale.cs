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

        public Optional<Client> GetClient() => this._client;

        public DateTime GetDate() => this._date;

        public HashSet<Product> GetProducts() => this._products.AsParallel().Select((entry) => entry.Key).ToHashSet();

        public int GetQuantityOf(Product product) => this._products.ContainsKey(product) ? this._products[product] : 0;

        public int GetTotalQuantity() => this._products.Values.AsParallel().Sum();

        public double GetTotalSpent() => this._products.AsParallel().Select((entry) => entry.Key.SellingPrice * entry.Value).Sum();

        public override string ToString()
        {
            String clientString = this._client.IsEmpty ? " Not a Registered Client" : this._client.Get.ToString(); ;
            String date = " date : " + this._date;
            String totalEarned = this.GetTotalSpent() + " euros ";
            return date + " " + totalEarned + " Client : " + clientString;
        }
    }
}
