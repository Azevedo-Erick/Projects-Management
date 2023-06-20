using ProjectsManagement.Authentication;
using ProjectsManagement.Mappers.Profiles;
using ProjectsManagement.Providers;
using ProjectsManagement.Services;

namespace ProjectsManagement.Application;


public static class StartupExtensions
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddLogging();
        services.AddControllers()
            .ConfigureApiBehaviorOptions(options => options.SuppressMapClientErrors = true);
        services.AddAutoMapper(
            typeof(CityProfile).Assembly,
            typeof(CityProfile).Assembly,
            typeof(CountryProfile).Assembly,
            typeof(IssueProfile).Assembly,
            typeof(PersonProfile).Assembly,
            typeof(RoleProfile).Assembly,
            typeof(TagProfile).Assembly,
            typeof(TaskProfile).Assembly,
            typeof(IssueProfile).Assembly,
            typeof(StateProfile).Assembly,
            typeof(ActivityLogProfile).Assembly,
            typeof(ActivityTypeProfile).Assembly,
            typeof(ContactInfoProfile).Assembly,
            typeof(ContactTypeProfile).Assembly,
            typeof(MilestoneProfile).Assembly,
            typeof(NotificationProfile).Assembly,
            typeof(NotificationTypeProfile).Assembly,
            typeof(PermissionProfile).Assembly,
            typeof(ProjectProfile).Assembly,
            typeof(SquadProfile).Assembly,
            typeof(TicketCommentProfile).Assembly,
            typeof(TicketProfile).Assembly
        );

        services.AddScoped<IJwtProvider, JwtProvider>();

        services.AddScoped<ProjectService>();
    }
}

