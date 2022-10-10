using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WFM_API.Wfm_Core.Abstraction;
using WFM_API.Wfm_Core.ViewModel;
using WFM_API.Wfm_Data;
using WFM_API.Wfm_DomainModel;
using WFM_API.Wfm_Service.Helpers;

namespace WFM_API.Wfm_Service
{
    public class UserService : IUserService
    {
        private readonly EmployeeDataContext _dataContext;
        private readonly AppSettings _appSettings;
        public UserService(EmployeeDataContext dataContext, IOptions<AppSettings> appSettings)
        {
            _dataContext = dataContext;
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _dataContext.Users.SingleOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This is my first Security key and hope this is enough to create jwt token");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public List<User> GetUser()
        {
            var user = _dataContext.Users.ToList();
            return user;
        }
        public User GetById(int id)
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

       
    }
}

