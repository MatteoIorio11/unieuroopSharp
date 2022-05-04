using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using unieuroopSharp.Strada;
using unieuroopSharp.Vincenzi;

namespace unieuroopSharp.Strada
{
    public class Stock : IStock
    {
        private readonly Dictionary<Product, int> _productsStocked;

        public void AddProducts(Dictionary<Product, int> products)
        {
            foreach (Product product in products.Keys)
            {
                if (this._productsStocked.ContainsKey(product))
                {
                    this._productsStocked[product] += products[product];
                }
                else
                {
                    this._productsStocked.Add(product, products[product]);
                }
            }
        }

        public Dictionary<Product, int> GetTotalStock()
        {
            return new Dictionary<Product, int>(this._productsStocked);
        }

        public Dictionary<Product, int> TakeFromStock(Dictionary<Product, int> productsTaken)
        {
            if (!this.CheckProductsTaken(productsTaken))
            {
                throw new ArgumentException("Some products can not be taken");
            }
            foreach (Product productTaken in productsTaken.Keys)
            {
                this._productsStocked[productTaken] -= productsTaken[productTaken];
            }
            return productsTaken;
        }

        public void DeleteProducts(HashSet<Product> productsDelete)
        {
            foreach (Product product in productsDelete)
            {
                if (!this._productsStocked.ContainsKey(product))
                {
                    throw new ArgumentException("Some products can not be Deleted");
                }
            }
            foreach (Product product in productsDelete)
            {
                this._productsStocked.Remove(product);
            }
        }

        public List<Product> GetFilterProducts(Predicate<KeyValuePair<int, Product.Category>> filter)
        {
            List<Product> productFiltered = new List<>();
            foreach (Product product in this._productsStocked)
            {
                if(filter(this._productsStocked[product], product.ProductCategory))
                {
                    productFiltered.Add(product);
                }
            }
            return productFiltered;
        }

        public List<Product> GetProductsSorted(Comparer<Product> sorting)
        {
            List<Product> productSorted = new List<Product>();
            productSorted.Sort(sorting);
            return productSorted;
        }

        public int GetMaxAmountOfProducts()
        {
            return this._productsStocked.Aggregate((x, y) => x.Value > y.Value ? x : y).Value;
        }

        /// <summary>
        ///  Check if is possible take each products and their amount from the stock.
        /// </summary>
        /// <param name="productsTaken"> productsTaken </param>
        /// <returns> True or False if is possible or not </returns>
        private bool CheckProductsTaken(Dictionary<Product, int> productsTaken)
        {
            foreach (Products productTaken in productsTaken.Keys)
            {
                if(!this._productsStocked.ContainsKey(productTaken) || this._productsStocked[productsTaken] < productsTaken[productTaken])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
