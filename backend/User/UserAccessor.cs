public class UserAccessor : IUserAccessor
{
    private IUserRepository _userRepository;

    public UserAccessor(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User GetUserById(int userId)
    {
        return _userRepository.GetUserById(userId);
    }

    public void CreateUser(User user)
    {
        _userRepository.CreateUser(user);
        return;
    }

    public void UpdateUser(int id, User user)
    {
        _userRepository.UpdateUser(id, user);
        return;
    }

    public void DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
        return;
    }
}