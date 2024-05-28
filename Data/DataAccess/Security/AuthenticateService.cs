using Data.Common;
using Data.Model;
using Data.Repository.Interface;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.DataAccess.Security
{
    public class AuthenticateService : IRequest<RequestResult<AuthUser>>
    {
        public string userName { get; set; }
        public string password { get; set; }

        public class Handler : IRequestHandler<AuthenticateService, RequestResult<AuthUser>>
        {
            private readonly IUserRepository _userRepository;
            private readonly AppSettings _appSettings;

            public Handler(IUserRepository userRepository, IOptions<AppSettings> appsetting)
            {
                _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                _appSettings = appsetting != null ? appsetting.Value : throw new ArgumentNullException(nameof(appsetting));
            }

            public async Task<RequestResult<AuthUser>> Handle(AuthenticateService request, CancellationToken cancellationToken)
            {
                var user = await _userRepository
                    .GetUserByUserNameAndPasswordAsync(request.userName, request.password).ConfigureAwait(false);

                if (user == null)
                {
                    return null;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.id.ToString()),
                    new Claim(ClaimTypes.Version, "v1")
                }),
                    Expires = DateTime.UtcNow.AddHours(8),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return RequestResult.Success(user.ToAuthUser(tokenHandler.WriteToken(token)));
            }
        }
    }
}
