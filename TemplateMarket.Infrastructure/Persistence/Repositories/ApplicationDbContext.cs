using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Common.Interfaces;
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
    public DbSet<Category> Categories { get; set; }
    public DbSet<TemplateCategory> TemplateCategories { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<Commission> Commissions { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }

    // Adicione mais DbSets conforme você for criando mais entidades no futuro
    // public DbSet<OutraEntidade> OutraEntidade { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplica todas as configurações de entidades de forma automática
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IActivable).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(IActivable.IsActive));
                var filter = Expression.Lambda(Expression.Equal(property, Expression.Constant(true)), parameter);

                entityType.SetQueryFilter(filter);
            }
        }
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var utcNow = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedDate = utcNow;

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                entry.Entity.UpdatedDate = utcNow;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
