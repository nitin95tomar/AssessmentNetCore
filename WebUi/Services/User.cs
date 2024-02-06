
using WebUi.Swagger;

namespace WebUi.Services
{
    public class User : IUser
    {
        private readonly swaggerClient client;

        public User(HttpClient httpClient)
        {
            this.client = new swaggerClient("http://localhost:5215",httpClient);
        }

        public async Task<Response> LoginUser(Login loginModel)
        {
            var response = await client.LoginUserAsync(loginModel);
            return (response!);
        }

        public async Task<Response> RegisterUser(Registration registrationModel)
        {
            var response = await client.RegisterUserAsync(registrationModel);
            return (response!);
        }
    }
}

