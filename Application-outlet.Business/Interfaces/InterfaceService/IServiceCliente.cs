using Application_outlet.Business.DTOs;
using Application_outlet.Business.Models;

namespace Application_outlet.Business.Interfaces.InterfaceService
{
    public interface IServiceCliente
    {
         Task CadastrarClienteAsync(ClienteCadastro cliente);

         Task<List<ClienteCadastradosDTO>> BuscarCadastroClientesAsync();

         Task UpdateClienteAsync(int Id, ClienteCadastro cliente);

         Task DeletarClienteCadastradoAsync(int Id);
    }
}