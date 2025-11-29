using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mise.Infrastructure.DataAcess;

namespace Mise.Infrastructure.Extensions;

public static class DatabaseMigrationExtension
{
	public static async Task Migrate(IServiceProvider serviceProvider)
	{
		using var scope = serviceProvider.CreateAsyncScope();

		var dbContext = scope.ServiceProvider.GetRequiredService<MiseDbContext>();

		await dbContext.Database.MigrateAsync();
	}		
}
