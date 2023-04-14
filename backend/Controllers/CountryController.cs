using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Factories;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class CountryController : ControllerBase
{

    ProjectsManagementContext Context;

    CountryController(ProjectsManagementContext context)
    {
        Context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/countries")]
    public async Task<IActionResult> Get([FromQuery] CountryQueryParams queryParams)
    {
        var data = await Context.Countries.AsQueryable().Apply(queryParams).ToListAsync();
        return StatusCode(
            200,
            new BaseResponseDto<ResponseCountryDto>(
                data.Select(
                        x => CountryFactory.FromModelToDto(x)
                    ).ToList()
                )
            );
    }

    [HttpGet("/v1/countries/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await Context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(
            400);
        }
        return StatusCode(
           200,
           new BaseResponseDto<ResponseCountryDto>(
                   CountryFactory.FromModelToDto(data)
               )
           );

    }



    [HttpPost("/v1/countries")]
    public async Task<IActionResult> Post(CreateCountryDto dto)
    {
        if (!ModelState.IsValid) { }

        var data = CountryFactory.FromDtoToModel(dto);

        await Context.Countries.AddAsync(data);
        Context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseCountryDto>(
                   CountryFactory.FromModelToDto(data)
               )
           );
    }



    [HttpPatch("/v1/countries/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateCountryDto dto)
    {
        if (!ModelState.IsValid) { }

        var element = await Context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }

        var data = CountryFactory.FromDtoToModel(dto);

        element.Name = data.Name;
        Context.Countries.Update(element);

        Context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseCountryDto>(
                   CountryFactory.FromModelToDto(element)
               )
           );
    }



    [HttpDelete("/v1/countries/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var element = await Context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }
        Context.Countries.Remove(element);
        return StatusCode(
           200,
           new BaseResponseDto<ResponseCountryDto>()
           );
    }

}