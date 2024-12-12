namespace Product
{
  public interface IProductManager
  {
    Product GetProductById(int productId);
    List<Product> GetAllProducts();
    bool UpdateProductStock(int productId, int stock);
    bool ApplyDiscountToProduct(int productId, double discountPercentage);
    List<Product> GetDiscountedProducts();
  }
}