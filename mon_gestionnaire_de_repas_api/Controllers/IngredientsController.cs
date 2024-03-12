using BLL.Forms.Ingredient;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mon_gestionnaire_de_repas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientService _ingredientService;
        public IngredientsController(IngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpPost]
        public IActionResult Create(CreateIngredientForm form)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _ingredientService.CreateIngredeint(form);
            return Ok("Creation Réussie");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ingredientService.GetAll());
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id)
        {
            Ingredient i = _ingredientService.GetById(id);
            if(i == null) return BadRequest();
            return Ok(i);
        }
    }
}
