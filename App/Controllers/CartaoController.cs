using DataSource.VassCommerceDbContext;
using Dtos;
using Helpers.ApiResponseHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers;

[Route("api/cliente")]
[ApiController]
public class CartaoController : ControllerBase
{
    private VassCommerceDbContext _context;
    public CartaoController(VassCommerceDbContext context)
    {
        _context = context;
    }

    [HttpGet("{idcliente}/formas-de-pagamento")]
    public async Task<ActionResult<object>> GetFormasPagamento(int idcliente)
    {
        var cliente = await _context.Cliente
            .Include(c => c.FormasDePagamento.Where(fp => fp.Excluido == false))
            .FirstOrDefaultAsync(c => c.Id == idcliente);
        if (cliente == null) return NotFound(ApiResponseHelper.Error(404, "Cliente não encontrado"));
        if (!cliente.FormasDePagamento.Any()) return NotFound(ApiResponseHelper.Error(404, "Formas de pagamento não encontradas"));
        return Ok(ApiResponseHelper.Success("Formas de pagamento encontradas", cliente.FormasDePagamento));
    }

    [HttpPost("{idcliente}/formas-de-pagamento")]
    public async Task<ActionResult<object>> CreateFormaPagamento(int idcliente, CreateCartaoDto req)
    {
        var cliente = await _context.Cliente
            .FirstOrDefaultAsync(c => c.Id == idcliente);
        if (cliente == null) return NotFound(ApiResponseHelper.Error(404, "Cliente não encontrado"));
        var cartao = new CartaoModel(req.Tipo)
        {
            Titular = cliente,
        };
        _context.Cartao.AddAsync(cartao);
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Forma de pagamento cadastrado"));
    }

    [HttpPut("{idcliente}/formas-de-pagamento/{idformapagamento}")]
    public async Task<ActionResult<object>> UpdateFormaPagamento(int idcliente, int idformapagamento, CreateCartaoDto req)
    {
        var cliente = await _context.Cliente
            .FirstOrDefaultAsync(c => c.Id == idcliente);
        if (cliente == null) return NotFound(ApiResponseHelper.Error(404, "Cliente não encontrado"));
        var formaDePagamento = await _context.Cartao
            .FirstOrDefaultAsync(c => c.TitularId == idcliente && c.Id == idformapagamento);
        if (formaDePagamento == null) return NotFound(ApiResponseHelper.Error(404, "Forma de pagamento não encontrada"));
        formaDePagamento.Tipo = req.Tipo;
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Forma de pagamento atualizado"));
    }

    [HttpDelete("{idcliente}/formas-de-pagamento/{idformapagamento}")]
    public async Task<ActionResult<object>> DeleteFormaPagamento(int idcliente, int idformapagamento)
    {
        var cliente = await _context.Cliente
            .FirstOrDefaultAsync(c => c.Id == idcliente);
        if (cliente == null) return NotFound(ApiResponseHelper.Error(404, "Cliente não encontrado"));
        var formaDePagamento = await _context.Cartao
            .FirstOrDefaultAsync(c => c.TitularId == idcliente && c.Id == idformapagamento);
        if (formaDePagamento == null) return NotFound(ApiResponseHelper.Error(404, "Forma de pagamento não encontrada"));
        formaDePagamento.Excluido = true;
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Forma de pagamento excluida"));
    }
}