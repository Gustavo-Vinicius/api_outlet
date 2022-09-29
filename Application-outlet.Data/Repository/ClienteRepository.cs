using Application_outlet.Business.DTOs;
using Application_outlet.Business.Interfaces.InterfaceRepository;
using Application_outlet.Business.Models;
using Application_outlet.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Application_outlet.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly ContextDataBase _context;

        public ClienteRepository(ContextDataBase context)
        {
            _context = context;
        }

        public async Task<ClienteCadastro> BuscarClienteAsync(int Id)
        {
            return(await _context.ClienteCadastros.Where(p => p.Id == Id).FirstOrDefaultAsync());
        }

        public async Task CadastrarClienteAsync(ClienteCadastro cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }


        public async Task<List<ClienteCadastradosDTO>> ObterListagemDosClientesAsync()
        {
            var buscaCLiente = @"SELECT * FROM cliente_cadastro";

             var result = await _context.Database.GetDbConnection().QueryAsync<ClienteCadastradosDTO>(buscaCLiente);

             return result.ToList();
        }

        public async Task UpdateNoCadastroDeClienteAsync(ClienteCadastro cliente)
        {
            _context.Update(cliente);             
            await _context.SaveChangesAsync();
        }
        public async Task DeletarClienteAsync(ClienteCadastro cliente)
        {
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}