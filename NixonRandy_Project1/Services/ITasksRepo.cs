using NixonRandy_Project1.Models.Entities;
using NixonRandy_Project1.Data;
namespace NixonRandy_Project1.Services;

public interface ITasksRepo
{
    public Task<ProjectTask> DetailsAsync(int id);
    public Task<ICollection<ProjectTask>> GetAllAsyncs();
    public Task<ProjectTask> CreateAsync(ProjectTask tasks);
    public Task EditAsync(int id, ProjectTask tasks);
    public Task DeleteAsync(int id);
}
