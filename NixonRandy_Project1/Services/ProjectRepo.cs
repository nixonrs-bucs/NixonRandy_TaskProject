using Microsoft.EntityFrameworkCore;
using NixonRandy_Project1.Models.Entities;
using NixonRandy_Project1.Data;
namespace NixonRandy_Project1.Services;

public class ProjectRepo : IProjectRepo
{
    private readonly ApplicationDbContext _db;
    public ProjectRepo(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<Project> DetailsAsync(int id)
    {
        return await _db.Projects.FindAsync(id);
    }
    public async Task<ICollection<Project>> GetAllAsyncs()
    {
        return await _db.Projects.ToListAsync();
    }
    public async Task<Project> CreateAsync(Project project)
    {
        project.CreationDate = DateTime.Now;
        await _db.Projects.AddAsync(project);
        await _db.SaveChangesAsync();
        return project;
    }
    public async Task EditAsync(int id, Project project)
    {
        var existingProject = await _db.Projects.FindAsync(id);
        if (existingProject != null)
        {
            existingProject.Title = project.Title;
            existingProject.Description = project.Description;
            existingProject.DueDate = project.DueDate;
            await _db.SaveChangesAsync();
        }
    }
    public async Task DeleteAsync(int id)
    {
        var project = await _db.Projects.FindAsync(id);
        if (project != null)
        {
            _db.Projects.Remove(project);
            await _db.SaveChangesAsync();
        }
    }
}
