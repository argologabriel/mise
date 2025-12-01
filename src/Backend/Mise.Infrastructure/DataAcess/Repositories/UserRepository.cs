using Mise.Domain.Entities;
using Mise.Domain.Repositories.User;

namespace Mise.Infrastructure.DataAcess.Repositories;

public class UserRepository : IUserWriteRepository
{
	private readonly MiseDbContext _dbContext;

	public UserRepository(MiseDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task Add(User user)
	{
		await _dbContext.Users.AddAsync(user);
	}
}
