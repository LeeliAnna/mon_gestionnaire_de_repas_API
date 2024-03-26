using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class UserMapper
    {
        public static User ToUserDB(this SqlDataReader reader)
        {
            return new User
            {
                UserId = (int)reader["User_id"],
                FirstName = (string)reader["First_name"],
                LastName = (string)reader["Last_name"],
                Email = (string)reader["Email"],
                Password = (string)reader["Password"],
                IsAdmin = (bool)reader["IsAdmin"],
                IsActive = (bool)reader["IsActive"],
                Pseudo = (string)reader["Pseudo"]
            };
        }
    }
}
