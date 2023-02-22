using Auth_CQRS_Example.Commands;
using Auth_CQRS_Example.DataAccess;
using Auth_CQRS_Example.Models;
using MediatR;

namespace Auth_CQRS_Example.Handler
{
    public class LoginRequestHandler : IRequestHandler<LoginRequestCommand, AuthResult>
    {
        private readonly IAuth _auth;

        public LoginRequestHandler(IAuth auth)
        {
            _auth = auth;
        }

        public Task<AuthResult> Handle(LoginRequestCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_auth.login(request.newUser));
        }
    }
}
