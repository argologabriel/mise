using Microsoft.Extensions.DependencyInjection;
using Mise.Application.Services.AutoMapper;
using Mise.Application.UseCases.User.Register;

namespace Mise.Application.Extensions;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
	  {
        services.AddAutoMapper(typeof(AutoMapping).Assembly);
	  }

	  private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }
}