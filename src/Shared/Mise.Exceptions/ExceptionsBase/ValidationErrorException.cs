namespace Mise.Exceptions.ExceptionsBase;

public class ValidationErrorException : MiseException
{
	public IList<string> ErrorMessages { get; set; }

	public ValidationErrorException(IList<string> errorMessages)
	{
		ErrorMessages = errorMessages;
	}
}