using Application_outlet.Business.DTOs;
using Application_outlet.Business.Interfaces.InterfaceService;
using Application_outlet.Business.Models;
using Application_outlet.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application_outlet.API.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _user;

        public UserController(IUserServices user)
        {
            _user = user;
        }

        [HttpPost("adciona-usuario")]
        public async Task<IActionResult> AdiconarUsuarioAsync(UserLogin user)
        {
            await _user.AdicionarUsuarioAsync(user);

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Auteticacao([FromBody] UserClienteDTO cliente)
        {
            var user = await _user.ObterUserClienteAsync(cliente.UserName, cliente.Password);

            TokenService tokenUser = new TokenService();

            if (user == null)
            {
                throw new Exception("Usuario ou senha invalidos");
            }

            var token = tokenUser.GenerateToken(user);

            cliente.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}