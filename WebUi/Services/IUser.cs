using System;
using WebUi.Swagger;

namespace WebUi.Services
{
    public interface IUser
    {
        Task<Response> RegisterUser(Registration registrationModel);
        Task<Response> LoginUser(Login loginModel);
    }
}
