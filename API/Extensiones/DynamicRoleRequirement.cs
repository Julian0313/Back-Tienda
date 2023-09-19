using Microsoft.AspNetCore.Authorization;

namespace API.Extensiones
{
    public class DynamicRoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; }

        public DynamicRoleRequirement(string role)
        {
            Role = role;
        }
    }
}