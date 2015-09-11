using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAddons
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetStringValue(this ClaimsPrincipal principal,
            string claimType)
        {
            return principal.Claims.Where(c => c.Type == claimType)
                .Select(c => c.Value).SingleOrDefault();
        }
    }
}
