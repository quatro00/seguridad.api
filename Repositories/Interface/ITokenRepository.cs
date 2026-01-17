using Microsoft.AspNetCore.Identity;

namespace seguridad.api.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
