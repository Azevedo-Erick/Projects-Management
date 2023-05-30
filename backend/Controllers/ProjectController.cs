using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Common;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Project;
using ProjectsManagement.Extensions;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.Services;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class ProjectController : ControllerBase
{
    private readonly ProjectsManagementContext _context;
    private readonly ILogger _logger;
    private readonly ProjectService _projectService;
    public ProjectController(ProjectsManagementContext context, ILogger logger, ProjectService projectService)
    {
        this._context = context;
        this._logger = logger;
        this._projectService = projectService;
    }

    [AllowAnonymous]
    [HttpGet("/v1/projects")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var data = await _context.Projects.Include(x => x.Manager).Include(x => x.Milestones).Include(x => x.Squads).ToListAsync();
            return StatusCode(200, new BaseResponseDto<List<ResponseProjectDto>>(data.ConvertAll(ProjectMapper.FromModelToDto)));
        }
        catch (Exception e)
        {
            _logger.LogError(EventIds.ExceptionOccurred, e, "Aconteceu um erro ao buscar os projetos");
            return StatusCode(500, new BaseResponseDto<ResponseProjectDto>("Aconteceu um erro"));
        }
    }

    [HttpGet("/v1/projects/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var data = await _projectService.GetById(id);
            return StatusCode(200, new BaseResponseDto<ResponseProjectDto>(ProjectMapper.FromModelToDto(data)));
        }
        catch (Exception e)
        {
            _logger.LogError(EventIds.ExceptionOccurred, e, "Aconteceu um erro ao buscar o projeto");
            return StatusCode(500, new BaseResponseDto<ResponseProjectDto>("Aconteceu um erro"));
        }
    }

    [HttpPost("/v1/projects")]
    public async Task<IActionResult> Post(CreateProjectDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, new BaseResponseDto<ResponseProjectDto>(ModelState.GetErrors()));
            }
            var data = await _projectService.Create(dto);
            return StatusCode(201, new BaseResponseDto<ResponseProjectDto>(ProjectMapper.FromModelToDto(data)));
        }
        catch (Exception e)
        {
            _logger.LogError(EventIds.ExceptionOccurred, e, "Aconteceu um erro ao salvar o projeto");
            return StatusCode(500, new BaseResponseDto<ResponseProjectDto>("Aconteceu um erro"));
        }
    }

    [HttpPatch("/v1/projects/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProjectDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, new BaseResponseDto<ResponseProjectDto>(ModelState.GetErrors()));
            }
            var data = await _projectService.Update(id, dto);
            return StatusCode(200, new BaseResponseDto<ResponseProjectDto>(ProjectMapper.FromModelToDto(data)));
        }
        catch (Exception e)
        {
            _logger.LogError(EventIds.ExceptionOccurred, e, "Aconteceu um erro ao atualizar o projeto");
            return StatusCode(500, new BaseResponseDto<ResponseProjectDto>("Aconteceu um erro"));
        }
    }

    [HttpDelete("/v1/projects/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            var data = await _projectService.Delete(id);
            return StatusCode(200, new BaseResponseDto<ResponseProjectDto>());
        }
        catch (Exception e)
        {
            _logger.LogError(EventIds.ExceptionOccurred, e, "Aconteceu um erro ao deletar o projeto");
            return StatusCode(500, new BaseResponseDto<ResponseProjectDto>("Aconteceu um erro"));
        }
    }
}