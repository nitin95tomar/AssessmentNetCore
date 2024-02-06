using System;
namespace WebAPI.Models.Repository
{
	public interface IUserRepository
	{
        public Task<Response> LoginUserAsync(Login loginModel);
        public Task<Response> RegisterUserAsync(Registration registrationModel);
    }
}

