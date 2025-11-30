using Microsoft.AspNetCore.Mvc;
using Mise.Application.UseCases.User.Register;
using Mise.Communication.Requests;
using Mise.Communication.Responses;

namespace Mise.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUser), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices]IRegisterUserUseCase useCase,
        [FromBody]RequestRegisterUser request
        )
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }
}
