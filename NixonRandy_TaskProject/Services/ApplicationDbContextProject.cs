using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NixonRandy_TaskProject.Data;
using NixonRandy_TaskProject.Models.Entities;
namespace NixonRandy_TaskProject.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    public  DbSet <IdentityUser> Users => Set<IdentityUser>();
    public DbSet <ProjectTask> Tasks => Set<ProjectTask>();
    public DbSet <Project> Projects => Set<Project>();
}
