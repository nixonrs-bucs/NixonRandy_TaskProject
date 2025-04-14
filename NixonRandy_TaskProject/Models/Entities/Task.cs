namespace NixonRandy_TaskProject.Models.Entities;
public class Task : Project
{
    public int projectId { get; set; }
    public string TaskTitle { get; set; } = string.Empty;
    public string? TaskDescription { get; set; } = string.Empty;
    public DateTime TaskCreationDate { get; set; } = DateTime.Now;
    public DateTime? TaskDueDate { get; set; } = null;
}
