using BLL.Forms.Ingredient;

namespace BLL.Mappers
{
    public static class IngredientMapper
    {
        public static Ingredient ToIngredientForm(this CreateIngredientForm form)
        {
            return new Ingredient
            {
                Name = form.Name,
                Expiration = form.Expiration
            };
        }
    }
}
