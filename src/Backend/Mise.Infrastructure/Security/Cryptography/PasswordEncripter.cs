using Mise.Domain.Security.Cryptography;

namespace Mise.Application.Services.Cryptography;

public class PasswordEncripter : IPasswordEncripter
{
	public string Encrypt(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}