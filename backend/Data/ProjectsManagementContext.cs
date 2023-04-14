using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data.Mappings;
using ProjectsManagement.Models;
using Task = ProjectsManagement.Models.Task;

namespace ProjectsManagement.Data;

public class ProjectsManagementContext : DbContext
{


    /* public DbSet<ActivityLog> ActivityLogs { get; set; }
    public DbSet<ActivityType> ActivityTypes { get; set; }
    public DbSet<Address> Addresses { get; set; } */
    public DbSet<City> Cities { get; set; }
    /*  public DbSet<ContactInfo> ContactInfos { get; set; }
     public DbSet<ContactType> ContactTypes { get; set; } */
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    /*  public DbSet<Employee> Employees { get; set; }
     public DbSet<Issue> Issues { get; set; }
     public DbSet<Milestone> Milestones { get; set; }
     public DbSet<Notification> Notifications { get; set; }
     public DbSet<NotificationType> NotificationTypes { get; set; }
     public DbSet<Permission> Permissions { get; set; }
     public DbSet<Person> Persons { get; set; }
     public DbSet<Project> Projects { get; set; }
     public DbSet<Role> Roles { get; set; }
     public DbSet<Squad> Squads { get; set; }
     public DbSet<Stakeholder> Stakeholders { get; set; }
     public DbSet<Tag> Tags { get; set; }
     public DbSet<Task> Tasks { get; set; }
     public DbSet<Ticket> Tickets { get; set; }
     public DbSet<TicketComment> TicketComment { get; set; }
  */
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StateMap());
        modelBuilder.ApplyConfiguration(new CityMap());
        modelBuilder.ApplyConfiguration(new CountryMap());
        /* modelBuilder.ApplyConfiguration(new ActivityLogMap());
        modelBuilder.ApplyConfiguration(new ActivityTypeMap());
        modelBuilder.ApplyConfiguration(new AddressMap());
        modelBuilder.ApplyConfiguration(new ContactInfoMap());
        modelBuilder.ApplyConfiguration(new ContactTypeMap());
        modelBuilder.ApplyConfiguration(new EmployeeMap());
        modelBuilder.ApplyConfiguration(new IssueMap());
        modelBuilder.ApplyConfiguration(new MilestoneMap());
        modelBuilder.ApplyConfiguration(new NotificationMap());
        modelBuilder.ApplyConfiguration(new NotificationTypeMap());
        modelBuilder.ApplyConfiguration(new PermissionMap());
        modelBuilder.ApplyConfiguration(new PersonMap());
        modelBuilder.ApplyConfiguration(new ProjectMap());
        modelBuilder.ApplyConfiguration(new RoleMap());
        modelBuilder.ApplyConfiguration(new SquadMap());
        modelBuilder.ApplyConfiguration(new StakeholderMap());
        modelBuilder.ApplyConfiguration(new TagMap());
        modelBuilder.ApplyConfiguration(new TaskMap());
        modelBuilder.ApplyConfiguration(new TicketMap());
        modelBuilder.ApplyConfiguration(new TicketCommentMap()); */
    }



}