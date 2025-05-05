using Microsoft.EntityFrameworkCore;
using NixonRandy_Project1.Models.Entities;
namespace NixonRandy_Project1.Services;
using NixonRandy_Project1.Data;
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
    public ProjectTask Details(int id)
    {
        return _db.Tasks.Find(id);
    }
    public async Task<ICollection<ProjectTask>> GetAllAsyncs()
    {
        return await _db.Tasks.ToListAsync();
    }
    public ICollection<ProjectTask> GetAll()
    {
        return _db.Tasks.ToList();
    }
    public async Task<ProjectTask> CreateAsync(ProjectTask tasks)
    {
        tasks.TaskCreationDate = DateTime.Now;
        await _db.Tasks.AddAsync(tasks);
        await _db.SaveChangesAsync();
        return tasks;
    }
    public ProjectTask Create(ProjectTask tasks)
    {
        tasks.TaskCreationDate = DateTime.Now;
        _db.Tasks.Add(tasks);
        _db.SaveChanges();
        return tasks;
    }
    public async Task EditAsync(int id, ProjectTask tasks)
    {
        var existingTask = await _db.Tasks.FindAsync(id);
        if (existingTask != null)
        {
            existingTask.TaskTitle = tasks.TaskTitle;
            existingTask.TaskDescription = tasks.TaskDescription;
            existingTask.TaskDueDate = tasks.TaskDueDate;
            await _db.SaveChangesAsync();
        }
    }
    public void Edit(int id, ProjectTask tasks)
    {
        var existingTask = _db.Tasks.Find(id);
        if (existingTask != null)
        {
            existingTask.TaskTitle = tasks.TaskTitle;
            existingTask.TaskDescription = tasks.TaskDescription;
            existingTask.TaskDueDate = tasks.TaskDueDate;
            _db.SaveChanges();
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
    public void Delete(int id)
    {
        var task = _db.Tasks.Find(id);
        if (task != null)
        {
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }
    }
}
