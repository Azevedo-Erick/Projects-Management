using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Dtos.State;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
//[Authorize]
public class StateController : ControllerBase
{

    private readonly ProjectsManagementContext _context;

    public StateController(ProjectsManagementContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/states")]
    public async Task<IActionResult> Get([FromQuery] StateQueryParams queryParams)
    {
        try
        {
            var data = await _context.States.AsQueryable().Apply(queryParams)
                .Include(x => x.Country).AsNoTracking().ToListAsync();

            return StatusCode(
                200,
                new BaseResponseDto<ResponseStateDto>(
                    data.Select(
                            x => StateMapper.FromModelToDto(x)
                        ).ToList()
                    )
                );
        }
        catch (Exception e)
        {

            Console.WriteLine(e);
            return StatusCode(
                500, new BaseResponseDto<ResponseCountryDto>(e.Message));
        }
    }


    [HttpGet("/v1/states/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var data = await _context.States.Where(x => x.Id == id)
            .Include(x => x.Country)
            .AsNoTracking()
            .FirstOrDefaultAsync();
            if (data == null)
            {
                return StatusCode(
                            400,
                           new BaseResponseDto<ResponseStateDto>(
                                  "Elemento não encontrado"
                               ));
            }
            return StatusCode(
               200,
               new BaseResponseDto<ResponseStateDto>(
                       StateMapper.FromModelToDto(data)
                   )
               );
        }
        catch (Exception e)
        {

            Console.WriteLine(e);
            return StatusCode(
                500, new BaseResponseDto<ResponseCountryDto>(e.Message));
        }
    }



    [HttpPost("/v1/states")]
    public async Task<IActionResult> Post(CreateStateDto dto)
    {
        try
        {
            if (!ModelState.IsValid) { }
            var data = StateMapper.FromDtoToModel(dto);

            var country = await _context.Countries.Where(x => x.Id == dto.CountryId).FirstOrDefaultAsync();
            if (country == null)
            {
                return StatusCode(
                           400,
                          new BaseResponseDto<ResponseStateDto>(
                                 "Elemento não encontrado"
                              ));
            }
            data.CountryId = country.Id;

            await _context.States.AddAsync(data);
            _context.SaveChanges();

            return StatusCode(
               200,
               new BaseResponseDto<ResponseStateDto>(
                       StateMapper.FromModelToDto(data)
                   )
               );
        }
        catch (Exception e)
        {

            Console.WriteLine(e);
            return StatusCode(
                500, new BaseResponseDto<ResponseCountryDto>(e.Message));
        }

    }



    [HttpPatch("/v1/states/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateStateDto dto)
    {
        try
        {
            if (!ModelState.IsValid) { }
            var element = await _context.States.Where(x => x.Id == id).Include(x => x.Country).FirstOrDefaultAsync();
            if (element == null)
            {
                return StatusCode(
                400);
            }
            var data = StateMapper.FromDtoToModel(dto);
            element.Name = data.Name;
            if (element.CountryId != data.CountryId)
            {
                var country = await _context.Countries.Where(x => x.Id == data.CountryId).FirstOrDefaultAsync();
                if (country == null)
                {
                    return StatusCode(
               400, "País não encontrado");
                }
                element.CountryId = country.Id;
            }
            _context.States.Update(element);
            _context.SaveChanges();

            return StatusCode(
               200,
               new BaseResponseDto<ResponseStateDto>(
                       StateMapper.FromModelToDto(element)
                   )
               );
        }
        catch (Exception e)
        {

            Console.WriteLine(e);
            return StatusCode(
                500, new BaseResponseDto<ResponseCountryDto>(e.Message));
        }

    }



    [HttpDelete("/v1/states/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            var element = await _context.States.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (element == null)
            {
                return StatusCode(
                400, "Estado não encontrado ");
            }
            _context.States.Remove(element);
            _context.SaveChanges();

            return StatusCode(
               200,
               new BaseResponseDto<ResponseStateDto>()
               );
        }
        catch (Exception e)
        {

            Console.WriteLine(e);
            return StatusCode(
                500, new BaseResponseDto<ResponseCountryDto>(e.Message));
        }

    }

}