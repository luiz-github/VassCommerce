using DataSource.VassCommerceDbContext;
using Models;
using Dtos.ClienteDto;
using Microsoft.EntityFrameworkCore;
using Helpers.ApiResponseHelper;

namespace Routes.ClienteRoute;
public static class ClienteRoute
{
    public static void ClienteRoutes(this WebApplication app)
    {
        var route = app.MapGroup("clientes");

        route.MapGet("/{id}", async (Guid id, VassCommerceDbContext context) =>
        {
            var cliente = await context.Cliente.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null) return Results.Ok(ApiResponseHelper.Error(404, "Cliente não encontrado")); 
            return Results.Ok(ApiResponseHelper.Success("Cliente encontrado", cliente));
        });

        route.MapPost("/", async (CreateClienteDto req, VassCommerceDbContext context) =>
        {
            var cliente = new ClienteModel(req.FotoUrl, req.DataNascimento);
            if (cliente == null) return Results.Ok(ApiResponseHelper.Error(500, "Erro ao criar cliente")); 
            await context.AddAsync(cliente);
            await context.SaveChangesAsync();
            return Results.Ok(ApiResponseHelper.Success("Cliente criado com sucesso", cliente));
        });
    }
}