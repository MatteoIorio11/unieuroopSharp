using System;
using System.Collections.Generic;
using unieuroopSharp.Vincenzi

namespace unieuroopSharp.Ferri
{
	public interface IDepartment
	{
		/// <summary>
		/// This method is used to add an amount of products in the Department.
		/// </summary>
		/// <param name="products"></param>
		/// <returns></returns>
		void AddProducts(Dictionary<Product, int> products);

		/// <summary>
		/// This method is used to assigns new Staff in the Department.
		/// </summary>
		/// <param name="newStaff"></param>
		/// <returns></returns>
		void AddStaff(Staff newStaff);

		/// <summary>
		/// This method is used to remove a set of Staff from the assigned Department.
		/// </summary>
		/// <param name="deleteStaff"></param>
		/// <returns></returns>
		void RemoveStaff(HashSet<Staff> deleteStaff);

		/// <summary>
		/// This method is used to return the Department name.
		/// </summary>
		/// <param></param>
		/// <returns> department name </returns>
		string GetDepartment();

		/// <summary>
		/// This method is used to return products filtered by their quantities.
		/// </summary>
		/// <param name="quantity"></param>
		/// <returns> products by quantitity</returns>
		Dictionary<Product, int> ProductsByQuantity(Predicate<int> quantity);

		/// <summary>
		/// This method is used to return the entire Staff assigned in the Department.
		/// </summary>
		/// <param></param>
		/// <returns> staffs department </returns>
		HashSet<Staff> GetStaff();

		/// <summary>
		/// This method is used to return all products presents in the Department.
		/// </summary>
		/// <param></param>
		/// <returns> department products </returns>
		Dictionary<Product, int> GetAllProducts();

		/// <summary>
		/// This method is used to return the products and their amount taken from the departments.
		/// </summary>
		/// <param name="productsTaken"></param>
		/// <returns> products taken</returns>
		Dictionary<Product, int> TakeProductFromDepartment(Dictionary<Product, int> productsTaken);
	}
}

