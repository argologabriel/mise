using Microsoft.EntityFrameworkCore;

namespace Mise.Infrastructure.DataAcess;

public class MiseDbContext : DbContext
{
	public MiseDbContext(DbContextOptions<MiseDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MiseDbContext).Assembly);
    }
}
