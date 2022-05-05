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
        private readonly Dictionary<IProduct, int> _products;
        private readonly Optional<IClient> _client;
        private readonly DateTime _date;
        public Sale(DateTime date, Dictionary<IProduct, int> products, Optional<IClient> client)
        {
            this._date = date;
            this._products = new Dictionary<IProduct, int>(products);
            this._client = client;
        }

        public Optional<IClient> GetClient() => this._client;

        public DateTime GetDate() => this._date;

        public HashSet<IProduct> GetProducts() => this._products.Select((entry) => entry.Key).ToHashSet();

        public int GetQuantityOf(IProduct product) => this._products.ContainsKey(product) ? this._products[product] : 0;

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
