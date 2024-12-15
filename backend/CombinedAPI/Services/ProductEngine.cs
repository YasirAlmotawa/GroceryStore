using CombinedAPI.Repositories;
using CombinedAPI.Models;
using CombinedAPI.Interfaces;

namespace CombinedAPI.Services
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
      return _productAccessor.GetProductById(productId);
    }
    public Product GetProductByName(string Name)
    {
      return _productAccessor.GetProductByName(Name);
    }
    public List<Product> GetProductByCategory(int categoryId)
    {
      return _productAccessor.GetProductByCategory(categoryId);
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
  }
}