using AmCart.Business.IAM;
using IdentityModel;
using System.Collections.Generic;
using System.Security.Claims;

namespace Amcart.Web.IAM
{
    public static class UserExtensions
    {
        public static List<Claim> GetClaims(this User user)
        {
            return new List<Claim>()
            {
                new Claim("user_id", user.Id.ToString()),
                new Claim(JwtClaimTypes.Name, (!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName)) ? (user.FirstName + " " + user.LastName) : ""),
                new Claim(JwtClaimTypes.GivenName, user.FirstName  ?? ""),
                new Claim(JwtClaimTypes.FamilyName, user.LastName  ?? ""),
                new Claim(JwtClaimTypes.Email, user.EmailId  ?? ""),
                new Claim(JwtClaimTypes.Role, user.Role.Name)
            };
        }
    }
}
