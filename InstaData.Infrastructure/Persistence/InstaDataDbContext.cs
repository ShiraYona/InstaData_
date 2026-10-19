using Microsoft.EntityFrameworkCore;

namespace InstaData.Infrastructure.Persistence;

/// <summary>
/// EF Core context for the InstaDataDB database.
/// Entity configurations live in the Configurations folder and are applied automatically.
/// </summary>
public class InstaDataDbContext : DbContext
{
    public InstaDataDbContext(DbContextOptions<InstaDataDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Picks up every IEntityTypeConfiguration<> in this assembly.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InstaDataDbContext).Assembly);
    }
}
