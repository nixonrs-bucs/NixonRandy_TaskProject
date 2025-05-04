using Microsoft.EntityFrameworkCore;
using NixonRandy_Project1.Models.Entities;
namespace NixonRandy_Project1.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    public  DbSet <User> Users => Set<User>();
    public DbSet <ProjectTask> Tasks => Set<ProjectTask>();
    public DbSet <Project> Projects => Set<Project>();
}
