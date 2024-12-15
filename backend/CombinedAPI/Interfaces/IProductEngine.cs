using CombinedAPI.Models;

namespace CombinedAPI.Interfaces
{
  public interface IProductEngine
  {
    Product GetProductById(int productId);
    Product GetProductByName(string Name);
    List<Product> GetProductByCategory(int categoryId);
    List<Product> GetAllProducts();
    bool UpdateProductStock(int productId, int stock);
  }
}
