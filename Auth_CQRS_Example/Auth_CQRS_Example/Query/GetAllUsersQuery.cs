using Auth_CQRS_Example.Models;
using MediatR;

namespace Auth_CQRS_Example.Query
{
    public record GetAllUsersQuery:IRequest<List<UserInfo>>
    {
    }
}
