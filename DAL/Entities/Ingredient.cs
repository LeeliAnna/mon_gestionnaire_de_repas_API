

namespace DAL.Entities
{
    public class Ingredient
    {

        public int IngredientId { get; set; }
        public string Name { get; set; } = default!;
        public DateTime Expiration { get; set; }
        public string UnitMeasurment { get; set; } = default!;

        public Ingredient()
        {
        }

        public Ingredient(string name, DateTime expiration, string unitMeasurment) : this() 
        {
            Name = name;
            Expiration = expiration;
            UnitMeasurment = unitMeasurment;
        }
    }
}
