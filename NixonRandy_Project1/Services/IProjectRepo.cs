using NixonRandy_Project1.Models.Entities;

namespace NixonRandy_Project1.Services;

public interface IProjectRepo
{
    public Task<Project> DetailsAsync(int id);
    public Project Details(int id);
    public Task<ICollection<Project>> GetAllAsyncs();
    public ICollection<Project> GetAll();
    public Task<Project> CreateAsync(Project project);
    public Project Create(Project project);
    public Task EditAsync(int id, Project project);
    public void Edit(int id, Project project);
    public Task DeleteAsync(int id);
    public void Delete(int id);
}
