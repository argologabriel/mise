using Mise.Communication.Requests;
using Mise.Communication.Responses;

namespace Mise.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
	Task<ResponseRegisteredUser> Execute(RequestRegisterUser request);
}
