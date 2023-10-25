using Domain.Endpoint;
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

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO campos)
        {
            List<User> usuarios = await _userService.Get();
            ServiceEncryptDecrypt enc = new ServiceEncryptDecrypt();

            bool autenticado = false;

            foreach (var user in usuarios)
            {
                string password = enc.Decrypt(user.UserPassword);
                if (user.UserEmail == campos.UserEmail && password == campos.UserPassword)
                {
                    autenticado = true;
                    break; // Sal del bucle si la autenticación es exitosa.
                }
            }

            if (autenticado)
            {
                return Ok("Login successful");
            }
            else
            {
                return Ok("Login denied");
            }
        }

    }
}
