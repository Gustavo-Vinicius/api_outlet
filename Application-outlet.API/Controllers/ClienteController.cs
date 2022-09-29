using Application_outlet.Business.Interfaces.InterfaceService;
using Application_outlet.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application_outlet.API.Controllers;

[ApiController]
[Route("api/controller")]
public class ClienteController : ControllerBase
{
    private readonly IServiceCliente _serviceCLiente;

    public ClienteController(IServiceCliente serviceCLiente)
    {
        _serviceCLiente = serviceCLiente;
    }

    [HttpPost("cadastrar-cliente")]
    public async Task<IActionResult> CadastrarClienteAsync(ClienteCadastro cliente)
    {
        await _serviceCLiente.CadastrarClienteAsync(cliente);

        return Ok();
    }


    [HttpGet("buscar-clientes")]
    public async Task<IActionResult> ObterListagemDeClientesCadastradosAsync()
    {
        return Ok(await _serviceCLiente.BuscarCadastroClientesAsync());
    }

    [HttpPut("update-cliente")]
    public async Task<IActionResult> UpdateNoCadastroDeClienteAsync([FromBody] ClienteCadastro cliente, int Id)
    {
        await _serviceCLiente.UpdateClienteAsync(Id, cliente);

        return Ok();
    }

    [HttpDelete("deletar-cliente")]
    public async Task<IActionResult> DeletarClienteAsync(int Id)
    {
        await _serviceCLiente.DeletarClienteCadastradoAsync(Id);

       return Ok();
    }
}
