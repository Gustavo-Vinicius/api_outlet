using Application_outlet.Business.DTOs;
using Application_outlet.Business.Models;

namespace Application_outlet.Business.Interfaces.InterfaceRepository
{
    public interface IUserRepository
    {
        Task AdicionarUsusarioAsync(UserLogin login);
        Task<UserLogin> BuscaUsuarioAsync(string UserName , string Password); 

        
    }
}