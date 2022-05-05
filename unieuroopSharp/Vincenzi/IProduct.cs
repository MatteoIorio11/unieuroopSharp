namespace unieuroopSharp.Vincenzi
{
    public interface IProduct
    {
        string Brand { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        Product.Category ProductCategory { get; set; }
        int ProductCode { get; }
        double PurchasePrice { get; }
        double SellingPrice { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}