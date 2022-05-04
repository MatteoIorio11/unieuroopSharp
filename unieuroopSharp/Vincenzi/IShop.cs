﻿using System;
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
        void AddDepartment(IDepartment department);
        void AddStaffIn(IDepartment departmentInput, HashSet<IStaff> staff);
        void RemoveStaffFrom(IDepartment departmentInput, HashSet<IStaff> staff);
        void EditStaff(string name, string surname, DateTime birthday, string email, string password,
        string hoursStartWork, string minutesStartWork, string hoursEndWork, string minutesEndWork, IStaff staff);
        void EditClient(string name, string surname, DateTime birthday, IClient client);
        void AddStaff(IStaff staff);
        void AddSupplier(ISupplier supplier);
        void AddSale(ISale sale);
        void RegisterClient(IClient client);
        void RemoveDepartment(IDepartment department);
        void RemoveStaff(IStaff staff);
        void RemoveSupplier(ISupplier supplier);
        void RemoveSale(ISale sale);
        void RemoveClient(IClient client);
        void SupplyDepartment(IDepartment department, Dictionary<Product, int> requestedProduct);
        void PutProductsBackInStock(IDepartment department, Dictionary<Product, int> requestedProducts);
        IDepartment MergeDepartments(HashSet<IDepartment> departments, string newName);
        HashSet<Category> GetAllCategories();
    }
}
