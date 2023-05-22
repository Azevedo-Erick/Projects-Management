using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Project;
using ProjectsManagement.Extensions;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class ProjectController : ControllerBase
{
    private readonly ProjectsManagementContext _context;

    public ProjectController(ProjectsManagementContext context)
    {
        this._context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/projects")]
    public async Task<IActionResult> Get()
    {
        var data = await _context.Projects.Include(x => x.Manager).Include(x => x.Members).Include(x => x.Milestones).Include(x => x.Squads).ToListAsync();
        return StatusCode(200, new BaseResponseDto<List<ResponseProjectDto>>(data.ConvertAll(ProjectMapper.FromModelToDto)));
    }

    [HttpGet("/v1/projects/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.Projects.Include(x => x.Manager).Include(x => x.Members).Include(x => x.Milestones).Include(x => x.Squads).Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseProjectDto>());
        }
        return StatusCode(200, new BaseResponseDto<ResponseProjectDto>(ProjectMapper.FromModelToDto(data)));
    }

    [HttpPost("/v1/projects")]
    public async Task<IActionResult> Post(CreateProjectDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400, new BaseResponseDto<ResponseProjectDto>(ModelState.GetErrors()));
        }
        var data = ProjectMapper.FromDtoToModel(dto);
        _context.Projects.Add(data);
        _context.SaveChanges();
        return StatusCode(201, new BaseResponseDto<ResponseProjectDto>(ProjectMapper.FromModelToDto(data)));
    }

    [HttpPatch("/v1/projects/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateProjectDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400, new BaseResponseDto<ResponseProjectDto>(ModelState.GetErrors()));
        }
        var model = await _context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (model == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseProjectDto>("Não encontrado"));
        }
        var data = ProjectMapper.FromDtoToModel(dto);
        model.Name = data.Name;
        model.ManagerId = data.ManagerId;
        model.Members = data.Members;

        _context.Projects.Update(model);
        _context.SaveChanges();
        return StatusCode(200, new BaseResponseDto<ResponseProjectDto>(ProjectMapper.FromModelToDto(data)));
    }

    [HttpPatch("/v1/projects/{id:int}/member")]
    public async Task<IActionResult> AddMember([FromRoute] int id, [FromBody] CreateProjectDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400, new BaseResponseDto<ResponseProjectDto>(ModelState.GetErrors()));
        }

        var project = await _context.Projects.Where(x => x.Id == id).Include(x => x.Members).FirstOrDefaultAsync();
        if (project == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseProjectDto>("Projeto não encontrado"));
        }
        var person = await _context.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (person == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseProjectDto>("Pessoa não encontrada"));
        }

        var role = await _context.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (role == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseProjectDto>("Cargo não encontrado"));
        }
        var member = new Member
        {
            Person = person,
            Role = role,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now
        };
        _context.Members.Add(member);
        project.Members.Add(member);
        _context.Update(project);
        _context.SaveChanges();
        return StatusCode(200, new BaseResponseDto<ResponseProjectDto>(ProjectMapper.FromModelToDto(project)));

    }


    [HttpDelete("/v1/projects/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var model = await _context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (model == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseProjectDto>("Não encontrado"));
        }
        _context.Projects.Remove(model);
        _context.SaveChanges();
        return StatusCode(200, new BaseResponseDto<ResponseProjectDto>());
    }
}