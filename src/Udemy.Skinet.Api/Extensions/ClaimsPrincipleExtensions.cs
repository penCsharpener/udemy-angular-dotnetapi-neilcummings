using System.Linq;
using System.Security.Claims;

namespace Udemy.Skinet.Api.Extensions {
    public static class ClaimsPrincipleExtensions {
        public static string RetrieveEmailFromPrinciple(this ClaimsPrincipal user) {
            return user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}
