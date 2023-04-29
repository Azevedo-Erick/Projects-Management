using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Person;
using ProjectsManagement.Extensions;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
//[Authorize]
public class PersonController : ControllerBase
{

    private readonly ProjectsManagementContext _context;

    public PersonController(ProjectsManagementContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/persons")]
    public async Task<IActionResult> Get([FromQuery] PersonQueryParams queryParams)
    {
        var data = await _context.Persons.AsQueryable().Apply(queryParams).ToListAsync();
        return StatusCode(200, new BaseResponseDto<ResponsePersonDto>(data.Select(PersonMapper.FromModelToDto).ToList()));
    }


    [HttpGet("/v1/persons/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponsePersonDto>());
        }
        return StatusCode(200, new BaseResponseDto<ResponsePersonDto>(PersonMapper.FromModelToDto(data)));
    }



    [HttpPost("/v1/persons")]
    public async Task<IActionResult> Post(CreatePersonDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400, new BaseResponseDto<ResponsePersonDto>(ModelState.GetErrors()));
        }

        var data = PersonMapper.FromDtoToModel(dto);

        var addresses = await _context.Addresses.Where(x => dto.Addresses.Contains(x.Id)).ToListAsync();
        var contacts = await _context.ContactInfos.Where(x => dto.Contacts.Contains(x.Id)).ToListAsync();

        data.Contacts = contacts;
        data.Addresses = addresses;

        _context.Persons.Add(data);
        _context.SaveChanges();

        return StatusCode(200, new BaseResponseDto<ResponsePersonDto>(PersonMapper.FromModelToDto(data)));

    }



    [HttpPatch("/v1/persons/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Person dto) { return null; }



    [HttpDelete("/v1/persons/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}