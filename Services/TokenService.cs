using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AUTH2_TEST.Models;
using Microsoft.IdentityModel.Tokens;

namespace AUTH2_TEST.Services
{

  public static class TokenService
  {
    private const double EXPIRE_HOURS = 2.0;
    public static string CreateToken(User user)
    {
      var key = Encoding.ASCII.GetBytes(Settings.Secret);
      var tokenHandler = new JwtSecurityTokenHandler();
      var descriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, user.Username.ToString()),
          new Claim(ClaimTypes.Role, user.Type.ToString())
        }),
        Expires = DateTime.UtcNow.AddHours(EXPIRE_HOURS),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(descriptor);
      return tokenHandler.WriteToken(token);
    }
  }
    
}