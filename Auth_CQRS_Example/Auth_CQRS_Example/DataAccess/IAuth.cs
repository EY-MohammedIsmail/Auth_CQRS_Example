using Auth_CQRS_Example.Models;
using Auth_CQRS_Example.Models.DTO;

namespace Auth_CQRS_Example.DataAccess
{
    public interface IAuth
    {
        AuthResult login(UserLoginRequestDto user);

        string register(UserRegisterDto newUser);

    }
}
