using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace dtaplace.Services.JWT;

public class JWTService(SecurityKey securityKey) : IJWTService
{
    public string CreateToken(ProfileToAuth data)
    {
        var jwt = new JwtSecurityToken(
            claims: [
                new Claim(ClaimTypes.NameIdentifier, data.ProfileID.ToString()),
                new Claim(ClaimTypes.Name, data.Username)
            ],
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256Signature
            )
        );
        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(jwt);
    }
}