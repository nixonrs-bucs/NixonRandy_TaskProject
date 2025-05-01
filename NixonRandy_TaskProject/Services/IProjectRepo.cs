using NixonRandy_TaskProject.Models.Entities;

namespace NixonRandy_TaskProject.Services;

public interface IProjectRepo
{
    public Task<Project> DetailsAsync(int id);
    public Task<ICollection<Project>> GetAllAsyncs();
    public Task<Project> CreateAsync(Project project);
    public Task EditAsync(int id, Project project);
    public Task DeleteAsync(int id);
}
