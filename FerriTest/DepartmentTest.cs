using NUnit.Framework;
using System;
using System.Collections.Generic;
using unieuroopSharp.Ferri;
using unieuroopSharp.Vincenzi;

namespace FerriTest
{
	public class Tests
	{
		private static readonly DateTime TIME_NOW = DateTime.Now;
		private static readonly DateTime TIME_START = DateTime.Now;
		private static readonly DateTime TIME_FINISH = DateTime.FromOADate(10.10);
		private static readonly string APPLE_PRODUCT = "APPLE";
		private static readonly int QUANTITY_P1 = 10;
		private static readonly int FINAL_QUANTITY = 11;
		private static readonly int FINAL_QUANTITY_P2 = 200;
		private Department _department;
		private readonly Product p1 = new Product(1, "iphone 13 pro", Tests.APPLE_PRODUCT, 1200.00, 900.00, "best phone ever created", Product.Category.SMARTPHONE);
		private readonly Product p2 = new Product(2, "applewatch", Tests.APPLE_PRODUCT, 500.00, 200.00, "best watch ever created", Product.Category.SMARTWATCH);
		private readonly Product p3 = new Product(3, "mac book pro 14 ", Tests.APPLE_PRODUCT, 3000.00, 2000.00, "best mac book ever created", Product.Category.PC);
		private readonly Product p4 = new Product(4, "mac book pro 16", Tests.APPLE_PRODUCT, 6000.00, 3000.00, "best mac book ever created", Product.Category.PC);
		private readonly Staff staff1 = new Staff("Nome1", "Cognome1", Tests.TIME_NOW,
			"a", "email1@gmail.com", 12, new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>()
				{
					{DayOfWeek.Monday,new KeyValuePair<DateTime, DateTime>(TIME_START, TIME_FINISH)}
				});
		private readonly Staff staff2 = new Staff("Nome2", "Cognome2", Tests.TIME_NOW,
			"b", "email2@gmail.csom", 123, new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>()
				{
					{DayOfWeek.Wednesday,new KeyValuePair<DateTime, DateTime>(TIME_START, TIME_FINISH)}
				});
		private readonly Staff staff3 = new Staff("NomeProva", "CognomeProva", Tests.TIME_NOW,
			"c", "email3@gmail.com", 12, new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>()
				{
					{DayOfWeek.Monday,new KeyValuePair<DateTime, DateTime>(TIME_START, TIME_FINISH)}
				});

		[SetUp]
		public void SetUp()
		{
			this._department = new Department("department1", new HashSet<Staff>() { staff1, staff2 }, new Dictionary<Product, int>() { p1, 10, p2, 100, p3, 3 });
		}

		[Test]
		public void TestAddStaff1()
		{
			try
			{
				this._department.AddStaff(this.staff1);
				Assert.Fail("ERROR Excpetion must be detected.");
			}
			catch (InvalidOperationException e)
			{
				Assert.Fail("ERROR wrong exception throwned.");
			}
			catch (ArgumentException e1)
			{
				Assert.True(e1.Message.Contains("staff"));
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
				Assert.Fail("ERROR this staff is not contained in the department so the Exception must not be throwned.");
			}
		}

		[Test]
		public void TestRemoveStaff1()
		{
			try
			{
				this._department.RemoveStaff(new HashSet<Staff>() { staff1 });
			}
			catch (ArgumentException e)
			{
				Assert.Fail("ERROR : this staff is present and the exception must not be throwned.");
			}
		}

		[Test]
		public void TestRemoveStaff2()
		{
			try
			{
				this._department.RemoveStaff(new HashSet<Staff>() { staff3 });
				Assert.Fail("ERROR : the exception must be thowned because " + staff3.ToString() + "does not exist in Department");
			}
			catch (ArgumentException e)
			{
				Assert.True(e.Message.Contains("staff"));
			}
		}

		[Test]
		public void TestProductByQuantity()
		{
			Dictionary<Product, int> products = this._department.ProductsByQuantity(quantity => quantity <= 10);

			Assert.True(products.ContainsKey(p1));

			int quantityP1 = products[p1];

			Assert.True(products.ContainsKey(p3));
			Assert.False(products.ContainsKey(p2));
			Assert.False(products.ContainsKey(p4));
			Assert.Equals(Tests.QUANTITY_P1, quantityP1);
		}

		[Test]
		public void TestTakeProductFromDepartment1()
		{
			try
			{
				this._department.TakeProductFromDepartment(new Dictionary<Product, int>() { p1, 1, p3, 3 });
			}
			catch
			{
				Assert.Fail("ERROR : this operation can be done withouth exception");
			}
		}

		[Test]
		public void testTakeProductFromDepartment2()
		{
			try
			{
				this._department.TakeProductFromDepartment(new Dictionary<Product, int>() { p3, 100 });
				Assert.Fail("ERROR : this operation can not be done, p30's quantity is less than 100");
			}
			catch (ArgumentException e)
			{
				Assert.True(e.Message.Contains("Take products can not be done beacuse some products's quantity is less than the quantity in input"));
			}
		}
		
		[Test]
		public void testAddProducts()
		{
			Dictionary<Product, int> products = new Dictionary<Product, int>() { p1, 1, p2, 100, p3, 10 };
			this._department.AddProducts(products);
			int quantityP1 = this._department.GetAllProducts()[p1];
			int quantityP2 = this._department.GetAllProducts()[p2];

			Assert.Equals(Tests.FINAL_QUANTITY, quantityP1);
			Assert.Equals(Tests.FINAL_QUANTITY_P2, quantityP2);
		}
	}
}