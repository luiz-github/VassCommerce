using DataSource.VassCommerceDbContext;
using Models;
using Dtos;
using Microsoft.EntityFrameworkCore;
using Helpers.ApiResponseHelper;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[Route("api/categoria")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private VassCommerceDbContext _context;
    public CategoriaController(VassCommerceDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<object>> GetCategorias([FromQuery] string? nome)
    {
        var query = _context.Categoria.AsQueryable();
        if (!string.IsNullOrWhiteSpace(nome)) query = query.Where(c => c.Nome.Contains(nome));
        var categorias = await query.ToListAsync();
        if (!categorias.Any()) return NotFound(ApiResponseHelper.Error(404, "Categoria não encontrada"));
        return Ok(ApiResponseHelper.Success("Categoria encontrada", categorias));
    }

    [HttpGet("{idcategoria}/produto")]
    public async Task<ActionResult<object>> GetCategorias
    (
        int idcategoria,
        [FromQuery] string? nome,
        [FromQuery] float? valorMinimo,
        [FromQuery] float? valorMaximo
    )
    {
        var categoria = await _context.Categoria
                .Include(c => c.Produtos)
            .FirstOrDefaultAsync(c => c.Id == idcategoria);

        var query = categoria.Produtos.AsQueryable();

        if (!string.IsNullOrWhiteSpace(nome)) query = query.Where(p => p.Nome.Contains(nome));
        if (valorMinimo.HasValue) query = query.Where(p => p.ValorUnitario >= valorMinimo);
        if (valorMaximo.HasValue) query = query.Where(p => p.ValorUnitario <= valorMaximo);

        var produtos = query.ToList();

        if (!produtos.Any()) return NotFound(ApiResponseHelper.Error(404, "Categoria não encontrada"));
        return Ok(ApiResponseHelper.Success("Categoria encontrada", produtos));
    }
}