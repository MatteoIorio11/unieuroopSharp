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
        void AddBills(DateTime date, double spent);
        void AddDepartment(Department department);
        void AddStaffIn(Department departmentInput, HashSet<Staff> staff);
        void RemoveStaffFrom(Department departmentInput, HashSet<Staff> staff);
        void EditStaff(string name, string surname, DateTime birthday, string email, string password,
        string hoursStartWork, string minutesStartWork, string hoursEndWork, string minutesEndWork, Staff staff);
        void EditClient(string name, string surname, DateTime birthday, Client client);
        void AddStaff(Staff staff);
        void AddSupplier(Supplier supplier);
        void AddSale(Sale sale);
        void RegisterClient(Client client);
        void RemoveDepartment(Department department);
        void RemoveStaff(Staff staff);
        void RemoveSupplier(Supplier supplier);
        void RemoveSale(Sale sale);
        void RemoveClient(Client client);
        void SupplyDepartment(Department department, Dictionary<Product, int> requestedProduct);
        void PutProductsBackInStock(Department department, Dictionary<Product, int> requestedProducts);
        Department MergeDepartments(HashSet<Department> departments, string newName);
        HashSet<Category> GetAllCategories();
    }
}
