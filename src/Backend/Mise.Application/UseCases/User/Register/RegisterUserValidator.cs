using FluentValidation;
using Mise.Communication.Requests;

namespace Mise.Application.UseCases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUser>
{
	public RegisterUserValidator()
	{
		RuleFor(user => user.Name)
			.NotEmpty()
			.WithMessage("O nome não pode ser vazio.");

		RuleFor(user => user.Email)
			.NotEmpty()
			.WithMessage("O email não pode ser vazio.")
			.EmailAddress()
			.WithMessage("O e-mail é inválido."); 

		RuleFor(user => user.Password)
			.NotEmpty()
			.WithMessage("A senha não pode ser vazia.")
			.MinimumLength(8)
			.WithMessage("A senha deve conter no mínimo 8 digítos")
			.MaximumLength(20)
			.WithMessage("A senha deve conter no mínimo 20 digítos");
	}	
}
