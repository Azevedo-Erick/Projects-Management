using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Tag;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class TagController : ControllerBase
{

    private readonly ProjectsManagementContext _context;

    public TagController(ProjectsManagementContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/tags")]
    public async Task<IActionResult> Get([FromQuery] TagQueryParams queryParams)
    {
        var data = await _context.Tags.AsQueryable().Apply(queryParams).ToListAsync();
        return StatusCode(200, new BaseResponseDto<ResponseTagDto>(data.Select(TagMapper.FromModelToDto).ToList()));
    }


    [HttpGet("/v1/tags/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.Tags.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseTagDto>());
        }
        return StatusCode(200, new BaseResponseDto<ResponseTagDto>(TagMapper.FromModelToDto(data)));
    }



    [HttpPost("/v1/tags")]
    public async Task<IActionResult> Post(CreateTagDto dto)
    {
        if (!ModelState.IsValid) { }
        var data = TagMapper.FromDtoToModel(dto);
        await _context.Tags.AddAsync(data);
        _context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseTagDto>(
                   TagMapper.FromModelToDto(data)
               )
           );
    }



    [HttpPatch("/v1/tags/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateTagDto dto)
    {
        if (!ModelState.IsValid) { }

        var data = await _context.Tags.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(
                400,
           new BaseResponseDto<ResponseTagDto>()
            );
        }

        var serializedData = TagMapper.FromDtoToModel(dto);

        if (data.Title != serializedData.Title)
        {
            data.Title = serializedData.Title;
        }
        if (data.HexColor != serializedData.HexColor)
        {
            data.HexColor = serializedData.HexColor;

        }
        _context.Tags.Update(data);
        _context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseTagDto>(
                   TagMapper.FromModelToDto(data)
               )
           );
    }



    [HttpDelete("/v1/tags/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var data = await _context.Tags.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(
                400,
           new BaseResponseDto<ResponseTagDto>()
            );
        }

        _context.Tags.Remove(data);
        _context.SaveChanges();

        return StatusCode(
          200,
          new BaseResponseDto<ResponseTagDto>(
              )
          );
    }

}