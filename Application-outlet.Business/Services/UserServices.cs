using Application_outlet.Business.DTOs;
using Application_outlet.Business.Interfaces.InterfaceRepository;
using Application_outlet.Business.Interfaces.InterfaceService;
using Application_outlet.Business.Models;

namespace Application_outlet.Business.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _user;

        public UserServices(IUserRepository user)
        {
            _user = user;
        }

        public async Task AdicionarUsuarioAsync(UserLogin user)
        {
            var addUser = new UserLogin()
            {
               UserName = user.UserName,
               Password = user.Password,
               Role = user.Role 
            };

            await _user.AdicionarUsusarioAsync(user);

        }

        public async Task<UserLogin> ObterUserClienteAsync(string UserName, string Password)
        {
           var teste = await _user.BuscaUsuarioAsync(UserName, Password);

           return teste;
        }
    }
}