using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using unieuroopSharp.Strada;
using unieuroopSharp.Vincenzi;

namespace unieuroopSharp.Strada
{
    public class Supplier : ISupplier
    {
        public Dictionary<IProduct, double> SalableProducts { get; private set; }
        public string Name { get; private set; }

        public Supplier(string name, Dictionary<IProduct, double> catalog)
        {
            this.SalableProducts = catalog;
            this.Name = name;
        }

        public double GetPriceOf(IProduct product, int amount)
        {
            if(this.SalableProducts.ContainsKey(product))
            {
                return this.SalableProducts[product] * amount;
            }
            else
            {
                throw new ArgumentException("The product is not saled from this Supplier");
            }
        }

        public double GetTotalPriceByProducts(Dictionary<IProduct, int> productsPurchased)
        {
            double totalePrice = 0;
            foreach (IProduct product in productsPurchased.Keys)
            {
                if(!this.SalableProducts.ContainsKey(product))
                {
                    throw new ArgumentException("Some of the products purchased are not saled from this Supplier");
                }
                totalePrice += this.SalableProducts[product] * productsPurchased[product];
            }
            return totalePrice;
        }

        public Dictionary<IProduct, int> SellProduct(Dictionary<IProduct, int> productsPurchased)
        {
            foreach (IProduct product in productsPurchased.Keys)
            {
                if(!this.SalableProducts.ContainsKey(product))
                {
                    throw new ArgumentException("Some of the products purchased are not saled from this Supplier");
                }
            }
            return productsPurchased;
        }
    }
}
