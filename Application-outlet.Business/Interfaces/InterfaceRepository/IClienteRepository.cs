using Application_outlet.Business.DTOs;
using Application_outlet.Business.Models;

namespace Application_outlet.Business.Interfaces.InterfaceRepository
{
    public interface IClienteRepository
    {
        Task CadastrarClienteAsync(ClienteCadastro cliente); 
        
        Task<List<ClienteCadastradosDTO>> ObterListagemDosClientesAsync();

        Task UpdateNoCadastroDeClienteAsync(ClienteCadastro cliente);

        Task<ClienteCadastro> BuscarClienteAsync(int Id);

        Task DeletarClienteAsync(ClienteCadastro cliente);
    }
}