using Auth_CQRS_Example.Models;
using Auth_CQRS_Example.Models.DTO;
using MediatR;

namespace Auth_CQRS_Example.Commands
{
    public record LoginRequestCommand(UserLoginRequestDto newUser) : IRequest<AuthResult>
    {
    }
}
