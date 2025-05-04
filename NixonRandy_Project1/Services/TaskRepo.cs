using Microsoft.EntityFrameworkCore;
using NixonRandy_Project1.Models.Entities;
namespace NixonRandy_Project1.Services;

public class TaskRepo : ITasksRepo      
{
    private readonly ApplicationDbContext _db;
    public TaskRepo(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<ProjectTask> DetailsAsync(int id)
    {
        return await _db.Tasks.FindAsync(id);
    }
    public async Task<ICollection<ProjectTask>> GetAllAsyncs()
    {
        return await _db.Tasks.ToListAsync();
    }
    public async Task<ProjectTask> CreateAsync(ProjectTask tasks)
    {
        await _db.Tasks.AddAsync(tasks);
        await _db.SaveChangesAsync();
        return tasks;
    }
    public async Task EditAsync(int id, ProjectTask tasks)
    {
        var existingTask = await _db.Tasks.FindAsync(id);
        if (existingTask != null)
        {
            existingTask.Title = tasks.Title;
            existingTask.Description = tasks.Description;
            existingTask.DueDate = tasks.DueDate;
            await _db.SaveChangesAsync();
        }
    }
    public async Task DeleteAsync(int id)
    {
        var task = await _db.Tasks.FindAsync(id);
        if (task != null)
        {
            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
        }
    }
}
