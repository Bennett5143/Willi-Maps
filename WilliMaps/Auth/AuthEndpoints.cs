using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WilliMaps.Data;
using WilliMaps.Models;

namespace WilliMaps.Auth
{
    public static class AuthEndpoints
    {
        public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("/auth").DisableAntiforgery();

            group.MapPost("/login", (Delegate)LoginAsync);
            group.MapPost("/logout", (Delegate)LogoutAsync);

            return endpoints;
        }

        private static async Task<IResult> LoginAsync(
            HttpContext context,
            WilliMapsDbContext db,
            IPasswordHasher<ApplicationUser> hasher,
            [FromForm] string username,
            [FromForm] string password)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user is null)
                return Results.Redirect("/login?error=invalid");

            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (result == PasswordVerificationResult.Failed)
                return Results.Redirect("/login?error=invalid");

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            return Results.Redirect("/admin");
        }

        private static async Task<IResult> LogoutAsync(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Results.Redirect("/");
        }
    }
}

