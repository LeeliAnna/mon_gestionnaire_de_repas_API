namespace DAL.Mappers
{
    public static class IngredientMapper
    {
        public static Ingredient ToIngredientDB(this SqlDataReader reader)
        {
            return new Ingredient
            {
                IngredientId = (int)reader["Ingredient_id"],
                Name = (string)reader["Name"],
                Expiration = (DateTime)reader["Expiration"]
            };
        }
    }
}
