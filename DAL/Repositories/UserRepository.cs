using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connection;

        public UserRepository(string connection)
        {
            _connection = connection;
        }

        public User CreateUser(User user)
        {
            using(SqlConnection conn = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Users]" +
                                                  "(First_name, Last_name, Pseudo, Email, Password) " +
                                      "VALUES (@firstName, " +
                                              "@lastName, " +
                                              "@pseudo, " +
                                              "@email, " +
                                              "@password)";

                    cmd.Parameters.AddWithValue("firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("lastName", user.LastName);
                    cmd.Parameters.AddWithValue("pseudo", user.Pseudo);
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("password", user.Password);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    return user;
                }
            }
            
        }

        public bool DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Users] " +
                                      "SET IsActive = 0" +
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
            using (SqlConnection conn = new SqlConnection(_connection))
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
            using (SqlConnection conn = new SqlConnection(_connection))
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
            using (SqlConnection conn = new SqlConnection(_connection))
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
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Users] " +
                                      "(First_name, Last_name, Pseudo, Email, Password) " +
                                      "SET FirstName = @firstName, " +
                                          "LastName = @lastName, " +
                                          "Pseudo = @pseudo, " +
                                          "Email = @email, " +
                                          "Password = @password " +
                                          "WHERE User_id = @id";

                    cmd.Parameters.AddWithValue("firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("lastName", user.LastName);
                    cmd.Parameters.AddWithValue("pseudo", user.Pseudo);
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("password", user.Password);
                    cmd.Parameters.AddWithValue("role", user.IsAdmin);
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
