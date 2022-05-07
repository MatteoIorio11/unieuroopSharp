using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using unieuroopSharp.Ferri;
using unieuroopSharp.Iorio;
using unieuroopSharp.Strada;

namespace unieuroopSharp.Vincenzi
{
    public class Shop : IShop
    {
        public HashSet<IDepartment> Departments { get; private set; }
        public HashSet<IStaff> Staffs { get; private set; }
        public HashSet<ISupplier> Suppliers { get; private set; }
        public HashSet<ISale> Sales { get; private set; }
        public HashSet<IClient> RegisteredClients { get; private set; }
        public IStock Stock { get; private set; }
        public Dictionary<DateTime, double> Bills { get; private set; }
        public string Name { get; set; }
        public Shop(string name): this(name, new HashSet<IDepartment>(), 
            new HashSet<IStaff>(), new HashSet<ISupplier>(), 
            new HashSet<ISale>(), new HashSet<IClient>(), new Stock(), 
            new Dictionary<DateTime, double>())
        {}

        public Shop(string name, HashSet<IDepartment> departments,
                HashSet<IStaff> staffs, HashSet<ISupplier> suppliers,
                HashSet<ISale> sales, HashSet<IClient> registeredClients,
                IStock stock, Dictionary<DateTime, double> bills)
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
            if (this.Bills.ContainsKey(date))
            {
                this.Bills[date] += spent;
            }
            else
            {
                this.Bills.Add(date, spent);
            }
        }

        public void AddDepartment(IDepartment department)
        {
            this.Departments.Add(department);
        }

        public void AddSale(ISale sale)
        {
            this.Sales.Add(sale);
        }

        public void AddStaff(IStaff staff)
        {
            this.Staffs.Add(staff);
        }

        public void AddStaffIn(IDepartment departmentInput, HashSet<IStaff> staff)
        {
            IDepartment department = this.Departments.Where(d => d.Equals(d)).First();
            foreach (var s in staff)
            {
                department.AddStaff(s);
            }

        }

        public void AddSupplier(ISupplier supplier)
        {
            this.Suppliers.Add(supplier);
        }

        public void EditClient(string name, string surname, DateTime birthday, IClient client)
        {
            IClient clientInput = RegisteredClients.Where(c => c.Equals(client)).First();
            clientInput.GetPerson().SetPersonName(name);
            clientInput.GetPerson().SetPersonSurname(surname);
            clientInput.GetPerson().SetPersonBirthday(birthday);
        }

        public void EditStaff(string name, string surname, DateTime birthday, string email, string password, string hoursStartWork, string minutesStartWork, string hoursEndWork, string minutesEndWork, IStaff staff)
        {
            var days = new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>();
            var times = new KeyValuePair<DateTime, DateTime> (new DateTime(0,0,0,int.Parse(hoursStartWork), int.Parse(minutesStartWork),0), new DateTime(0,0,0,int.Parse(hoursEndWork), int.Parse(minutesEndWork),0));
            Enumerable.Range(((int)DayOfWeek.Monday), ((int)DayOfWeek.Sunday)).ToList().ForEach( i => days.Add(((DayOfWeek)i), times));
            IStaff staffInput = this.Staffs.Where(s => s.Equals(staff)).First();
            staffInput.GetPerson().SetPersonName(name);
            staffInput.GetPerson().SetPersonSurname(surname);
            staffInput.GetPerson().SetPersonBirthday(birthday);
            staffInput.SetEmail(email);
            staffInput.SetPassword(password.GetHashCode());
            staffInput.SetWorkTime(days);
        }


        public HashSet<Product.Category> GetAllCategories()
        {
            return this.Stock.GetTotalStock()
               .Select(entry => entry.Key.ProductCategory)
               .Distinct()
               .ToHashSet();
        }

        public IDepartment MergeDepartments(HashSet<IDepartment> departments, string newName)
        {
            Dictionary<IProduct, int> products = new Dictionary<IProduct, int>();
            //Get all products from the departments i want to merge.
            departments.Select(d => d.GetAllProducts().AsParallel())
                .AsParallel()
                .ForAll(m =>
                {
                    m.ForAll(p =>
                    {
                        if (products.ContainsKey(p.Key))
                        {
                            products[p.Key] += p.Value;
                        }
                        else
                        {
                            products.Add(p.Key, p.Value);
                        }
                    });
                });

            HashSet<IStaff> staff = new HashSet<IStaff>();
            //Get all staff from the department i want to merge.
            departments.Select(d => d.GetStaff().AsParallel())
                    .AsParallel()
                    .ForAll(d =>
                    {
                        d.ForAll(s =>
                            {
                                staff.Add(s);
                            });
                    });
            //Removing all departments.
            departments.AsParallel().ForAll(d => this.RemoveDepartment(d));
            //Creating new department.
            var dep = new Department(newName, staff, products);
            this.AddDepartment(dep);
            return dep;
        }

        public void PutProductsBackInStock(IDepartment department, Dictionary<IProduct, int> requestedProducts)
        {
            var dep = this.Departments.Where(d => d.Equals(department)).First();
            dep.TakeProductFromDepartment(requestedProducts);
            this.Stock.AddProducts(requestedProducts);
        }

        public void RegisterClient(IClient client)
        {
            this.RegisteredClients.Add(client);
        }

        public void RemoveClient(IClient client)
        {

            if (!this.RegisteredClients.Remove(client))
            {
                throw new ArgumentException("The input client does not exist");
            }
        }

        public void RemoveDepartment(IDepartment department)
        {
            if (!this.Departments.Remove(department))
            {
                throw new ArgumentException("The input department does not exist");
            }
        }

        public void RemoveSale(ISale sale)
        {
            if (!this.Sales.Remove(sale))
            {
                throw new ArgumentException("The input sale does not exist");
            }
        }

        public void RemoveStaff(IStaff staff)
        {
            if (!this.Staffs.Remove(staff))
            {
                throw new ArgumentException("The input staff does not exist");
            }
        }

        public void RemoveStaffFrom(IDepartment departmentInput, HashSet<IStaff> staff)
        {
            IDepartment department = this.Departments.Where(d => d.Equals(departmentInput)).First();
            department.RemoveStaff(staff);
        }

        public void RemoveSupplier(ISupplier supplier)
        {
            if (!this.Suppliers.Remove(supplier))
            {
                throw new ArgumentException("The input supplier does not exist");
            }
        }

        public void SupplyDepartment(IDepartment department, Dictionary<IProduct, int> requestedProduct)
        {
            var dep = this.Departments.Where(d => d.Equals(department)).First();
            var products = this.Stock.TakeFromStock(requestedProduct);
            dep.AddProducts(products);
        }
    }
}
