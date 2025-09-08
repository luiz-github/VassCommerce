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