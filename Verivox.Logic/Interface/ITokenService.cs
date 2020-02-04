using Verivox.Domain.Models;
using Verivox.Logic.Models;

namespace Verivox.Logic.Interface
{
    public interface ITokenService
    {
        JsonWebToken GenerateJwtToken(ApplicationUser user);
    }
}