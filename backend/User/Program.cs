using System;

public class Program
{
    public void Main(string[] args)
    {
        string connectionString = "";

        int id = 0;

        IUserRepository userRepository = new UserRepository(connectionString);

        IUserAccessor userAccessor = new UserAccessor(userRepository);

        User user = userAccessor.GetUserById(id);

        if (user != null)
        {
            Console.WriteLine($"Username: {user.username}, Email: {user.email}, Email: {user.password}");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }
}