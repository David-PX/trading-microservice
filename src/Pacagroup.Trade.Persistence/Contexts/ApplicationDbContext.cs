using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Persistence;
using Pacagroup.Trade.Domain.Entities;
using Pacagroup.Trade.Persistence.Interceptors;

namespace Pacagroup.Trade.Persistence.Contexts
{
  public class ApplicationDbContext : DbContext, IApplicationDbContext
  {
    public readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
                                AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
    {
      _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
      optionsBuilder.EnableSensitiveDataLogging();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      return await base.SaveChangesAsync(cancellationToken);
    }
  }
}