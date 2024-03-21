using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public User CreateUser(User user)
        {
            using(SqlConnection conn = _connection)
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Users] " +
                                      "VALUES (@firstName, " +
                                              "@lastName, " +
                                              "@pseudo, " +
                                              "@email, " +
                                              "@password, " +
                                              "@role)";

                    cmd.Parameters.AddWithValue("firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("lastName", user.LastName);
                    cmd.Parameters.AddWithValue("pseudo", user.Pseudo);
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("password", user.Password);
                    cmd.Parameters.AddWithValue("role", user.Role);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    return user;
                }
            }
            
        }

        public bool DeleteUser(int id)
        {
            using (SqlConnection conn = _connection)
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Users] " +
                                      "WHERE User_id = @id";

                    cmd.Parameters.AddWithValue("id", id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    
                    return rowsAffected == 1;
                }
            }
        }

        public List<User> GetAllUsers()
        {
            using (SqlConnection conn = _connection)
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * " +
                                      "FROM [Users]";

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<User> users = new List<User>();
                    while (reader.Read())
                    {
                        users.Add(reader.ToUserDB());
                    }
                    conn.Close();
                    return users;
                }
            }
        }

        public User GetByEmail(string email)
        {
            using (SqlConnection conn = _connection)
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * " +
                                      "FROM [Users] " +
                                      "WHERE Email = @email";

                    cmd.Parameters.AddWithValue("email", email);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    User user = null;
                    while (reader.Read())
                    {
                        user = reader.ToUserDB();
                    }
                    conn.Close();
                    return user;
                }
            }
        }

        public User GetUserById(int id)
        {
            using (SqlConnection conn = _connection)
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * " +
                                      "FROM [Users] " +
                                      "WHERE User_id = @id";

                    cmd.Parameters.AddWithValue("id", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    User user = null;
                    while (reader.Read())
                    {
                        user = reader.ToUserDB();
                    }
                    conn.Close();
                    return user;
                }
            }
        }

        public bool UpdateUser(User user)
        {
            using (SqlConnection conn = _connection)
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Users] " +
                                      "SET FirstName = @firstName, " +
                                          "LastName = @lastName, " +
                                          "Pseudo = @pseudo, " +
                                          "Email = @email, " +
                                          "Password = @password, " +
                                          "Role = @role " +
                                          "WHERE User_id = @id";

                    cmd.Parameters.AddWithValue("firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("lastName", user.LastName);
                    cmd.Parameters.AddWithValue("pseudo", user.Pseudo);
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("password", user.Password);
                    cmd.Parameters.AddWithValue("role", user.Role);
                    cmd.Parameters.AddWithValue("id", user.UserId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected == 1;
                }
            }
        }
    }
}
