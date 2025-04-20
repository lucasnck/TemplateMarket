using Microsoft.EntityFrameworkCore;
using TemplateMarket.Domain.Entities;
using TemplateMarket.Infrastructure.Persistence.Configurations;

namespace TemplateMarket.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // DbSets para as entidades
    public DbSet<Template> Templates { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<TemplatePlatform> TemplatePlatforms { get; set; }

    // Adicione mais DbSets conforme você for criando mais entidades no futuro
    // public DbSet<OutraEntidade> OutraEntidade { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplica todas as configurações de entidades de forma automática
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
