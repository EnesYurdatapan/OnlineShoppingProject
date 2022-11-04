using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions //kullanıcıların claim'lerini ararken .net bizi uğraştırır.Bir kişinin claimlerine erişmek için kullandığımız class
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType) // ClaimsPrincipal : jwt token ile o an erişen user'ın claimlerine erişmemizi sağlayan class.
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList(); // ? : Claim oluşmamış olabilir, yani null olabilir anlamı taşır.
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal) // direkt roller lazımsa kısa yoldan döndürülür.
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
