using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn2SwitchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Create(UserDTO nuevoUser)
        {
            User newUser = _userService.createUser(nuevoUser);
            return Ok(newUser);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUsuarioById(Guid Id)
        {
            User usuario = _userService.FilterUser(Id);
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsuario()
        {
            List<User> usuario = await _userService.Get();
            return Ok(usuario);
        }

    }
}
