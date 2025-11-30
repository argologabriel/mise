using Mise.Communication.Requests;
using Mise.Communication.Responses;
using Mise.Domain.Repositories.User;

namespace Mise.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
	private readonly IUserWriteRepository _userWriteRepository;

	public RegisterUserUseCase(IUserWriteRepository userWriteRepository)
	{
		_userWriteRepository = userWriteRepository;
	} 

	public async Task<ResponseRegisteredUser> Execute(RequestRegisterUser request)
	{
		// TODO: Validar Requisição 

		// TODO: Usar AutoMapper para Converter de DTO para Entidade 

		var user = new Domain.Entities.User
		{
			Name = request.Name,
			Email = request.Email,
			Password = request.Password
		};

		// TODO: Criptografar Senha 

		await _userWriteRepository.Add(user);

		return new ResponseRegisteredUser
		{
			Name = user.Name,
		};
	}
}