public interface IUserAccessor
{
    public User GetUserById(int userId);
    void CreateUser(User user);
    void UpdateUser(int id, User user);
    void DeleteUser(int id);
}