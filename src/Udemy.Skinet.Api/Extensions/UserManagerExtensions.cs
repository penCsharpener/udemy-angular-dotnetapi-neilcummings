using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities.Identity;

namespace Udemy.Skinet.Api.Extensions {
    public static class UserManagerExtensions {
        public static async Task<AppUser> FindByUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> userManager, ClaimsPrincipal user) {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

            return await userManager.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email.Equals(email));
        }

        public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> userManager, ClaimsPrincipal user) {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

            return await userManager.Users.SingleOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}
