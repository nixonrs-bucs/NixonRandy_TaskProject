using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NixonRandy_Project1.Models.Entities;

public class UserProject
{
    [Key]
    public int UserProjectId { get; set; }

    [ForeignKey(nameof(FUser))]   
    public int UserId { get; set; }

    [ForeignKey(nameof(FProject))] 
    public int ProjectId { get; set; }

    public virtual User? FUser { get; set; }
    public virtual Project? FProject { get; set; }
}
