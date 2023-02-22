using Auth_CQRS_Example.Models;

namespace Auth_CQRS_Example.DataAccess
{
    public interface IUser
    {
        List<UserInfo> GetAllUsers();
    }
}
