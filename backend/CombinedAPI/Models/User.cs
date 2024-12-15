namespace CombinedAPI.Models
{
  public class User
  {
    public int userID { get; set; }
    public string username { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string address { get; set; }
    public string email { get; set; }
    public string phoneNumber { get; set; }
    public string password { get; set; }
    public string creditcardNumber { get; set; }
    public string creditcardExpDate { get; set; }
    public int cvv { get; set; }
    public string shippingLocation { get; set; }
  }
}