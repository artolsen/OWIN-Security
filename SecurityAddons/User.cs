using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace SecurityAddons
{
    public class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
        public string Email { get; set; }

        public ClaimsIdentity BuildIdentity()
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, this.FirstName + " "
                + this.LastName));
            claims.Add(new Claim(ClaimTypes.Email, this.Email));
            claims.Add(new Claim(ClaimTypes.Name, this.UserName));
            
            foreach (string role in this.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            ClaimsIdentity identity = new ClaimsIdentity(claims.ToArray(),
                          DefaultAuthenticationTypes.ApplicationCookie,
                          ClaimTypes.Name, ClaimTypes.Role);

            return identity;
        }

        public User BuildUserFromPrincipal(ClaimsPrincipal principal)
        {
            string[] names = principal.GetStringValue(ClaimTypes.GivenName).Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            User user = new User()
            {
                UserName = principal.GetStringValue(ClaimTypes.Name),
                FirstName = names.First(),
                LastName = names.Last(),
                Email = principal.GetStringValue(ClaimTypes.Email)
            };

            return user;
        }
    }
}
