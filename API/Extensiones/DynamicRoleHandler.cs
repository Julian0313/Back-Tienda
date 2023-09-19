using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace API.Extensiones
{
    public class DynamicRoleHandler : AuthorizationHandler<DynamicRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DynamicRoleRequirement requirement)
        {
            // Verificar si el usuario tiene el rol dinámico
            if (context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == requirement.Role))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}