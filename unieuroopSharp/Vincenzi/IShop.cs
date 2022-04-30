using System;
using System.Collections.Generic;
using System.Text;
using unieuroopSharp.Iorio;

namespace unieuroopSharp.Vincenzi
{
    interface IShop
    {
        void AddBills(DateTime date, double spent);
        void AddDepartment(Department department);
        void AddStaffIn(Department departmentInput, HashSet<Staff> staff);
        void RemoveStaffFrom(Department departmentInput, HashSet<Staff> staff);
        void EditStaff(String name, String surname, DateTime birthday, String email, String password,
        string hoursStartWork, String minutesStartWork, String hoursEndWork, String minutesEndWork, Staff staff);
        void EditClient(String name, String surname, DateTime birthday, Client client);
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
        Department MergeDepartments(HashSet<Department> departments, String newName);
        HashSet<Category> GetAllCategories();
    }
}
