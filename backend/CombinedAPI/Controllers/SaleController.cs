using Microsoft.AspNetCore.Mvc;
using CombinedAPI.Models;
using CombinedAPI.Repositories;
using CombinedAPI.Services;
using CombinedAPI.Interfaces;

namespace CombinedAPI.Controllers
{
  [Route("api/sales")]
  [ApiController]
  public class SaleController : ControllerBase
  {
    private readonly ISaleEngine _saleEngine;
    public SaleController(ISaleEngine saleEngine)
    {
      _saleEngine = saleEngine;
    }

    // GET: api/sales/id/{id}
    [HttpGet("{id}")]
    public IActionResult GetSaleById(int id)
    {
      try
      {
        var sale = _saleEngine.GetSaleById(id);
        if (sale == null) 
        {
          return NotFound("No sale with this ID found!");
        }
        return Ok(sale);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

     // GET: api/sales
    [HttpGet]
    public IActionResult GetAllSales()
    {
      var sales = _saleEngine.GetAllSales();
      if (sales == null)
      {
        return NotFound("No sales going on right now!");
      }
      return Ok(sales);
    }

     // PUT: api/sales/update
    [HttpPut("update")]
    public IActionResult UpdateSale([FromBody] SaleUpdateRequest request)
    {
      var sale = new Sale
      {
        SaleID = request.SaleID,
        startDate = request.startDate,
        endDate = request.endDate,
        IsPercentage = request.IsPercentage,
        DiscountAmount = request.DiscountAmount
      };

      var success = _saleEngine.UpdateSale(sale);
      if (!success)
      {
        return BadRequest("Failed to update sale.");
      }
      return Ok("Sale update successfully");
    }

     // POST: api/sales/add
    [HttpPost("add")]
    public IActionResult AddSale([FromBody] SaleUpdateRequest request)
    {
      var sale = new Sale
      {
        SaleID = request.SaleID,
        startDate = request.startDate,
        endDate = request.endDate,
        IsPercentage = request.IsPercentage,
        DiscountAmount = request.DiscountAmount
      };

      var success = _saleEngine.AddSale(sale);
      if (!success)
      {
        return BadRequest("Failed to add sale.");
      }
      return Ok("Sale added successfully");
    }

  }
  public class SaleUpdateRequest
  {
    public int SaleID { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public bool IsPercentage { get; set; }
    public double DiscountAmount { get; set; }
  }
}