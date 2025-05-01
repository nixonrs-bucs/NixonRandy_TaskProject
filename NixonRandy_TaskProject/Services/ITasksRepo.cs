using NixonRandy_TaskProject.Models.Entities;

namespace NixonRandy_TaskProject.Services;

public interface ITasksRepo
{
    public Task<ProjectTask> DetailsAsync(int id);
    public Task<ICollection<ProjectTask>> GetAllAsyncs();
    public Task<ProjectTask> CreateAsync(ProjectTask tasks);
    public Task EditAsync(int id, ProjectTask tasks);
    public Task DeleteAsync(int id);
}
