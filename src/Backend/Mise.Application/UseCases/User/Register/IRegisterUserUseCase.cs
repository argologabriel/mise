using Mise.Communication.Requests;
using Mise.Communication.Responses;

namespace Mise.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
	Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
