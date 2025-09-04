using DataSource.VassCommerceDbContext;
using Models;
using Dtos;
using Microsoft.EntityFrameworkCore;
using Helpers.ApiResponseHelper;
using Microsoft.AspNetCore.Mvc;

namespace Routes;
public static class ClienteRoute
{
    public static void ClienteRoutes(this WebApplication app)
    {
        var route = app.MapGroup("cliente");

        route.MapGet("/{id}", async (Guid id, VassCommerceDbContext context) =>
        {
            var cliente = await context.Cliente
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null) return Results.Ok(ApiResponseHelper.Error(404, "Cliente não encontrado"));
            return Results.Ok(ApiResponseHelper.Success("Cliente encontrado", cliente));
        });
        
        route.MapGet("/{idcliente}/endereco", async (Guid idcliente, VassCommerceDbContext context) =>
        {
            var cliente = await context.Cliente
            .Include(c => c.Endereco)
            .FirstOrDefaultAsync(c => c.Id == idcliente);
            if (cliente == null) return Results.Ok(ApiResponseHelper.Error(404, "Cliente não encontrado"));
            return Results.Ok(ApiResponseHelper.Success("Cliente encontrado", cliente.Endereco));
        });
    }
}