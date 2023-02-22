using Auth_CQRS_Example.DataAccess;
using Auth_CQRS_Example.Models;

namespace Auth_CQRS_Example.Repository
{
    public class UserInfoRepository:IUser
    {
        private readonly AuthCqrsContext _context;

        public UserInfoRepository(AuthCqrsContext context)
        {
            _context = context;
        }

        public List<UserInfo> GetAllUsers()
        {
            return _context.UserInfos.ToList();
        }
    }
}
