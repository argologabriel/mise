using AutoMapper;
using Mise.Communication.Requests;
using Mise.Domain.Entities;

namespace Mise.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
	public AutoMapping()
	{
		RequestToEntity();
	}

	private void RequestToEntity()
	{
		CreateMap<RequestRegisterUserJson, User>();
	}
}