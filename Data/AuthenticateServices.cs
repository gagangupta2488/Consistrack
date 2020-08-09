using Consistrack.Interface;
using Consistrack.Models;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System;

namespace Consistrack.Data
{
    public class AuthenticateServices : IAuthenticateServiceRepo
    {
 private readonly ConsistrackContext _Context;
 private readonly AppSettings _appsettings;


public AuthenticateServices(ConsistrackContext Context, IOptions<AppSettings> appsettings)
{
            _Context=Context;
            _appsettings=appsettings.Value;
}
        public UserMaster Authenticate(string loginid, string password)
        {
            var user=_Context.UserMasters.SingleOrDefault(x=> x.LoginID==loginid && x.Password==password);
            if(user==null)
            {
                return null;
            }
            var tokenHandler=new JwtSecurityTokenHandler();
            var key=Encoding.ASCII.GetBytes(_appsettings.Key);
            var tokenDescriptor=new SecurityTokenDescriptor
            {

Subject=new System.Security.Claims.ClaimsIdentity( new Claim[]{

new Claim(ClaimTypes.Name,user.UserID.ToString()),
new Claim(ClaimTypes.Role ,"Admin"),
new Claim(ClaimTypes.Version,"V3.1")
}),
Expires=DateTime.UtcNow.AddDays(2),
SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token=tokenHandler.CreateToken(tokenDescriptor); 
            user.Token=tokenHandler.WriteToken(token);
            user.Password=null;
        return user;
        }
    }
}