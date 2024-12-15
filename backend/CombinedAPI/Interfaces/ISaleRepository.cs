using CombinedAPI.Models;

namespace CombinedAPI.Interfaces
{
  public interface ISaleRepository
  {
    Sale GetSaleById(int saleId);
    List<Sale> GetAllSales();
    bool AddSale(Sale sale);
    bool UpdateSale(Sale sale);
  }
}