namespace DAL.Interfaces
{
    public interface IIngredient
    {
        public Ingredient InsertIngredient(Ingredient i);
        public IEnumerable<Ingredient> GetAll();
        public Ingredient GetById(int id);
        public Ingredient GetByName(string name);
        public bool UpdateIngredient(Ingredient i);
        public bool DeleteIngredient(int id);
    }
}
