using NUnit.Framework;
using System;
using System.Collections.Generic;
using unieuroopSharp.Ferri;
using unieuroopSharp.Vincenzi;

namespace FerriTest
{
	public class Tests
	{
		private static readonly DateTime TIME_NOW = DateTime.Now();
		private static readonly DateTime TIME_START = DateTime.Now();
		private static readonly DateTime TIME_FINISH = DateTime.FromOADate(10.10);
		private static readonly string APPLE_PRODUCT = "APPLE";
		private static readonly int QUANTITY_P1 = 10;
		private static readonly int FINAL_QUANTITY = 11;
		private static readonly int FINAL_QUANTITY_P2 = 200;
		private Department _department
			private readonly Product p1 = new Product(1, "iphone 13 pro", DepartmentTest.APPLE_PRODUCT, 1200.00, 900.00, "best phone ever created", Product.Category.SMARTPHONE);
		private readonly Product p2 = new Product(2, "applewatch", DepartmentTest.APPLE_PRODUCT, 500.00, 200.00, "best watch ever created", Product.Category.SMARTWATCH);
		private readonly Product p3 = new Product(3, "mac book pro 14 ", DepartmentTest.APPLE_PRODUCT, 3000.00, 2000.00, "best mac book ever created", Product.Category.PC);
		private readonly Product p4 = new Product(4, "mac book pro 16", DepartmentTest.APPLE_PRODUCT, 6000.00, 3000.00, "best mac book ever created", Product.Category.PC);
		private readonly Staff staff1 = new Staff("Nome1", "Cognome1", DepartmentTest.TIME_NOW,
			"a", "email1@gmail.com", 12, new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>(DayOfWeek.of(1), new KeyValuePair<DateTime, DateTime>(TIME_START, TIME_FINISH)));
		private readonly Staff staff2 = new Staff("Nome2", "Cognome2", DepartmentTest.TIME_NOW,
			"b", "email2@gmail.csom", 123, new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>(DayOfWeek.of(2), new KeyValuePair<DateTime, DateTime>(TIME_START, TIME_FINISH)));
		private readonly Staff staff3 = new Staff("NomeProva", "CognomeProva", DepartmentTest.TIME_NOW,
			"c", "email3@gmail.com", 12, new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>(DayOfWeek.of(1), new KeyValuePair<DateTime, DateTime>(TIME_START, TIME_FINISH)));

		[SetUp]
		public void SetUp()
		{
			this._department = new Department("department1", new HashSet<Staff>(staff1, staff2), new Dictionary<Product, int>(p1, 10, p2, 100, p3, 3));
		}

		[Test]
		public void TestAddStaff1()
		{
			try
			{
				this._department.AddStaff(this.staff1);
				
			}
			catch (InvalidOperationException e)
			{

			}
			catch (ArgumentException e1)
			{

			}
		}

		[Test]
		public void TestAddStaff2()
		{
			try
			{
				this._department.AddStaff(staff3);
			}
			catch (ArgumentException e)
			{

			}
		}

		[Test]
		public void TestRemoveStaff1()
		{
			try
			{
				this._department.RemoveStaff(new HashSet<Staff>(staff1));
			}
			catch (ArgumentException e)
			{

			}
		}

		[Test]
		public void TestRemoveStaff2()
		{
			try
			{
				this._department.RemoveStaff(new HashSet<Staff>(staff3));

			}
			catch (ArgumentException e)
			{

			}
		}

		[Test]
		public void TestProductByQuantity()
		{
			Dictionary<Product, int> products = this._department.ProductsByQuantity((quantity)->quantity <= 10);



			int quantityP1 = products.TryGetValue(p1);
		}

		[Test]
		public void TestTakeProductFromDepartment()
		{
			try
			{
				this._department.TakeProductFromDepartment(new Dictionary<Product, int>(p1, v1: 1, p3, v2: 3));
			}
			catch
			{

			}
		}
	}
}