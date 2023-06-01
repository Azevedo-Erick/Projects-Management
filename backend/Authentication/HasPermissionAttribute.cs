using Microsoft.AspNetCore.Authorization;

namespace ProjectsManagement.Authentication;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permission permission)
        : base(policy: permission.ToString())
    {

    }

    // class members here
}
