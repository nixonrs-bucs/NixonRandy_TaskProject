using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NixonRandy_Project1.Models.Entities;

namespace NixonRandy_Project1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<ProjectTask> Tasks => Set<ProjectTask>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<TaskProject> TaskProjects => Set<TaskProject>();
        public DbSet<UserProject> UserProjects => Set<UserProject>();
    }
}
