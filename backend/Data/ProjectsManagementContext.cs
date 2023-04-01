using Microsoft.EntityFrameworkCore;

namespace ProjectsManagement.Data;

public class ProjectsManagementContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.ConnectionString);
    }
}