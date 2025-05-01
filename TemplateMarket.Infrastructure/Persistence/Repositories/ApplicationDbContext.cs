using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TemplateMarket.Domain.Common.Entities;
using TemplateMarket.Domain.Common.Interfaces;
using TemplateMarket.Domain.Entities;

namespace TemplateMarket.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    private IMediator _mediator;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IMediator mediator
    ) : base(options) {
        _mediator = mediator;
    }

    // DbSets para as entidades
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderItemService> OrderItemServices { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<Commission> Commissions { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Entity> Entities { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ServiceDetail> ServiceDetails { get; set; }
    public DbSet<TemplateDetail> TemplateDetails { get; set; }

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

        // 1. Encontra entidades com eventos
        var domainEntities = ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .ToList();

        // 2. Coleta todos os eventos
        var domainEvents = domainEntities
            .SelectMany(e => e.Entity.DomainEvents)
            .ToList();

        // 3. Limpa eventos das entidades
        domainEntities.ForEach(e => e.Entity.ClearDomainEvents());

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedDate = utcNow;

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                entry.Entity.UpdatedDate = utcNow;
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        // 5. Publica os eventos
        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }

        return result;
    }
}
