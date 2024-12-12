namespace Product
{
  public class ProductManager : IProductManager
  {
    private readonly IProductEngine _productEngine;

    public ProductManager(IProductEngine productEngine)
    {
      _productEngine = productEngine;
    }

    public Product GetProductById(int productId)
    {
      return _productEngine.GetProductById(productId);
    }

    public List<Product> GetAllProducts()
    {
      return _productEngine.GetAllProducts();
    }

    public bool UpdateProductStock(int productId, int stock)
    {
      return _productEngine.UpdateProductStock(productId, stock);
    }

    public bool ApplyDiscountToProduct(int productId, double discountPercentage)
    {
      return _productEngine.ApplyDiscountToProduct(productId, discountPercentage);
    }

    public List<Product> GetDiscountedProducts()
    {
      return _productEngine.GetDiscountedProducts();
    }
  }
}