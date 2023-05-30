using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos.Squad;
using ProjectsManagement.Models;

namespace ProjectsManagement.Services;

public class SquadService
{
    private readonly ProjectsManagementContext _context;

    public SquadService(ProjectsManagementContext context)
    {
        this._context = context;
    }
    public async Task<Squad> AddMember(AddMemberToSquadDto dto)
    {
        try
        {
            var squad = await _context.Squads.Include(x => x.Team).Where(x => x.Id == dto.SquadId).FirstOrDefaultAsync() ?? throw new Exception("Projeto não encontrado");
            var person = await _context.Persons.Where(x => x.Id == dto.PersonId).FirstOrDefaultAsync() ?? throw new Exception("Pessoa não encontrada");

            var role = await _context.Roles.Where(x => x.Id == dto.RoleId).FirstOrDefaultAsync() ?? throw new Exception("Cargo não encontrado");
            var member = new Member
            {
                Person = person,
                Role = role,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            _context.Members.Add(member);
            squad.Team.Add(member);
            _context.Squads.Update(squad);
            _context.SaveChanges();
            return squad;
        }
        catch (Exception)
        {
            throw new Exception("Aconteceu um erro ao adicionar o membro no projeto");
        }
    }

    public async Task<bool> RemoveMember(int memberId)
    {
        try
        {
            var member = await _context.Members
            .Where(x => x.Id == memberId).FirstOrDefaultAsync() ?? throw new Exception("Membro não encontrado");
            _context.Members.Remove(member);
            _context.Update(member);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            throw new Exception("Aconteceu um erro ao remover o membro do squad");
        }
    }
}
