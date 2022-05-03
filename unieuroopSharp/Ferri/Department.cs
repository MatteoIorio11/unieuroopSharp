﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using unieuroopSharp.Vincenzi;

namespace unieuroopSharp.Ferri
{
	public class Department : IDepartment
	{
		private readonly string _name;
		private readonly HashSet<Staff> _staff;
		private readonly Dictionary<Product, int> _products;

		public Department(string nameDepartment, HashSet<Staff> staff, Dictionary<Product, int> products)
		{
			this._name = nameDepartment;
			this._staff = new HashSet<>(staff);
			this._products = new Dictionary<>(products);
		}

		public void AddProducts(Dictionary<Product, int> produtcs)
        {
			for (Product product in produtcs.Keys())
            {
				var productsAdded = this._products.
            }
        }

		public void AddStaff(Staff newStaff)
        {
            if (!this._staff.Contains(newStaff))
            {
				this._staff.Add(newStaff)
            }
            else
            {
				throw new ArgumentException("The staff: " + newStaff.ToString() + " already exist. ");
            }
        }

		public void RemoveStaff(HashSet<Staff> deleteStaff)
        {
            if (this._staff.Contains(deleteStaff))
            {
				this._staff.Remove(deleteStaff);
            }
            else
            {
                throw new ArgumentException("Some of the input staff does not work in this department.");
            }
        }

        public string GetDepartment()
        {
            return this._name;
        }

        public Dictionary<Product, int> ProductsByQuantity(Predicate<int> quantity)
        {
            Dictionary<Product, int> prodcutsFilter = new Dictionary<>();
            for(Product product in this._products.Keys())
            {
                
            }
        }

        public HashSet<Staff> GetStaff()
        {
            return this._staff;
        }

        public Dictionary<Product, int> GetAllProducts()
        {
            return this._products;
        }

        public Dictionary<Product, int> TakeProductFromDepartment(Dictionary<Product, int> productsTaken)
        {
            if (!CheckProductsTaken(productsTaken))
            {
                throw new ArgumentException("Take products can not be done beacuse some products's quantity is less than the quantity in input");
            }
            for(Product product in productsTaken.Keys())
            {
                this._products.Add() ---------
            }
        }

        private bool CheckProductsTaken(Dictionary<Product, int> productsTaken)
        {
            for(Product productTake in productsTaken.Keys())
            {
                if(!this._products.ContainsKey(productTaken) || this._products.TryGetValue(productTaken) < productsTaken.TryGetValue(productTake))
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
            return base.GetHashCode(this._name);
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

