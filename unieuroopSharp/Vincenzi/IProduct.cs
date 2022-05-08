namespace unieuroopSharp.Vincenzi
{
    public interface IProduct
    {
        /// <summary>
        /// Set and Get for the brand of the product.
        /// </summary>
        string Brand { get; set; }
        /// <summary>
        /// Set and Get for the description of the product.
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Set and Get for the name of the product.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Set and Get the Category of the product.
        /// </summary>
        Product.Category ProductCategory { get; set; }
        /// <summary>
        /// It Gets the univoque code of the product.
        /// </summary>
        int ProductCode { get; }
        /// <summary>
        /// Set and Get for the price payed by the shop to get this product
        /// </summary>
        double PurchasePrice { get; }
        /// <summary>
        /// Set and Get for the price the shop decided as selling price
        /// </summary>
        double SellingPrice { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}