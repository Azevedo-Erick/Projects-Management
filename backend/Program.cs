using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjectsManagement.Application;
using ProjectsManagement.Authentication;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos.ActivityLog;
using ProjectsManagement.Dtos.ActivityType;
using ProjectsManagement.Dtos.Address;
using ProjectsManagement.Dtos.City;
using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Dtos.Issue;
using ProjectsManagement.Dtos.Member;
using ProjectsManagement.Dtos.NotificationType;
using ProjectsManagement.Dtos.Permission;
using ProjectsManagement.Dtos.Person;
using ProjectsManagement.Dtos.Project;
using ProjectsManagement.Dtos.Role;
using ProjectsManagement.Dtos.State;
using ProjectsManagement.Dtos.Tag;
using ProjectsManagement.Dtos.Task;
using ProjectsManagement.Dtos.Ticket;
using ProjectsManagement.Dtos.TicketComment;
using ProjectsManagement.Infrastructure;
using ProjectsManagement.Mappers.Profiles;
using ProjectsManagement.Models;
using ProjectsManagement.OptionsSetup;
using ProjectsManagement.Providers;
using ProjectsManagement.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var mapperConfig = new MapperConfiguration(
    config =>
    {



        config.AddProfile<CityProfile>();
        config.AddProfile<CountryProfile>();
        config.AddProfile<IssueProfile>();
        config.AddProfile<PersonProfile>();
        config.AddProfile<RoleProfile>();
        config.AddProfile<TagProfile>();
        config.AddProfile<TaskProfile>();
        config.AddProfile<IssueProfile>();
        config.AddProfile<StateProfile>();
        config.AddProfile<ActivityLogProfile>();
        config.AddProfile<ActivityTypeProfile>();
        config.AddProfile<ContactInfoProfile>();
        config.AddProfile<ContactTypeProfile>();
        config.AddProfile<MilestoneProfile>();
        config.AddProfile<NotificationProfile>();
        config.AddProfile<NotificationTypeProfile>();
        config.AddProfile<PermissionProfile>();
        config.AddProfile<ProjectProfile>();
        config.AddProfile<SquadProfile>();
        config.AddProfile<TicketCommentProfile>();
        config.AddProfile<TicketProfile>();

        config.CreateMap<Address, ResponseAddressDto>();
        config.CreateMap<Member, ResponseMemberDto>();
    }
);

builder.Services.ConfigureInfrastructureServices();
builder.Services.ConfigureApplicationServices();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(option => option.AllowAnyOrigin());
app.UseAuthorization();
app.MapControllers();

app.Run();
