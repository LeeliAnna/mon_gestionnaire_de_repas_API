using BLL.Forms.User;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mon_gestionnaire_de_repas_api.Tools;

namespace mon_gestionnaire_de_repas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserForm form)
        {
            if(ModelState.IsValid)
            {
                if (_userService.CreateUser(form) == null) return BadRequest();
                _userService.CreateUser(form);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid) return BadRequest();
            User? connected = _userService.Login(form.Email, form.Password);
            if (connected is null) return BadRequest();

            TokenManager tokenManager = new TokenManager();
            return Ok(new { token = tokenManager.GeneretedToken(connected) });
        }


        //[Authorize("connected")]
        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        //[Authorize("connected")]
        [HttpGet("byId/{id}")]
        public IActionResult GetUserById(int id)
        {
            User u = _userService.GetById(id);
            if(u is null) return NotFound();
            return Ok(u);
        }

    }
}
