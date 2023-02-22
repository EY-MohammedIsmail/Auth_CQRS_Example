using Auth_CQRS_Example.DataAccess;
using Auth_CQRS_Example.Models;
using Auth_CQRS_Example.Query;
using MediatR;

namespace Auth_CQRS_Example.Handler
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserInfo>>
    {
        private readonly IUser _user;

        public GetAllUsersHandler(IUser user)
        {
            _user = user;
        }

        public Task<List<UserInfo>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_user.GetAllUsers());
        }
    }
}
