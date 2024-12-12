using System.Data.SqlClient;

public interface IUserRepository
{
    void CreateUser(User user);
    void UpdateUser(int id, User user);
    void DeleteUser(int id);
    public User GetUserById(int id);
}