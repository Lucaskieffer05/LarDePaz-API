using Microsoft.AspNetCore.Authorization;

namespace LarDePaz_API.Security
{
    public class AuthorizeRolesAttribute(params string[] roles) : IAuthorizationRequirement
    {
        public string Roles { get; } = string.Join(",", roles);
    }
}
