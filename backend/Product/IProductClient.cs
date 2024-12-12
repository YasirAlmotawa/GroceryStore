public interface IProductClient
{
  void DisplayProductDetails(int productId);
  void DisplayAllProducts();
  void UpdateStock(int productId, int newStock);
  void ApplyDiscount(int productId, double discountPercentage);
  void DisplayDiscountedProducts();
}
