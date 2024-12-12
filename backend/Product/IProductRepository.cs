namespace Product
{
  public interface IProductRepository
  {
    Product GetProductById(int productId);
    List<Product> GetAllProducts();
    bool UpdateProductStock(int productId, int stock);
    bool ApplyDiscount(int productId, double discount);
    bool inStock(int productId);
  }
}
