using System.ComponentModel.DataAnnotations;

namespace BLL.Forms.Ingredient
{
    public class CreateIngredientForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Expiration { get; set; }
    }
}
