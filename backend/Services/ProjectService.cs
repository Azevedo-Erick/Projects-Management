using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos.Project;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;

namespace ProjectsManagement.Services;

public class ProjectService
{
    private readonly ProjectsManagementContext _context;

    public ProjectService(ProjectsManagementContext context)
    {
        this._context = context;

    }

    public async Task<Project> GetById(int id)
    {
        try
        {
            return await _context.Projects
                            .Include(x => x.Manager)
                            .Include(x => x.Milestones)
                            .Include(x => x.Squads)
                        .Where(x => x.Id == id)
                            .FirstOrDefaultAsync() ?? throw new Exception("Projeto não encontrado");
        }
        catch (Exception)
        {
            throw new Exception("Aconteceu um erro ao salvar o projeto");
        }
    }

    public async Task<Project> Create(CreateProjectDto dto)
    {
        try
        {
            //var data = ProjectMapper.FromDtoToModel(dto);
            var manager = await _context.Persons.FirstOrDefaultAsync(x => x.Id == dto.ManagerId) ?? throw new Exception("Não encontrado");
            var data = new Project
            {
                Name = dto.Name,
                Release = dto.Release,
                Manager = manager
            };
            await _context.Projects.AddAsync(data);
            _context.SaveChanges();
            return data;
        }
        catch (Exception)
        {
            throw new Exception("Aconteceu um erro ao salvar o projeto");
        }
    }

    public async Task<Project> Update(int id, UpdateProjectDto dto)
    {
        try
        {
            var model = await _context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Projeto não encontrado");

            if (model.Name != dto.Name && dto.Name is not null)
            {
                model.Name = dto.Name;
            }
            if (model.ManagerId != dto.ManagerId && dto.ManagerId is not null)
            {
                model.ManagerId = dto.ManagerId.Value;
            }
            if (model.Release != dto.Release && dto.Release is not null)
            {
                model.Release = dto.Release;
            }
            _context.Projects.Update(model);
            _context.SaveChanges();
            return model;
        }
        catch (Exception)
        {
            throw new Exception("Aconteceu um erro ao atualizar o projeto");
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var model = await _context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Projeto não encontrado");
            _context.Projects.Remove(model);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            throw new Exception("Aconteceu um erro ao deletar o projeto");
        }
    }


}
