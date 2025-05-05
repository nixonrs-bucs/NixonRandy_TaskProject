using NixonRandy_Project1.Models.Entities;

namespace NixonRandy_Project1.Services;

public interface IProjectRepo
{
    public Task<Project> DetailsAsync(int id);
    public Task<ICollection<Project>> GetAllAsyncs();
    public Task<Project> CreateAsync(Project project);
    public Task EditAsync(int id, Project project);
    public Task DeleteAsync(int id);
}
