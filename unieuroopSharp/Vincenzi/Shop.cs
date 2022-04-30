using System;
using System.Collections.Generic;
using System.Text;
using unieuroopSharp.Iorio;

namespace unieuroopSharp.Vincenzi
{
    class Shop : IShop
    {
        public void AddBills(DateTime date, double spent)
        {
            throw new NotImplementedException();
        }

        public void AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void AddSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public void AddStaff(Staff staff)
        {
            throw new NotImplementedException();
        }

        public void AddStaffIn(Department departmentInput, HashSet<Staff> staff)
        {
            throw new NotImplementedException();
        }

        public void AddSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public void EditClient(string name, string surname, DateTime birthday, Client client)
        {
            throw new NotImplementedException();
        }

        public void EditStaff(string name, string surname, DateTime birthday, string email, string password, string hoursStartWork, string minutesStartWork, string hoursEndWork, string minutesEndWork, Staff staff)
        {
            throw new NotImplementedException();
        }

        public HashSet<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Department MergeDepartments(HashSet<Department> departments, string newName)
        {
            throw new NotImplementedException();
        }

        public void PutProductsBackInStock(Department department, Dictionary<Product, int> requestedProducts)
        {
            throw new NotImplementedException();
        }

        public void RegisterClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void RemoveClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void RemoveDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void RemoveSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public void RemoveStaff(Staff staff)
        {
            throw new NotImplementedException();
        }

        public void RemoveStaffFrom(Department departmentInput, HashSet<Staff> staff)
        {
            throw new NotImplementedException();
        }

        public void RemoveSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public void SupplyDepartment(Department department, Dictionary<Product, int> requestedProduct)
        {
            throw new NotImplementedException();
        }
    }
}
