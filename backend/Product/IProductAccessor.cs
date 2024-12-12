namespace Product
{
  public interface IProductAccessor
  {
    public Product GetProductById(int productId);
    public List<Product> GetAllProducts();
    public bool UpdateProductStock(int productId, int stock);
    public bool ApplyDiscountToProduct(int productId, double discount);
  }
}