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
        public Dictionary<Product, double> SalableProducts { get; private set; }
        public string Name { get; private set; }

        public Supplier(string name, Dictionary<Product, double> catalog)
        {
            this.SalableProducts = catalog;
            this.Name = name;
        }

        double GetPriceOf(Product product, int amount)
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

        double GetTotalPriceByProducts(Dictionary<Product, int> productsPurchased)
        {
            double totalePrice = 0;
            foreach (Product product in productsPurchased)
            {
                if(!this.SalableProducts.ContainsKey(product))
                {
                    throw new ArgumentException("Some of the products purchased are not saled from this Supplier");
                }
                totalePrice += this.SalableProducts[product] * productsPurchased[product];
            }
            return totalePrice;
        }

        Dictionary<Product, int> SellProduct(Dictionary<Product, int> productsPurchased)
        {
            foreach (Product product in productsPurchased)
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
