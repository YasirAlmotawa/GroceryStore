namespace Product
{


  using Microsoft.AspNetCore.Mvc;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly IProductManager _productManager;

    // Constructor for Dependency Injection
    public ProductController(IProductManager productManager)
    {
      _productManager = productManager;
    }

    // GET: api/product/{id}
    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
      Console.WriteLine($"Getting product by ID: {id}");
      var product = _productManager.GetProductById(id);
      if (product == null)
      {
        return NotFound("Product not found.");
      }
      return Ok(product);
    }

    // GET: api/product
    [HttpGet]
    public IActionResult GetAllProducts()
    {
      var products = _productManager.GetAllProducts();
      return Ok(products);
    }

    // PUT: api/product/update-stock
    [HttpPut("update-stock")]
    public IActionResult UpdateProductStock([FromBody] UpdateStockRequest request)
    {
      var success = _productManager.UpdateProductStock(request.ProductId, request.Stock);
      if (!success)
      {
        return BadRequest("Failed to update stock.");
      }
      return Ok("Stock updated successfully.");
    }

    // PUT: api/product/apply-discount
    [HttpPut("apply-discount")]
    public IActionResult ApplyDiscountToProduct([FromBody] ApplyDiscountRequest request)
    {
      var success = _productManager.ApplyDiscountToProduct(request.ProductId, request.Discount);
      if (!success)
      {
        return BadRequest("Failed to apply discount.");
      }
      return Ok("Discount applied successfully.");
    }
  }

  // Request models for updating stock and discount
  public class UpdateStockRequest
  {
    public int ProductId { get; set; }
    public int Stock { get; set; }
  }

  public class ApplyDiscountRequest
  {
    public int ProductId { get; set; }
    public double Discount { get; set; }
  }
}
