namespace Mise.Domain.Repositories;

public interface IUnitOfWork
{
	Task Commit();
}
