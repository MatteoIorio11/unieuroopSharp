using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using unieuroopSharp.Vincenzi;

namespace unieuroopSharp.Ferri
{
	public class Department : IDepartment
	{
		private readonly string _name;
		private readonly HashSet<IStaff> _staff;
        private readonly Dictionary<IProduct, int> _products;

		public Department(string nameDepartment, HashSet<IStaff> staff, Dictionary<IProduct, int> products)
		{
			this._name = nameDepartment;
            this._staff = staff;
            this._products = products;
		}

		public void AddProducts(Dictionary<IProduct, int> products)
        {
			foreach (Product product in products.Keys)
            {
                if (this._products.ContainsKey(product))
                {
                    this._products[product] += products[product];
                }
                else
                {
                    this._products.Add(product, products[product]);
                }
            }
        }

		public void AddStaff(IStaff newStaff)
        {
            if (!this._staff.Contains(newStaff))
            {
                this._staff.Add(newStaff);
            }
            else
            {
				throw new ArgumentException("The staff: " + newStaff.ToString() + " already exist. ");
            }
        }

		public void RemoveStaff(HashSet<IStaff> deleteStaff)
        {
            foreach(IStaff staff in deleteStaff)
            {
                if (this._staff.Contains(staff))
                {
                    this._staff.Remove(staff);
                }
                else
                {
                    throw new ArgumentException("Some of the input staff does not work in this department.");
                }
            }
        }

        public string GetDepartmentName()
        {
            return this._name;
        }

        public Dictionary<IProduct, int> ProductsByQuantity(Predicate<int> quantity)
        {
            Dictionary<IProduct, int> prodcutsFilter = new Dictionary<IProduct, int>();
            foreach(Product product in this._products.Keys)
            {
                if (quantity.Invoke(this._products[product]))
                {
                    prodcutsFilter.Add(product, this._products[product]);
                }
            }

            return prodcutsFilter;
        }

        public HashSet<IStaff> GetStaff()
        {
            return this._staff;
        }

        public Dictionary<IProduct, int> GetAllProducts()
        {
            return this._products;
        }

        public Dictionary<IProduct, int> TakeProductFromDepartment(Dictionary<IProduct, int> productsTaken)
        {
            if (!CheckProductsTaken(productsTaken))
            {
                throw new ArgumentException("Take products can not be done beacuse some products's quantity is less than the quantity in input");
            }
            foreach(Product product in productsTaken.Keys)
            {
                this._products[product] -= productsTaken[product];
            }

            return this._products;
        }

        private bool CheckProductsTaken(Dictionary<IProduct, int> productsTaken)
        {
            foreach(Product productTake in productsTaken.Keys)
            {
                if(!this._products.ContainsKey(productTake) || this._products[productTake] < productsTaken[productTake])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return this._name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + this._name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(this == obj)
            {
                return true;
            }
            if(obj == null)
            {
                return false;
            }
            if(GetType() != obj.GetType())
            {
                return false;
            }

            Department other = (Department)obj;
            return object.Equals(this._name, other._name);
        }
    }
}

