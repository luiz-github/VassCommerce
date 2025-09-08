using DataSource.VassCommerceDbContext;
using Dtos;
using Helpers.ApiResponseHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers;

[Route("api/estado")]
[ApiController]
public class EstadoController : ControllerBase
{
    private VassCommerceDbContext _context;
    public EstadoController(VassCommerceDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<object>> GetEstados()
    {
        var estados = await _context.Estado
            .ToListAsync();
        return Ok(ApiResponseHelper.Success("Estados encontrados", estados));
    }

    [HttpGet("{idestado}/cidade")]
    public async Task<ActionResult<object>> GetEstadoCidades(int idestado)
    {
        var cidades = await _context.Cidade.Where(c => c.EstadoId == idestado).ToListAsync();
        return Ok(ApiResponseHelper.Success("Estados encontrados", cidades));
    }
}