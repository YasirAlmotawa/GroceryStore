namespace Product
{


  using System.Net.Http;
  using System.Net.Http.Json;
  using System.Threading.Tasks;


  public class ProductClient
  {
    private readonly HttpClient _httpClient;

    public ProductClient(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    // Get a product by its ID
    public async Task<Product> GetProductByIdAsync(int productId)
    {
      var product = await _httpClient.GetFromJsonAsync<Product>($"api/product/{productId}");

      if (product == null)
      {
        throw new Exception($"Product with ID {productId} not found.");
      }

      return product;
    }


    // Get all products
    public async Task<List<Product>> GetAllProductsAsync()
    {
      var products = await _httpClient.GetFromJsonAsync<List<Product>>("api/product");

      if (products == null)
      {
        throw new Exception("Products not found.");
      }
      return products;
    }

    // Update stock for a specific product
    public async Task UpdateProductStockAsync(int productId, int stock)
    {
      var data = new { ProductId = productId, Stock = stock };
      await _httpClient.PutAsJsonAsync("api/product/update-stock", data);
    }

    // Apply discount to a product
    public async Task ApplyDiscountToProductAsync(int productId, double discount)
    {
      var data = new { ProductId = productId, Discount = discount };
      await _httpClient.PutAsJsonAsync("api/product/apply-discount", data);
    }
  }
}