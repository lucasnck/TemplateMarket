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
    private readonly IDomainEventDispatcher _dispatcher;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IMediator mediator, 
        IDomainEventDispatcher dispatcher
    ) : base(options) {
        _mediator = mediator;
        _dispatcher = dispatcher;
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
    public DbSet<UserCompany> UserCompanies { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }   
    public DbSet<ServiceDetail> ServiceDetails { get; set; }
    public DbSet<TemplateDetail> TemplateDetails { get; set; }

    public DbSet<Role> Roles { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupRole> GroupRoles { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserCompanyGroup> UserCompanyGroups { get; set; }
    public DbSet<GroupTemplate> GroupTemplates { get; set; }

    public DbSet<Workflow> Workflow { get; set; }
    public DbSet<Processor> Processor { get; set; }
    public DbSet<ProcessorOutput> ProcessorOutput { get; set; }
    public DbSet<ProcessorStep> ProcessorStep { get; set; }
    public DbSet<WorkflowItem> WorkflowItem { get; set; }
    public DbSet<WorkflowItemProcessor> WorkflowItemProcessor { get; set; }
    public DbSet<WorkflowItemProcessorStep> WorkflowItemProcessorStep { get; set; }


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

        // 1. Atualiza timestamps
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedDate = utcNow;

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                entry.Entity.UpdatedDate = utcNow;
        }

        // 2. Coleta entidades com eventos ANTES do save
        var domainEntities = ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

        // 3. Salva no banco (agora os IDs são populados)
        var result = await base.SaveChangesAsync(cancellationToken);

        // 4. Dispara os eventos AGORA que os dados estão completos
        await _dispatcher.DispatchEventsAsync(domainEntities, cancellationToken);

        // 5. Limpa eventos (boa prática)
        domainEntities.ForEach(e => e.ClearDomainEvents());

        return result;
    }
}
