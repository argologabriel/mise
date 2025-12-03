using AutoMapper;
using Mise.Communication.Requests;
using Mise.Communication.Responses;
using Mise.Domain.Repositories;
using Mise.Domain.Repositories.User;
using Mise.Domain.Security.Cryptography;
using Mise.Exceptions.ExceptionsBase;
using Shared.Mise.Exceptions;

namespace Mise.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
	private readonly IMapper _mapper;
	private readonly IPasswordEncripter _passwordEncripter;
	private readonly IUserReadRepository _userReadRepository;
	private readonly IUserWriteRepository _userWriteRepository;
	private readonly IUnitOfWork _unitOfWork;

	public RegisterUserUseCase(IMapper mapper, IPasswordEncripter passwordEncripter, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_passwordEncripter = passwordEncripter;
		_userReadRepository = userReadRepository;
		_userWriteRepository = userWriteRepository;
		_unitOfWork = unitOfWork;
	} 

	public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
	{
		await Validate(request);

		var user = _mapper.Map<Domain.Entities.User>(request);
		user.Password = _passwordEncripter.Encrypt(request.Password);

		await _userWriteRepository.Add(user);

		await _unitOfWork.Commit();

		return new ResponseRegisteredUserJson
		{
			Name = user.Name,
		};
	}
	
	private async Task Validate(RequestRegisterUserJson request)
	{
		var validator = new RegisterUserValidator();

		var result = await validator.ValidateAsync(request);

		var emailExist = await _userReadRepository.ExistActiveUserWithEmail(request.Email);

		if(emailExist)
		{
			result.Errors.Add(new FluentValidation.Results.ValidationFailure(request.Email, ResourceMessagesException.EMAIL_ALREADY_REGISTERED));
		}

		if(!result.IsValid)
		{
			var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

			throw new ValidationErrorException(errorMessages);
		}
	}
}
