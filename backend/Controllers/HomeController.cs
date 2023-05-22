using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos.Login;
using ProjectsManagement.Services;

namespace ProjectsManagement.Controllers;

public class HomeController : ControllerBase
{
    private readonly ProjectsManagementContext _context;
    private readonly JwtTokenService _jwtTokenService;
    public HomeController(ProjectsManagementContext context, JwtTokenService jwtTokenService)
    {
        this._context = context;
        this._jwtTokenService = jwtTokenService;
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Post(RequestLoginDto dto)
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

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

        if (!isPasswordValid)
        {
            return StatusCode(401);
        }
        return Ok(_jwtTokenService.GenerateToken(user));
    }
}
