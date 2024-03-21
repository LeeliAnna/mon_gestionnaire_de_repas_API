
namespace DAL.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly string _connectionString;
        public IngredientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool DeleteIngredient(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Ingredients] " +
                                      "WHERE Ingredient_id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected == 1;

                }
            }
        }

        public IEnumerable<Ingredient> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * " +
                                      "FROM [Ingredients]";

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Ingredient> ingredients = new List<Ingredient>();
                    while (reader.Read())
                    {
                        ingredients.Add(reader.ToIngredientDB());
                    };
                    conn.Close();
                    return ingredients;

                }
            }
        }

        public Ingredient GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * " +
                                      "FROM [Ingredients] " +
                                      "WHERE Ingredient_id = @id";
                    cmd.Parameters.AddWithValue("id", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Ingredient i = null;

                    while (reader.Read())
                    {
                        i = reader.ToIngredientDB();
                    }
                    conn.Close();
                    return i;
                }
            }
        }

        public Ingredient GetByName(string name)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * " +
                                      "FROM [Ingredients] " +
                                      "WHERE Name = @name";
                    cmd.Parameters.AddWithValue("name", name);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Ingredient i = null;

                    while(reader.Read())
                    {
                        i = reader.ToIngredientDB();
                    }
                    conn.Close();
                    return i;

                }
            }
        }

        public Ingredient InsertIngredient(Ingredient i)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Ingredients](Name, Expiration) " +
                                      "VALUES (@name, @expiration)";

                    cmd.Parameters.AddWithValue("name", i.Name);
                    cmd.Parameters.AddWithValue("expiration", i.Expiration);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    return i;
                }
            }
        }

        public bool UpdateIngredient(Ingredient i)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Ingredients] " +
                                      "SET Name = @name, Expiration = @expiration " +
                                      "WHERE Ingredient_id = @id";
                    cmd.Parameters.AddWithValue("name", i.Name);
                    cmd.Parameters.AddWithValue("expiration", i.Expiration);
                    cmd.Parameters.AddWithValue("id", i.IngredientId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected == 1;

                }
            }
        }
    }
}
