using System.Data.SqlClient;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public UserRepository GetUserById(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM Users WHERE UserID = @Id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.read())
                    {
                        return new User
                        {
                            id = (int)reader["UserID"],
                            username = reader["Username"].ToString(),
                            description = reader["Description"].ToString(),
                            password = reader["PasswordHash"].ToString(),
                            email = reader["Email"].ToString()
                        }
                    }
                }
            }
        }
        return null;
    }

    public UserRepository CreateUser(User user)
    {
        using (var connection = new SqlConnection(_connectionString))
        {

            var query = @"INSERT INTO Users (Username, PasswordHash, Email) 
                          VALUES (@Username, @PasswordHash @Email);
                          SELECT CAST(SCOPE_IDENTITY() as int)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                connection.Parameters.AddWithValue("@Username", user.username);
                connection.Parameters.AddWithValue("@PasswordHash", user.password);
                connection.Parameters.AddWithValue("@Email", user.email);
                connection.ExecuteNonQuery();
                connection.Close();
                return;
            }
        }
    }

    public UserRepository UpdateUser(int id, User user)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = @"UPDATE Users SET Username = @Username, PasswordHash = @PasswordHash, Email = @Email 
                          WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                connection.Parameters.AddWithValue("@Username", user.username);
                connection.Parameters.AddWithValue("@PasswordHash", user.password);
                connection.Parameters.AddWithValue("@Email", user.email);
                connection.Parameters.AddWithValue("@Id", id);
                connection.ExecuteNonQuery();
                connection.Close();
                return;
            }
        }
    }

    public UserRepository DeleteUser(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = "DELETE FROM Users WHERE UserID = @Id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                connection.Parameters.AddWithValue("@Id", id);
                connection.ExecuteNonQuery();
                connection.Close();
                return;
            }
        }
    }
}