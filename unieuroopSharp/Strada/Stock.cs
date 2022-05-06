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
        private readonly Dictionary<IProduct, int> _productsStocked;

        public void AddProducts(Dictionary<IProduct, int> products)
        {
            foreach (IProduct product in products.Keys)
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

        int GetQuantityOfProduct(IProduct product)
        {
            return this._productsStocked[product];
        }

        public Dictionary<IProduct, int> GetTotalStock()
        {
            return new Dictionary<IProduct, int>(this._productsStocked);
        }

        public Dictionary<IProduct, int> TakeFromStock(Dictionary<IProduct, int> productsTaken)
        {
            if (!this.CheckProductsTaken(productsTaken))
            {
                throw new ArgumentException("Some products can not be taken");
            }
            foreach (IProduct productTaken in productsTaken.Keys)
            {
                this._productsStocked[productTaken] -= productsTaken[productTaken];
            }
            return productsTaken;
        }

        public void DeleteProducts(HashSet<IProduct> productsDelete)
        {
            foreach (IProduct product in productsDelete)
            {
                if (!this._productsStocked.ContainsKey(product))
                {
                    throw new ArgumentException("Some products can not be Deleted");
                }
            }
            foreach (IProduct product in productsDelete)
            {
                this._productsStocked.Remove(product);
            }
        }

        public List<IProduct> GetFilterProducts(Predicate<KeyValuePair<int, Product.Category>> filter)
        {
            List<IProduct> productFiltered = new List<IProduct>();
            foreach (IProduct product in this._productsStocked.Keys)
            {
                if(filter(new KeyValuePair<int, Product.Category>(this._productsStocked[product], product.Category)))
                {
                    productFiltered.Add(product);
                }
            }
            return productFiltered;
        }

        public List<IProduct> GetProductsSorted(Comparer<IProduct> sorting)
        {
            List<IProduct> productSorted = new List<IProduct>();
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
        private bool CheckProductsTaken(Dictionary<IProduct, int> productsTaken)
        {
            foreach (IProduct productTaken in productsTaken.Keys)
            {
                if(!this._productsStocked.ContainsKey(productTaken) || this._productsStocked[productsTaken] < productsTaken[productsTaken])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
