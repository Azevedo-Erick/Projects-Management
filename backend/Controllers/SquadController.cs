using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using AutoMapper;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Squad;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class SquadController : ControllerBase
{
    private readonly ProjectsManagementContext _context;

    private readonly IMapper _mapper;
    public SquadController(ProjectsManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    [AllowAnonymous]
    [HttpGet("/v1/squads")]
    public async Task<IActionResult> Get()
    {
        var data = await _context.Squads.Include(x => x.Team).ToListAsync();
        return StatusCode(200, new BaseResponseDto<List<ResponseSquadDto>>(data.ConvertAll(SquadMapper.FromModelToDto)));
    }

    [HttpGet("/v1/squads/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.Squads.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);
        }
        return StatusCode(200, new BaseResponseDto<ResponseSquadDto>(SquadMapper.FromModelToDto(data)));
    }


    [HttpPost("/v1/squads")]
    public async Task<IActionResult> Post(CreateSquadDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }
        var model = SquadMapper.FromDtoToModel(dto);
        var members = await _context.Members.Where(x => dto.Members.Contains(x.Id)).ToListAsync();
        if (members == null)
        {
            return StatusCode(400);
        }
        model.Team = members;

        _context.Squads.Add(model);
        _context.SaveChanges();
        return StatusCode(200, new BaseResponseDto<ResponseSquadDto>(SquadMapper.FromModelToDto(model)));

    }

    [HttpPatch("/v1/squads/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Squad dto) { return null; }

    [HttpDelete("/v1/squads/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var data = await _context.Squads.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);
        }
        _context.Squads.Remove(data);
        _context.SaveChanges();
        return StatusCode(200, new BaseResponseDto<ResponseSquadDto>());
    }
}