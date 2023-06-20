using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos.Login;
using ProjectsManagement.Providers;
using ProjectsManagement.Services;

namespace ProjectsManagement.Controllers;

public class HomeController : ControllerBase
{
    private readonly ProjectsManagementContext _context;
    private readonly IJwtProvider _jwtProvider;
    private readonly IMapper _mapper;
    public HomeController(ProjectsManagementContext context, IJwtProvider jwtProvider, IMapper mapper)
    {
        this._context = context;
        this._jwtProvider = jwtProvider;
        _mapper = mapper;

    }

    [HttpPost("/login")]
    public async Task<IActionResult> Post([FromBody] RequestLoginDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }

        var user = await _context.Persons.Where(x => x.Email == dto.Email).FirstOrDefaultAsync();

        if (user == null)
        {
            return StatusCode(401);

        }

        /*  bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

         if (!isPasswordValid)
         {
             return StatusCode(401);
         } */
        string token = _jwtProvider.Generate(user);
        return Ok(token);
    }
}
