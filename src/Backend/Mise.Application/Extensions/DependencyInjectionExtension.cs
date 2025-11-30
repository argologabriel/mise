using Microsoft.Extensions.DependencyInjection;
using Mise.Application.UseCases.User.Register;

namespace Mise.Application.Extensions;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
		AddUseCases(services);
    }

	private static void AddUseCases(IServiceCollection services)
    {
		services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }
}