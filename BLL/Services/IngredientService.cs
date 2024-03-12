using BLL.Forms.Ingredient;
using BLL.Mappers;

namespace BLL.Services
{
    public class IngredientService
    {
        private readonly IIngredient _ingredientRepository;
        public IngredientService(IIngredient ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public Ingredient CreateIngredeint(CreateIngredientForm form)
        {
            Ingredient i = _ingredientRepository.GetByName(form.Name);
            if (i != null) return null;
            i = form.ToIngredientForm();
            _ingredientRepository.InsertIngredient(i);
            return i;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _ingredientRepository.GetAll();
        }

        public Ingredient GetById(int id)
        {
            return _ingredientRepository.GetById(id);
        }
    }
}
