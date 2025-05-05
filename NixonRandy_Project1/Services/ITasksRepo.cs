using NixonRandy_Project1.Models.Entities;
using NixonRandy_Project1.Data;
namespace NixonRandy_Project1.Services;

public interface ITasksRepo
{
    public Task<ProjectTask> DetailsAsync(int id);
    public ProjectTask Details(int id);
    public Task<ICollection<ProjectTask>> GetAllAsyncs();
    public ICollection<ProjectTask> GetAll();
    public Task<ProjectTask> CreateAsync(ProjectTask tasks);
    public ProjectTask Create(ProjectTask tasks);
    public Task EditAsync(int id, ProjectTask tasks);
    public void Edit(int id, ProjectTask tasks);
    public Task DeleteAsync(int id);
    public void Delete(int id);
}
