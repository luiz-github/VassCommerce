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
    
    [HttpPost("/{idcliente}")]
    [ActionName("ação")]
    public async Task<ActionResult<object>> CreateEndereco(Guid idcliente, CreateEnderecoDto req)
    {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Id == idcliente);
            if (cliente == null) return NotFound(ApiResponseHelper.Error(404,"Cliente não encontrado"));
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
                Cliente = cliente
            };
            await _context.Endereco.AddAsync(endereco);
            await _context.SaveChangesAsync();
            return Ok(ApiResponseHelper.Success("Endereço criado", endereco));
    }
}