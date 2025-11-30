using Microsoft.EntityFrameworkCore;
using Mise.Domain.Entities;

namespace Mise.Infrastructure.DataAcess;

public class MiseDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

	public MiseDbContext(DbContextOptions<MiseDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MiseDbContext).Assembly);
    }
}
