using Laba_7.Models;

namespace Laba_7.Services
{
    public interface IAuthService
    {
        Users Register(Users user);
        Users Login(string email, string password);

    }
}
