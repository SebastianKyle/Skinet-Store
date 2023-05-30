using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.StartupExtensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string RetrieveEmailFromPrinciple(this ClaimsPrincipal user) 
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }
    }
}