using Application_outlet.Business.DTOs;
using Application_outlet.Business.Models;

namespace Application_outlet.Business.Interfaces.InterfaceService
{
    public interface IUserServices
    {
         Task AdicionarUsuarioAsync(UserLogin user);

         Task<UserLogin> ObterUserClienteAsync(string UserName, string Password);
    }
}