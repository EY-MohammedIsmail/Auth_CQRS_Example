using Auth_CQRS_Example.Models.DTO;
using Auth_CQRS_Example.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth_CQRS_Example.DataAccess;

namespace Auth_CQRS_Example.Repository
{
    public class AuthRepository:IAuth
    {
        private readonly AuthCqrsContext _context;

        private readonly IConfiguration _configuration;

        public AuthRepository(AuthCqrsContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public AuthResult login(UserLoginRequestDto user)
        {
            try
            {
                var checkUser = _context.UserInfos.Where(o => o.Email == user.Email && o.Password == user.Password).FirstOrDefault();
                if (checkUser != null)
                {
                    var token = GenerateJwtToken(checkUser);
                    var result = new AuthResult()
                    {
                        Token = token,
                        Result = true

                    };
                    return result;


                }
                else
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() {
                    "Not found"}
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string register(UserRegisterDto newUser)
        {
            var checkUser = _context.UserInfos.Where(o => o.Email == newUser.Email).FirstOrDefault();
            if (checkUser == null)
            {
                var new_user = new UserInfo()
                {
                    UserName = newUser.Name,
                    Email = newUser.Email,
                    Password = newUser.Password,
                    Role = "user",
                };

                _context.UserInfos.Add(new_user);
                _context.SaveChanges();

                return "Registered successfully";

            }

            return "Email already exists.";
        }

        private string GenerateJwtToken(UserInfo user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)

            };

            var tokens = new JwtSecurityToken(_configuration["jwt:Issuer"],
                _configuration["jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokens);
        }
    }
    }


