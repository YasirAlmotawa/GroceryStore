public class UserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserService viewUserInfo(int id)
    {
        return _userRepository.GetUserById(id);
    }

    public void createUser(User user)
    {
        _userRepository.CreateUser(user);
        return;
    }

    public void updateUser(int id, User user)
    {
        _userRepository.UpdateUser(id, user);
        return;
    }

    public void deleteUser(int id
    {
        _userRepository.DeleteUser(id);
        return;
    }


}