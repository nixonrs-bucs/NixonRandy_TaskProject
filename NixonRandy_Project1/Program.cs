using Microsoft.EntityFrameworkCore;
using NixonRandy_Project1.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<ILogger<Program>, Logger<Program>>(); // Add logging service
builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<ITasksRepo, TaskRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();  
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
