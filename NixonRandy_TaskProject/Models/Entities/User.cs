using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NixonRandy_TaskProject.Models.Entities;

public class User : IdentityUser
{
    /// <summary>
    /// This User class inherits from IdentityUser, which provides the basic properties for a user.
    /// </summary>
    /// 
    [StringLength(100)]
    public override string UserName { get; set; } = string.Empty;
    [StringLength(100)]
    public override string Email { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [DataType(DataType.DateTime)]
    public DateTime? UpdatedAt { get; set; } = null;
    [DataType(nameof(IsActive))]
    public bool IsActive { get; set; } = true;
}
