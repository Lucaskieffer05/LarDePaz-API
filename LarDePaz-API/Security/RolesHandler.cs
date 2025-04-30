using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Security.Claims;

namespace LarDePaz_API.Security
{
    public class RolesHandler(IHttpContextAccessor httpContextAccessor) : AuthorizationHandler<AuthorizeRolesAttribute>
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizeRolesAttribute requirement)
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            foreach (var claim in _httpContextAccessor.HttpContext.User.Claims)
            {
                Debug.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
            }
            var roles = (_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Role).Value).Split(',').ToList();

            if (!roles.Any(role => requirement.Roles.Contains(role)))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
