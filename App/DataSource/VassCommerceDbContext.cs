using Microsoft.EntityFrameworkCore;
using Models;

namespace DataSource.VassCommerceDbContext;

public class VassCommerceDbContext : DbContext
{
    public DbSet<ClienteModel> Cliente { get; set; }
    public DbSet<EnderecoModel> Endereco { get; set; }
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
            .OwnsOne(c => c.Endereco);
    }
}