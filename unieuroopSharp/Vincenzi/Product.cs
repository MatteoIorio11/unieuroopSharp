using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopSharp.Vincenzi
{
    class Product
    {
        public int ProductCode { get; private set; }
        public double PurchasePrice { get; private set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        private double SellingPrice { get; set; }
        public string Description { get; set; }
        public Category ProductCategory { get; set; }
        public enum Category
        {
            SMARTPHONE,PC,HOME,SMARTWATCH,DOMESTIC_APPLIANCE,
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
    }
}
