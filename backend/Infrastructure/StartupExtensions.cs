using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using ProjectsManagement.Authentication;
using ProjectsManagement.Data;
using ProjectsManagement.Mappers.Profiles;
using ProjectsManagement.OptionsSetup;
using ProjectsManagement.Providers;
using ProjectsManagement.Services;

namespace ProjectsManagement.Infrastructure;

public static class StartupExtensions
{
    public static void ConfigureInfrastructureServices(this IServiceCollection services)
    {

        services.AddSignalR();
        services.AddDbContext<ProjectsManagementContext>();


        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme
        ).AddJwtBearer();

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();
        services.AddAuthorization();
        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

    }
}
