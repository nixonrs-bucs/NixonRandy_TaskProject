using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NixonRandy_Project1.Models.Entities;
public class ProjectTask : Project
{
    /// <summary>
    /// This class represents a task entity. Each task is associated 
    /// with a project and can have a title, description, creation date, and due date.
    /// </summary>
    [ForeignKey(nameof(ProjectId))]
    public int ProjectId { get; set; }
    [StringLength(100)]
    public string TaskTitle { get; set; } = string.Empty;
    [StringLength(500)]
    public string? TaskDescription { get; set; } = string.Empty;
    [DataType(DataType.Date)]
    public DateTime TaskCreationDate 
    {
        get 
        {
            return DateTime.Now;
        }
        set 
        {
            TaskCreationDate = DateTime.Now;
        } 
    } 
    [DataType(DataType.Date)]
    public DateTime? TaskDueDate { get; set; } = null;
    [ForeignKey(nameof(UserId))]
    public int? UserId { get; set; }
    public User? Fuser { get; set; } 
}
