using Microsoft.EntityFrameworkCore;
using Models;

namespace DataSource.VassCommerceDbContext;

public class VassCommerceDbContext : DbContext
{
    public DbSet<CategoriaModel> Categoria { get; set; }
    public DbSet<EstadoModel> Estado { get; set; }
    public DbSet<CidadeModel> Cidade { get; set; }
    public DbSet<EnderecoModel> Endereco { get; set; }
    public DbSet<CartaoModel> Cartao { get; set; }
    public DbSet<ClienteModel> Cliente { get; set; }
    public VassCommerceDbContext(DbContextOptions<VassCommerceDbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=vassCommerce.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClienteModel>()
            .HasOne(c => c.Endereco)
            .WithOne(e => e.Cliente)
            .HasForeignKey<EnderecoModel>(e => e.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CidadeModel>()
            .HasMany(c => c.Enderecos)
            .WithOne(e => e.Cidade)
            .HasForeignKey(e => e.CidadeId)
            .IsRequired();

        modelBuilder.Entity<EstadoModel>()
            .HasMany(e => e.Cidades)
            .WithOne(c => c.Estado)
            .HasForeignKey(c => c.EstadoId);

        modelBuilder.Entity<ClienteModel>()
            .HasMany(c => c.FormasDePagamento)
            .WithOne(c => c.Titular)
            .HasForeignKey(c => c.TitularId);
    }

}