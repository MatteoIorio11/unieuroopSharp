using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using unieuroopSharp.Ferri;
using unieuroopSharp.Iorio;

namespace unieuroopSharp.Vincenzi
{
    class Shop : IShop
    {
        public HashSet<Department> Departments { get; private set; }
        public HashSet<Staff> Staffs { get; private set; }
        public HashSet<Supplier> Suppliers { get; private set; }
        public HashSet<Sale> Sales { get; private set; }
        public HashSet<Client> RegisteredClients { get; private set; }
        public Stock Stock { get; private set; }
        public Dictionary<DateTime, Double> Bills { get; private set; }
        public string Name { get; set; }
        public Shop(string name)
        {
            this(name, new HashSet<>(), new HashSet<>(), new HashSet<>(), new HashSet<>(), new HashSet<>(), new StockImpl(), new HashMap<>());
        }

        public Shop(string name, HashSet<Department> departments,
                HashSet<Staff> staffs, HashSet<Supplier> suppliers,
                HashSet<Sale> sales, HashSet<Client> registeredClients,
                Stock stock, Dictionary<DateTime, Double> bills)
        {

       
            this.Name = name;
            this.Departments = departments;
            this.Staffs = staffs;
            this.Suppliers = suppliers;
            this.Sales = sales;
            this.RegisteredClients = registeredClients;
            this.Stock = stock;
            this.Bills = bills;
        }
        public void AddBills(DateTime date, double spent)
        {
            this.Bills.Add(date, spent);
        }

        public void AddDepartment(Department department)
        {
            this.Departments.Add(department);
        }

        public void AddSale(Sale sale)
        {
            this.Sales.Add(sale);
        }

        public void AddStaff(Staff staff)
        {
            this.Staffs.Add(staff);
        }

        public void AddStaffIn(Department departmentInput, HashSet<Staff> staff)
        {
            Department department = this.Departments.Where(d => d.Equals(d)).First;
            foreach (var s in staff)
            {
                department.addStaff(s);
            }

        }

        public void AddSupplier(Supplier supplier)
        {
            this.Suppliers.Add(supplier);
        }

        public void EditClient(string name, string surname, DateTime birthday, Client client)
        {
            Client clientInput = RegisteredClients.Where(c => c.Equals(client)).First();
            clientInput.GetPerson().SetPersonName(name);
            clientInput.GetPerson().SetPersonSurname(surname);
            clientInput.GetPerson().SetPersonBirthday(birthday);
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
            var dep = this.Departments.Where(d => d.Equals(department)).First();
            dep.TakeProductFromDepartment(requestedProducts);
            this.Stock.AddProducts(requestedProducts);
        }

        public void RegisterClient(Client client)
        {
            this.RegisteredClients.Add(client);
        }

        public void RemoveClient(Client client)
        {
            if (!this.RegisteredClients.Remove(client))
            {
                throw new NoSuchElementException("The input client does not exist");
            }
        }

        public void RemoveDepartment(Department department)
        {
            if (!this.Departments.Remove(department))
            {
                throw new NoSuchElementException("The input department does not exist");
            }
        }

        public void RemoveSale(Sale sale)
        {
            if (!this.Sales.Remove(sale))
            {
                throw new NoSuchElementException("The input sale does not exist");
            }
        }

        public void RemoveStaff(Staff staff)
        {
            if (!this.Staffs.Remove(staff))
            {
                throw new NoSuchElementException("The input staff does not exist");
            }
        }

        public void RemoveStaffFrom(Department departmentInput, HashSet<Staff> staff)
        {
            Department department = this.Departments.Where(d => d.Equals(departmentInput)).First();
            department.RemoveStaff(staff);
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
