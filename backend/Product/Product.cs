namespace Product
{
  public class Product
  {
    public required int ProductID { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required double Price { get; set; }
    public required string Images { get; set; }
    public required string Manufacturer { get; set; }
    public required string Dimensions { get; set; }
    public required double Weight { get; set; }
    public required double Rating { get; set; }
    public required string SKU { get; set; }
    public required int CategoryID { get; set; }
    public required int Stock { get; set; }
    public required double Discount { get; set; }
    public required DateTime DiscountStartDate { get; set; }
    public required DateTime DiscountEndDate { get; set; }
  }
}
