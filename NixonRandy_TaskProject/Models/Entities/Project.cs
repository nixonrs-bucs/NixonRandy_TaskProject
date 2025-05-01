using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NixonRandy_TaskProject.Models.Entities;
[PrimaryKey(nameof(ProjectId))]
public class Project
{
    /// <summary>
    /// This class represents a project entity. Each project can have multiple tasks associated with it.
    /// </summary>
    /// 
    public int ProjectId { get; set; }
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;
    [StringLength(500)]
    public string? Description { get; set; } = string.Empty;
    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; } = DateTime.Now;
    [DataType(DataType.Date)]   
    public DateTime? DueDate { get; set; } = null;
    [DataType(nameof(Tasks))]
    public IEnumerable<ProjectTask>? Tasks { get; set; } = new List<ProjectTask>();
}
