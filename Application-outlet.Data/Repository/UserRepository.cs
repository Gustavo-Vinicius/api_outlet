using Application_outlet.Business.DTOs;
using Application_outlet.Business.Interfaces.InterfaceRepository;
using Application_outlet.Business.Models;
using Application_outlet.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Application_outlet.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDataBase _context;

        public UserRepository(ContextDataBase context)
        {
            _context = context;
        }

        public async Task AdicionarUsusarioAsync(UserLogin user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();

        }

        public async Task<UserLogin> BuscaUsuarioAsync(string UserName , string Password)
        {
            var query = "SELECT \"UserName\", \"Password\"  FROM user_login WHERE \"UserName\" = @UserName and \"Password\" = @Password";

             return (await _context.Database.GetDbConnection().QuerySingleAsync<UserLogin>(query, new {UserName, Password}));

            
        }
    }
}