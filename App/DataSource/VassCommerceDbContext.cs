using Microsoft.EntityFrameworkCore;
using Models;

namespace DataSource.VassCommerceDbContext;

public class VassCommerceDbContext : DbContext
{
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
            .WithOne()
            .HasForeignKey<EnderecoModel>(e => e.ClienteId);

        modelBuilder.Entity<EnderecoModel>()
            .HasOne(e => e.Cidade)
            .WithMany()
            .HasForeignKey("CidadeId");

        modelBuilder.Entity<CidadeModel>()
            .HasOne(c => c.Estado)
            .WithMany(e => e.Cidades)
            .HasForeignKey(c => c.EstadoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CartaoModel>()
            .HasOne(c => c.Titular)
            .WithMany(c => c.Cartao)
            .HasForeignKey("TitularId");
    }

}