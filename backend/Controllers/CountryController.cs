using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Extensions;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[Authorize]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ProjectsManagementContext _context;

    public CountryController(ProjectsManagementContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/countries")]
    public async Task<IActionResult> Get([FromQuery] CountryQueryParams queryParams)
    {
        var data = await _context.Countries.AsQueryable().Apply(queryParams).ToListAsync();
        return StatusCode(
            200,
            new BaseResponseDto<ResponseCountryDto>(
                data.Select(
                        x => CountryMapper.FromModelToDto(x)
                    ).ToList()
                )
            );
    }

    [HttpGet("/v1/countries/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(
            400);
        }
        return StatusCode(
           200,
           new BaseResponseDto<ResponseCountryDto>(
                   CountryMapper.FromModelToDto(data)
               )
           );

    }



    [HttpPost("/v1/countries")]
    [AllowAnonymous]
    public async Task<IActionResult> Post(CreateCountryDto dto)
    {
        if (!ModelState.IsValid)
        {

            return StatusCode(400, new BaseResponseDto<ResponseCountryDto>(ModelState.GetErrors()));
        }

        var data = CountryMapper.FromDtoToModel(dto);
        Console.WriteLine(data.Name);
        await _context.Countries.AddAsync(data);
        _context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseCountryDto>(
                   CountryMapper.FromModelToDto(data)
               )
           );
    }



    [HttpPatch("/v1/countries/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateCountryDto dto)
    {
        if (!ModelState.IsValid) { }

        var element = await _context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }

        var data = CountryMapper.FromDtoToModel(dto);

        element.Name = data.Name;
        _context.Countries.Update(element);

        _context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseCountryDto>(
                   CountryMapper.FromModelToDto(element)
               )
           );
    }



    [HttpDelete("/v1/countries/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var element = await _context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }
        _context.Countries.Remove(element);
        return StatusCode(
           200,
           new BaseResponseDto<ResponseCountryDto>()
           );
    }

}