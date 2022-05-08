using System;
using System.Collections.Generic;
using System.Text;
using unieuroopSharp.Ferri;
using unieuroopSharp.Iorio;
using unieuroopSharp.Strada;
using static unieuroopSharp.Vincenzi.Product;

namespace unieuroopSharp.Vincenzi
{
    public interface IShop
    {
        /// <summary>
        /// It gets an HashSet with all the departments of the shop.
        /// </summary>
        HashSet<IDepartment> Departments { get; }
        /// <summary>
        /// Get for the staff of the shop.
        /// </summary>
        HashSet<IStaff> Staffs { get; }
        /// <summary>
        /// It gets an HashSet containing all the suppliers of the shop.
        /// </summary>
        HashSet<ISupplier> Suppliers { get; }
        /// <summary>
        /// It gets an HashSet containing all the sales the shop made so far.
        /// </summary>
        HashSet<ISale> Sales { get; }
        /// <summary>
        /// It gets an HashSet containing all the registered clients of the shop.
        /// </summary>
        HashSet<IClient> RegisteredClients { get; }
        /// <summary>
        /// It gets the stock of the shop.
        /// </summary>
        IStock Stock { get; }
        /// <summary>
        /// It gets a disctionary with date and money spent for each bill.
        /// </summary>
        Dictionary<DateTime, double> Bills { get; }
        /// <summary>
        /// Get and Set for the name of the shop.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Add a new bill inside the Dictionary of all bills.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="spent"></param>
        void AddBills(DateTime date, double spent);
        /// <summary>
        /// Adds a new department to the shop.
        /// </summary>
        /// <param name="department"></param>
        void AddDepartment(IDepartment department);
        /// <summary>
        /// Add new staff inside a specific department.
        /// </summary>
        /// <param name="departmentInput"></param>
        /// <param name="staff"></param>
        void AddStaffIn(IDepartment departmentInput, HashSet<IStaff> staff);
        /// <summary>
        ///  Remove staff from a specific department.
        /// </summary>
        /// <param name="departmentInput"></param>
        /// <param name="staff"></param>
        void RemoveStaffFrom(IDepartment departmentInput, HashSet<IStaff> staff);
        /// <summary>
        /// Edit the selected staff.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="birthday"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="hoursStartWork"></param>
        /// <param name="minutesStartWork"></param>
        /// <param name="hoursEndWork"></param>
        /// <param name="minutesEndWork"></param>
        /// <param name="staff"></param>
        void EditStaff(string name, string surname, DateTime birthday, string email, string password,
        string hoursStartWork, string minutesStartWork, string hoursEndWork, string minutesEndWork, IStaff staff);
        /// <summary>
        /// Edit the selected client.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="birthday"></param>
        /// <param name="client"></param>
        void EditClient(string name, string surname, DateTime birthday, IClient client);
        /// <summary>
        /// dds a new person to the staff of the shop.
        /// </summary>
        /// <param name="staff"></param>
        void AddStaff(IStaff staff);
        /// <summary>
        /// Adds a new supplier to the shop.
        /// </summary>
        /// <param name="supplier"></param>
        void AddSupplier(ISupplier supplier);
        /// <summary>
        /// Adds a new sale made by the shop.
        /// </summary>
        /// <param name="sale"></param>
        void AddSale(ISale sale);
        /// <summary>
        /// Registers a new client.
        /// </summary>
        /// <param name="client"></param>
        void RegisterClient(IClient client);
        /// <summary>
        /// Removes an existing department.
        /// </summary>
        /// <param name="department"></param>
        void RemoveDepartment(IDepartment department);
        /// <summary>
        /// Removes a person from the staff of the shop.
        /// </summary>
        /// <param name="staff"></param>
        void RemoveStaff(IStaff staff);
        /// <summary>
        /// Removes a supplier of the shop.
        /// </summary>
        /// <param name="supplier"></param>
        void RemoveSupplier(ISupplier supplier);
        /// <summary>
        /// Removes an existing sale.
        /// </summary>
        /// <param name="sale"></param>
        void RemoveSale(ISale sale);
        /// <summary>
        /// Removes a registered client.
        /// </summary>
        /// <param name="client"></param>
        void RemoveClient(IClient client);
        /// <summary>
        /// Takes the requested quantity of the specified products from the stock and add them in the specified department.
        /// </summary>
        /// <param name="department"></param>
        /// <param name="requestedProduct"></param>
        void SupplyDepartment(IDepartment department, Dictionary<IProduct, int> requestedProduct);
        /// <summary>
        /// Takes products from a specific department and pu them back in the stock.
        /// </summary>
        /// <param name="department"></param>
        /// <param name="requestedProducts"></param>
        void PutProductsBackInStock(IDepartment department, Dictionary<IProduct, int> requestedProducts);
        /// <summary>
        /// Return the new merged department, created by the previously selected departments.
        /// </summary>
        /// <param name="departments"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        IDepartment MergeDepartments(HashSet<IDepartment> departments, string newName);
        /// <summary>
        ///  Returns all the categories present in the Shop.
        /// </summary>
        /// <returns></returns>
        HashSet<Category> GetAllCategories();
    }
}
