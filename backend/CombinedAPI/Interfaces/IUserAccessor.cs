using CombinedAPI.Models;

namespace CombinedAPI.Interfaces
{
  public interface IUserAccessor
  {
      List<User> GetAllUsers();
      public User GetUserById(int userId);
      bool UpdateUser(int id, User user);
      bool DeleteUser(int id);
      bool CreateUser(User user);
      bool AuthenticateUser(string username, string password);
  }
}