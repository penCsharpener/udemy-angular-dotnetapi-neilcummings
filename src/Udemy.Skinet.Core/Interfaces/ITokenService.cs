using Udemy.Skinet.Core.Entities.Identity;

namespace Udemy.Skinet.Core.Interfaces {
    public interface ITokenService {
        string CreateToken(AppUser user);
    }
}
