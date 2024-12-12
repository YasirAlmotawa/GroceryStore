namespace Product
{
  public class ProductEngine : IProductEngine
  {
    private readonly IProductAccessor _productAccessor;

    public ProductEngine(IProductAccessor productAccessor)
    {
      _productAccessor = productAccessor;
    }

    public Product GetProductById(int productId)
    {
      var product = _productAccessor.GetProductById(productId);
      if (product == null)
      {
        throw new ArgumentException($"No product found with ID {productId}");
      }
      return product;
    }
    public List<Product> GetAllProducts()
    {
      return _productAccessor.GetAllProducts();
    }

    public bool UpdateProductStock(int productId, int stock)
    {
      if (stock < 0)
      {
        throw new ArgumentException("Stock cannot be negative.");
      }

      return _productAccessor.UpdateProductStock(productId, stock);
    }
    public bool ApplyDiscountToProduct(int productId, double discountPercentage)
    {
      if (discountPercentage < 0 || discountPercentage > 100)
      {
        throw new ArgumentException("Discount percentage must be between 0 and 100.");
      }
      double discount = discountPercentage / 100;

      return _productAccessor.ApplyDiscountToProduct(productId, discount);
    }
    public List<Product> GetDiscountedProducts()
    {
      var products = _productAccessor.GetAllProducts();
      return products.Where(p => p.Discount > 0 && DateTime.UtcNow >= p.DiscountStartDate && DateTime.UtcNow <= p.DiscountEndDate).ToList();
    }

  }
}