namespace Mise.Domain.Repositories.User;

public interface IUserWriteRepository
{
	Task Add(Entities.User user);
}
