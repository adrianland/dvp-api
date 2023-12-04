using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DVP.Project.AggregatesModel.UserAggregate;
using DVP.Project.Api.Application.Commands.User;
using MediatR;
using Microsoft.IdentityModel.Tokens;

public class ValidatorUserCommandHandler : IRequestHandler<ValidatorUserCommand, string>
{
    private readonly IUserRepository _iUsernRepository;
    private readonly string secretKey;



    public ValidatorUserCommandHandler(IUserRepository iUserRepository, IConfiguration config)
    {
        _iUsernRepository = iUserRepository;
        secretKey = config.GetSection("settings").GetSection("secretKey").ToString();

    }

    public async Task<string> Handle(ValidatorUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = _iUsernRepository.GetUserById(request.Username,request.Password);

        if(dbUser != null)
        {

            var keyBytes = Encoding.ASCII.GetBytes(secretKey);
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, $"{dbUser.Id}"),
                new Claim(ClaimTypes.Name,$"{request.Username}")
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokencreado = tokenHandler.WriteToken(tokenConfig);


            return tokencreado;
        }
        else
        {

            return "";
        }
    }
}