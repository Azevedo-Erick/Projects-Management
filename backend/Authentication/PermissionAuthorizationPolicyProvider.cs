using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace ProjectsManagement.Authentication;

public class PermissionAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
{
    public PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
    {
    }


    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);
        return policy ?? (AuthorizationPolicy?)new AuthorizationPolicyBuilder().AddRequirements(
            new PermissionRequirement(policyName)
        ).Build();
    }
}
