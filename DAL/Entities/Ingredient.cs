

namespace DAL.Entities
{
    public class Ingredient
    {

        public int IngredientId { get; set; }
        public string Name { get; set; } = default!;
        public DateTime Expiration { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(string name, DateTime expiration) : this() 
        {
            Name = name;
            Expiration = expiration;
        }
    }
}
