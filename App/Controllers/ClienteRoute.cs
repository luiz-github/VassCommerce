using DataSource.VassCommerceDbContext;
using Models;
using Dtos;
using Microsoft.EntityFrameworkCore;
using Helpers.ApiResponseHelper;

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
            var endereco = await context.Endereco
                .FirstOrDefaultAsync(e => e.ClienteId == idcliente);
            if (endereco == null) return Results.Ok(ApiResponseHelper.Error(404, "Endereço não encontrado"));
            return Results.Ok(ApiResponseHelper.Success("Endereço encontrado", endereco));
        });

        
        route.MapPut("/{id}", async (Guid id, UpdateClienteDto req, VassCommerceDbContext context) =>
        {
            var cliente = await context.Cliente
                .FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null) return Results.Ok(ApiResponseHelper.Error(404, "Cliente não encontrado"));
            cliente.FotoUrl = req.FotoUrl ?? cliente.FotoUrl;
            cliente.DataNascimento = req.DataNascimento ?? cliente.DataNascimento;
            await context.SaveChangesAsync();
            return Results.Ok(ApiResponseHelper.Success("Cliente atualizado"));
        });

        route.MapDelete("/{id}", async (Guid id, VassCommerceDbContext context) =>
        {
            var cliente = await context.Cliente
                .FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null) return Results.Ok(ApiResponseHelper.Error(404, "Cliente não encontrado"));
            context.Cliente.Remove(cliente);
            await context.SaveChangesAsync();
            return Results.Ok(ApiResponseHelper.Success("Cliente deletado"));
        });
        
        route.MapPost("", async (CreateClienteDto req, VassCommerceDbContext context) =>
        {
            var cliente = new ClienteModel(req.FotoUrl, req.Cpf, req.DataNascimento);
            await context.Cliente.AddAsync(cliente);
            await context.SaveChangesAsync();
            return Results.Ok(ApiResponseHelper.Success("Cliente criado", cliente));
        });
    }
}