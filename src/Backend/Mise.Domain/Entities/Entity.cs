namespace Mise.Domain.Entities;

public abstract class Entity
{
	public long Id { get; set; }
	public bool Active { get;  set; } = true;
	public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
