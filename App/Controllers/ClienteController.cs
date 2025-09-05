using DataSource.VassCommerceDbContext;
using Models;
using Dtos;
using Microsoft.EntityFrameworkCore;
using Helpers.ApiResponseHelper;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[Route("api/cliente")]
[ApiController]
public class ClienteController : ControllerBase
{
    private VassCommerceDbContext _context;
    public ClienteController(VassCommerceDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<object>> GetClienteById(int id)
    {
        var cliente = await _context.Cliente
            .Include(c => c.Endereco)
            .ThenInclude(e => e.Cidade)
            .ThenInclude(c => c.Estado)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (cliente == null) return NotFound(ApiResponseHelper.Error(404, "Cliente não encontrado"));
        return Ok(ApiResponseHelper.Success("Cliente encontrado", cliente));

    }

    [HttpGet("{idcliente}/endereco")]
    public async Task<ActionResult<object>> GetEnderecoCliente(int idcliente)
    {
        var endereco = await _context.Endereco
            .FirstOrDefaultAsync(e => e.ClienteId == idcliente);
        if (endereco == null) return NotFound(ApiResponseHelper.Error(404, "Endereço não encontrado"));
        return Ok(ApiResponseHelper.Success("Endereço encontrado", endereco));
    }

    [HttpPut("{idcliente}/endereco")]
    public async Task<ActionResult<object>> UpdateEnderecoCliente(int idcliente, [FromBody] CreateEnderecoDto req)
    {
        var cidade = await _context.Cidade.FirstOrDefaultAsync(c => c.Id == req.CidadeId);
        if (cidade == null)
            return NotFound(ApiResponseHelper.Error(404, "Cidade não encontrada"));

        var endereco = await _context.Endereco.FirstOrDefaultAsync(c => c.Id == idcliente);
        if (endereco == null)
            return NotFound(ApiResponseHelper.Error(404, "Endereco não encontrada"));

        endereco.Rua = req.Rua;
        endereco.Numero = req.Numero;
        endereco.Cep = req.Cep;
        endereco.Complemento = req.Complemento;
        endereco.Telefone = req.Telefone;
        endereco.Bairro = req.Bairro;
        endereco.DataUltimaAtualizacao = DateTime.Now;
        endereco.CidadeId = cidade.Id;
        endereco.Cidade = cidade;

        _context.Endereco.Update(endereco);
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Endereço atualizado", endereco));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<object>> UpdateCliente(int id, UpdateClienteDto req)
    {
        var cliente = await _context.Cliente
            .FirstOrDefaultAsync(c => c.Id == id);
        if (cliente == null) return NotFound(ApiResponseHelper.Error(404, "Cliente não encontrado"));
        cliente.FotoUrl = req.FotoUrl ?? cliente.FotoUrl;
        cliente.DataNascimento = req.DataNascimento ?? cliente.DataNascimento;
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Cliente atualizado"));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<object>> DeleteCliente(int id)
    {
        var cliente = await _context.Cliente
            .FirstOrDefaultAsync(c => c.Id == id);
        if (cliente == null) return NotFound(ApiResponseHelper.Error(404, "Cliente não encontrado"));
        _context.Cliente.Remove(cliente);
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Cliente deletado"));
    }

    [HttpPost]
    public async Task<ActionResult<object>> CreateCliente(CreateClienteDto req)
    {
        var cliente = new ClienteModel(req.FotoUrl, req.Cpf, req.DataNascimento);
        await _context.Cliente.AddAsync(cliente);
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Cliente criado", cliente));
    }
}