namespace Product
{
  public class ProductAccessor : IProductAccessor
  {
    private readonly IProductRepository _productRepository;

    public ProductAccessor(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    public Product GetProductById(int productId)
    {
      return _productRepository.GetProductById(productId);
    }

    public List<Product> GetAllProducts()
    {
      return _productRepository.GetAllProducts();
    }

    public bool UpdateProductStock(int productId, int stock)
    {
      var product = _productRepository.GetProductById(productId);
      if (product == null)
      {
        throw new ArgumentException($"No product found with ID {productId}");
      }

      return _productRepository.UpdateProductStock(productId, stock);
    }

    public bool ApplyDiscountToProduct(int productId, double discount)
    {
      var product = _productRepository.GetProductById(productId);
      if (product == null)
      {
        throw new ArgumentException($"No product found with ID {productId}");
      }

      return _productRepository.ApplyDiscount(productId, discount);
    }
  }
}
