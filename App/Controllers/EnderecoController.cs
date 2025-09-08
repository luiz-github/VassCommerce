using DataSource.VassCommerceDbContext;
using Dtos;
using Helpers.ApiResponseHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers;

[Route("api/endereco")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private VassCommerceDbContext _context;
    public EnderecoController(VassCommerceDbContext context)
    {
        _context = context;
    }

    [HttpPost("{idcliente}")]
    public async Task<ActionResult<object>> CreateEndereco(int idcliente, [FromBody] CreateEnderecoDto req)
    {
        var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Id == idcliente);
        if (cliente == null) return NotFound(ApiResponseHelper.Error(404, "Cliente não encontrado"));
        var cidade = await _context.Cidade.FirstOrDefaultAsync(c => c.Id == req.CidadeId);
        if (cidade == null) return NotFound(ApiResponseHelper.Error(404, "Cidade não encontrada"));
        var endereco = new EnderecoModel(
            req.Rua,
            req.Numero,
            req.Cep,
            req.Complemento,
            req.Telefone,
            req.Bairro,
            DateTime.Now
        )
        {
            ClienteId = cliente.Id,
            Cliente = cliente,
            CidadeId = cidade.Id,
            Cidade = cidade
        };
        await _context.Endereco.AddAsync(endereco);
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Endereço criado", endereco));
    }

    [HttpGet("/api/cliente/{idcliente}/endereco")]
    public async Task<ActionResult<object>> GetEnderecoCliente(int idcliente)
    {
        var endereco = await _context.Endereco
            .FirstOrDefaultAsync(e => e.ClienteId == idcliente);
        if (endereco == null) return NotFound(ApiResponseHelper.Error(404, "Endereço não encontrado"));
        return Ok(ApiResponseHelper.Success("Endereço encontrado", endereco));
    }

    [HttpPut("/api/cliente/{idcliente}/endereco")]
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
}