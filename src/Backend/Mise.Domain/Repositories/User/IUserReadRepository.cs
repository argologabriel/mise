namespace Mise.Domain.Repositories.User;

public interface IUserReadRepository
{
	Task<bool> ExistActiveUserWithEmail(string email);
}