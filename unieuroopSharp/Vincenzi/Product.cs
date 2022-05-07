using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopSharp.Vincenzi
{
    public class Product : IProduct
    {
        public int ProductCode { get; private set; }
        public double PurchasePrice { get; private set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double SellingPrice { get; set; }
        public string Description { get; set; }
        public Category ProductCategory { get; set; }
        public Product(
            int productCode, string name, string brand, double sellingPrice,
            double purchasePrice, string description, Category category)
        {
            this.ProductCode = productCode;
            this.Name = name;
            this.Brand = brand;
            this.SellingPrice = sellingPrice;
            this.PurchasePrice = purchasePrice;
            this.Description = description;
            this.ProductCategory = category;
        }
        public enum Category
        {
            SMARTPHONE, PC, HOME, SMARTWATCH, DOMESTIC_APPLIANCE,
            COMPUTER,
            PC_DESKTOP,
            MONITOR,
            KEYBOARD,
            MOUSE,
            SCANNER,
            PRINTER,
            NAS,
            HARD_DISK_AND_STORAGE,
            NETWORKING,
            VIDEO_SURVEILLANCE,
            TABLET
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   ProductCode == product.ProductCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductCode, PurchasePrice, Name, Brand, SellingPrice, Description, ProductCategory);
        }
        public override string ToString()
        {
            return "code: " + this.ProductCode + " name: " + this.Name;
        }
    }
}
