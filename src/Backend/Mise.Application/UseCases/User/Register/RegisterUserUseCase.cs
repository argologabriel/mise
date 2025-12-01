using AutoMapper;
using Mise.Communication.Requests;
using Mise.Communication.Responses;
using Mise.Domain.Repositories.User;
using Mise.Domain.Security.Cryptography;
using Mise.Exceptions.ExceptionsBase;

namespace Mise.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
	private readonly IMapper _mapper;
	private readonly IPasswordEncripter _passwordEncripter;
	private readonly IUserWriteRepository _userWriteRepository;

	public RegisterUserUseCase(IMapper mapper, IPasswordEncripter passwordEncripter, IUserWriteRepository userWriteRepository)
	{
		_mapper = mapper;
		_passwordEncripter = passwordEncripter;
		_userWriteRepository = userWriteRepository;
	} 

	public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
	{
		await Validate(request);

		var user = _mapper.Map<Domain.Entities.User>(request);
		user.Password = _passwordEncripter.Encrypt(request.Password);

		await _userWriteRepository.Add(user);

		return new ResponseRegisteredUserJson
		{
			Name = user.Name,
		};
	}
	
	private async Task Validate(RequestRegisterUserJson request)
	{
		var validator = new RegisterUserValidator();

		var result = await validator.ValidateAsync(request);

		if(!result.IsValid)
		{
			var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

			throw new ValidationErrorException(errorMessages);
		}
	}
}
