using System.ComponentModel.DataAnnotations;

namespace NixonRandy_Project1.Models.Entities;

public class User 
{
    /// <summary>
    /// This User class inherits from IdentityUser, which provides the basic properties for a user.
    /// </summary>
    /// 
    [Key]
    public int UserId { get; set; }
    [StringLength(100)]
    public string UserName { get; set; } = string.Empty;
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt
    {
        get 
        {
            return DateTime.Now;
        }
        set
        {
            CreatedAt = DateTime.Now;
        }
    }
    [DataType(DataType.DateTime)]
    public DateTime? UpdatedAt { get; set; } = null;
    [DataType(nameof(IsActive))]
    public bool IsActive { get; set; }
}
