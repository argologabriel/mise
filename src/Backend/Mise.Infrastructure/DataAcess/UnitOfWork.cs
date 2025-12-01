using Mise.Domain.Repositories;

namespace Mise.Infrastructure.DataAcess;

public class UnitOfWork : IUnitOfWork
{
	private readonly MiseDbContext _dbContext;

	public UnitOfWork(MiseDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task Commit()
	{
		await _dbContext.SaveChangesAsync();
	}
}
