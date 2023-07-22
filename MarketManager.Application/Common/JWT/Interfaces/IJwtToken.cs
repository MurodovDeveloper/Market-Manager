using System.Security.Claims;
using MarketManager.Application.Common.JWT.Models;
using MarketManager.Domain.Entities.Identity;

namespace MarketManager.Application.Common.JWT.Interfaces;
public interface IJwtToken
{
    ValueTask<TokenResponse> CreateTokenAsync(string userName, string UserId, ICollection<Role> roles, CancellationToken cancellationToken = default);
    ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    ValueTask<string> GenerateRefreshTokenAsync(string userName);
}
