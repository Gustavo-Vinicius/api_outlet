using Application_outlet.Business.DTOs;
using Application_outlet.Business.Interfaces.InterfaceRepository;
using Application_outlet.Business.Interfaces.InterfaceService;
using Application_outlet.Business.Models;

namespace Application_outlet.Business.Services
{
    public class ClienteServices : IServiceCliente
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteCadastradosDTO>> BuscarCadastroClientesAsync()
        {
            var result  = await _clienteRepository.ObterListagemDosClientesAsync();

            return result;
        }

        public async Task CadastrarClienteAsync(ClienteCadastro cliente)
        {
           var inserirCliente = new ClienteCadastro()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Idade = cliente.Idade,
                Nascimento = cliente.Nascimento,
                Cpf = cliente.Cpf,
                Cidade = cliente.Cidade,
                Uf = cliente.Uf
            };

             await _clienteRepository.CadastrarClienteAsync(inserirCliente);
        }


        public async Task UpdateClienteAsync(int Id, ClienteCadastro cliente)
        {
           var buscaCLiente = await _clienteRepository.BuscarClienteAsync(Id);

           buscaCLiente.Nome = cliente.Nome;
           buscaCLiente.Cpf = cliente.Cpf;
           buscaCLiente.Nascimento = cliente.Nascimento;
           buscaCLiente.Idade = cliente.Idade;
           buscaCLiente.Cidade = cliente.Cidade;
           buscaCLiente.Uf = cliente.Uf;

           await _clienteRepository.UpdateNoCadastroDeClienteAsync(buscaCLiente); 
        }

        public async Task DeletarClienteCadastradoAsync(int Id)
        {
           var cliente = await _clienteRepository.BuscarClienteAsync(Id);

           await _clienteRepository.DeletarClienteAsync(cliente);
        }
    }
}