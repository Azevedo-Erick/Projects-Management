using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using AutoMapper;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Task;
using ProjectsManagement.Extensions;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class TaskController : ControllerBase
{
    private readonly ProjectsManagementContext _context;

    private readonly IMapper _mapper;
    public TaskController(ProjectsManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    [AllowAnonymous]
    [HttpGet("/v1/tasks")]
    public async Task<IActionResult> Get()
    {
        var data = await _context.Tasks.ToListAsync();
        return StatusCode(200, new BaseResponseDto<List<ResponseTaskDto>>(data.ConvertAll(TaskMapper.FromModelToDto)));
    }

    [HttpGet("/v1/tasks/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTaskDto>());
        }
        return StatusCode(200, new BaseResponseDto<ResponseTaskDto>(TaskMapper.FromModelToDto(data)));
    }

    [HttpPost("/v1/tasks")]
    public async Task<IActionResult> Post(CreateTaskDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTaskDto>(ModelState.GetErrors()));
        }

        var members = await _context.Members.Where(x => dto.Assignments.Contains(x.Id)).ToListAsync();
        if (members == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTaskDto>("Membros não encontrados"));
        }
        var assigner = await _context.Persons.Where(x => x.Id == dto.Assigner).FirstOrDefaultAsync();
        if (assigner == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTaskDto>("Assinante não encontrado"));
        }
        var tags = await _context.Tags.Where(x => dto.Tags.Contains(x.Id)).ToListAsync();
        if (tags == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTaskDto>("Tags não encontradas"));
        }

        var data = TaskMapper.FromDtoToModel(dto);
        data.Assigner = assigner;
        data.Tags = tags;
        _context.Tasks.Add(data);
        foreach (var member in members)
        {
            _context.TaskAssignments.Add(new TaskAssignment
            {
                MemberId = member.Id,
                TaskId = data.Id
            });
        }
        _context.SaveChanges();
        return StatusCode(200, new BaseResponseDto<ResponseTaskDto>(TaskMapper.FromModelToDto(data)));
    }

    [HttpPatch("/v1/tasks/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateTaskDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTaskDto>(ModelState.GetErrors()));
        }
        var model = await _context.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (model == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTaskDto>("Elemento não encontrado"));
        }
        var members = await _context.Members.Where(x => dto.Assignments.Contains(x.Id)).ToListAsync();
        if (members == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTaskDto>("Membros não encontrados"));
        }
        var assigner = await _context.Persons.Where(x => x.Id == dto.Assigner).FirstOrDefaultAsync();
        if (assigner == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTaskDto>("Assinante não encontrado"));
        }
        var tags = await _context.Tags.Where(x => dto.Tags.Contains(x.Id)).ToListAsync();
        if (tags == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTaskDto>("Tags não encontradas"));
        }
        return StatusCode(200, new BaseResponseDto<ResponseTaskDto>(TaskMapper.FromModelToDto(model)));
    }

    [HttpDelete("/v1/tasks/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var data = await _context.Tasks.Where(x => x.Id == id).Include(
            x => x.Assignments
        )
        .Include(
            x => x.Issues
        )
        .FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTaskDto>("Elemento não encontradas"));
        }

        foreach (var assignee in data.Assignments)
        {
            _context.TaskAssignments.Remove(assignee);
        }

        foreach (var issue in data.Issues)
        {
            _context.Issues.Remove(issue);
        }
        _context.SaveChanges();
        return StatusCode(200, new BaseResponseDto<ResponseTaskDto>());
    }
}