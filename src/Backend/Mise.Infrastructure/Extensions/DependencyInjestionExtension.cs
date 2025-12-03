using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mise.Application.Services.Cryptography;
using Mise.Domain.Repositories;
using Mise.Domain.Repositories.User;
using Mise.Domain.Security.Cryptography;
using Mise.Infrastructure.DataAcess;
using Mise.Infrastructure.DataAcess.Repositories;

namespace Mise.Infrastructure.Extensions;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
		AddDbContext(services, configuration);
        AddPasswordEncripter(services);
        AddRepositories(services);
    }

	private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.ConnectionString();

        services.AddDbContext<MiseDbContext>(dbContextOptions =>
        {
            dbContextOptions.UseSqlServer(connectionString);
        });
    }

    private static void AddPasswordEncripter(IServiceCollection services)
	{
		services.AddScoped<IPasswordEncripter, PasswordEncripter>();
	}

    private static void AddRepositories(IServiceCollection services)
	{
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserReadRepository, UserRepository>();
		services.AddScoped<IUserWriteRepository, UserRepository>();
	}
}
