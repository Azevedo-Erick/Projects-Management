using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Issue;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class IssueController : ControllerBase
{
    private readonly ProjectsManagementContext _context;

    private readonly IMapper _mapper;
    public IssueController(ProjectsManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    [AllowAnonymous]
    [HttpGet("/v1/issues")]
    public async Task<IActionResult> Get()
    {
        var data = await _context.Issues.ToListAsync();
        return StatusCode(
               200,
               new BaseResponseDto<List<ResponseIssueDto>>(data.ConvertAll(IssueMapper.FromModelToDto))
               );
    }

    [HttpGet("/v1/issues/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.Issues.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);
        }
        return StatusCode(
               200,
               new BaseResponseDto<ResponseIssueDto>(IssueMapper.FromModelToDto(data))
               );
    }

    [HttpPost("/v1/issues")]
    public async Task<IActionResult> Post(CreateIssueDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }
        var project = await _context.Projects.Where(x => x.Id == dto.Project).FirstOrDefaultAsync();
        if (project == null)
        {
            return StatusCode(400);
        }
        var author = await _context.Persons.Where(x => x.Id == dto.Author).FirstOrDefaultAsync();
        if (author == null)
        {
            return StatusCode(400);
        }
        var model = IssueMapper.FromDtoToModel(dto);
        model.Author = author;
        model.Project = project;
        _context.Issues.Add(model);
        _context.SaveChanges();
        return StatusCode(
               200,
               new BaseResponseDto<ResponseIssueDto>(IssueMapper.FromModelToDto(model))
               );
    }

    [HttpPatch("/v1/issues/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateIssueDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }
        var issue = await _context.Issues.Where(x => x.Id == id).Include(x => x.Author).Include(x => x.Project).FirstOrDefaultAsync();
        if (issue == null)
        {
            return StatusCode(400);
        }
        var data = IssueMapper.FromDtoToModel(dto);

        if (issue.ProjectId == dto.Project)
        {
            var project = await _context.Projects.Where(x => x.Id == dto.Project).FirstOrDefaultAsync();
            if (project == null)
            {
                return StatusCode(400);
            }
            data.Project = project;
        }
        if (issue.AuthorId != dto.Author)
        {
            var author = await _context.Persons.Where(x => x.Id == dto.Author).FirstOrDefaultAsync();
            if (author == null)
            {
                return StatusCode(400);
            }
            data.Author = author;
        }
        _context.Issues.Update(data);
        _context.SaveChanges();
        return StatusCode(
               200,
               new BaseResponseDto<ResponseIssueDto>(IssueMapper.FromModelToDto(data))
               );
    }

    [HttpDelete("/v1/issues/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var issue = await _context.Issues.Where(x => x.Id == id).Include(x => x.Author).Include(x => x.Project).FirstOrDefaultAsync();
        if (issue == null)
        {
            return StatusCode(400);
        }
        _context.Issues.Remove(issue);
        _context.SaveChanges();
        return StatusCode(
               200,
               new BaseResponseDto<ResponseIssueDto>()
               );
    }
}