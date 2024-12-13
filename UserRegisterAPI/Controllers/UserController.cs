using Microsoft.AspNetCore.Mvc;
using UserRegisterAPI.Application;
using UserRegisterAPI.Domain;

namespace UserRegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserMessageService _messageService;

        public UserController(UserMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _messageService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult PostAddUser([FromBody] User user)
        {
            _messageService.RegisterUser(user);
            return Ok(new { Message = "Usuario registrado y mensaje enviado correctamente." });
        }
    }

}
