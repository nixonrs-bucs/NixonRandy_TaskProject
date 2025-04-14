using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NixonRandy_TaskProject.Models.Entities;

public class User : IdentityUser
{
    public string UserName { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null;
    public bool IsActive { get; set; } = true;
}
