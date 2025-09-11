using DataSource.VassCommerceDbContext;
using Dtos;
using Helpers.ApiResponseHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

[Route("api/pedido")]
[ApiController]
public class PedidoController : ControllerBase
{
    private VassCommerceDbContext _context;
    public PedidoController(VassCommerceDbContext context)
    {
        _context = context;
    }

    [HttpPost("{idcliente}")]
    public async Task<ActionResult<object>> CreatePedido(int idcliente, CreatePedidoDto req)
    {
        var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Id == idcliente);
        if (cliente == null) return NotFound(ApiResponseHelper.Error(404, "Cliente não encontrado"));
        var pedido = new PedidoModel(req.ValorTotal, req.StatusAtual)
        {
            Cliente = cliente
        };
        _context.Pedido.AddAsync(pedido);
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Pedido Criado", pedido));
    }
}