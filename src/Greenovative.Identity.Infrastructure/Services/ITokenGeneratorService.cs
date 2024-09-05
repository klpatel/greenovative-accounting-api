using Greenovative.Identity.Infrastructure.Models;
using System.Security.Claims;

namespace Greenovative.Identity.Infrastructure.Services;

public interface ITokenGeneratorService
{
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    Task<Token> GenerateTokens(User user, IList<string> roles);
}