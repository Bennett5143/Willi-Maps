using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WilliMaps.Auth
{
    public class BlazorAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BlazorAuthStateProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // HttpContext.User enthält den ClaimsPrincipal aus dem Cookie
            var user = _httpContextAccessor.HttpContext?.User 
                    ?? new ClaimsPrincipal(new ClaimsIdentity()); 

            return Task.FromResult(new AuthenticationState(user));
        }
    }
}


