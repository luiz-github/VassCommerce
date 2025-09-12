using DataSource.VassCommerceDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Helpers.ApiResponseHelper;
using Models;
using Dtos;

namespace Controllers;

[Route("api/produto")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private VassCommerceDbContext _context;
    public ProdutoController(VassCommerceDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<object>> CreateProduto(CreateProdutoDto req)
    {
        var categorias = await _context.Categoria
            .Where(c => req.CategoriasId.Contains(c.Id))
            .ToListAsync();

        var produto = new ProdutoModel(req.Nome, req.Descricao, req.FotoUrl, DateTime.Now, req.ValorUnitario)
        {
            Categorias = categorias
        };
        await _context.Produto.AddAsync(produto);
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Produto criado", produto));
    }

    [HttpGet]
    public async Task<ActionResult<object>> GetFilteredProduto
    (
        [FromQuery] string? nome,
        [FromQuery] float? valorMinimo,
        [FromQuery] float? valorMaximo
    )
    {
        var query = _context.Produto.AsQueryable();

        if (!string.IsNullOrWhiteSpace(nome)) query = query.Where(p => p.Nome.Contains(nome));
        if (valorMinimo.HasValue) query = query.Where(p => p.ValorUnitario >= valorMinimo);
        if (valorMaximo.HasValue) query = query.Where(p => p.ValorUnitario <= valorMaximo);

        var produtos = await query.ToListAsync();
        if (!produtos.Any())
            return NotFound(ApiResponseHelper.Error(404, "Nenhum produto encontrado"));

        return Ok(ApiResponseHelper.Success("Produtos encontrados", produtos));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<object>> GetProduto(int id)
    {
        var produto = await _context.Produto.FirstOrDefaultAsync(p => p.Id == id);
        if (produto == null)
            return NotFound(ApiResponseHelper.Error(404, "Produto não encontrado"));

        return Ok(ApiResponseHelper.Success("Produto encontrado", produto));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<object>> DeleteProduto(int id)
    {
        var produto = await _context.Produto.FirstOrDefaultAsync(p => p.Id == id);
        if (produto == null)
            return NotFound(ApiResponseHelper.Error(404, "Produto não encontrado"));

        _context.Produto.Remove(produto);
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Produto deletado"));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<object>> UpdateProduto(int id, UpdateProdutoDto req)
    {
        var categorias = await _context.Categoria
            .Where(c => req.CategoriasId.Contains(c.Id))
            .ToListAsync();

        var produto = await _context.Produto.FirstOrDefaultAsync(p => p.Id == id);
        if (produto == null)
            return NotFound(ApiResponseHelper.Error(404, "Produto não encontrado"));

        produto.Nome = req.Nome ?? produto.Nome;
        produto.Descricao = req.Descricao ?? produto.Descricao;
        produto.FotoUrl = req.FotoUrl ?? produto.FotoUrl;
        produto.ValorUnitario = req.ValorUnitario ?? produto.ValorUnitario;
        produto.Categorias = categorias ?? produto.Categorias;

        _context.Produto.Update(produto);
        await _context.SaveChangesAsync();
        return Ok(ApiResponseHelper.Success("Produto atualizado"));
    }
}