using Microsoft.AspNetCore.Authorization;

namespace API.Extensiones
{
    public class DynamicRoleAuthorizeAttribute : AuthorizeAttribute
    {
        public DynamicRoleAuthorizeAttribute()
        {
            Policy = "DynamicRolePolicy";
        }

    }
}