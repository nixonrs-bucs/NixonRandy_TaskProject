namespace NixonRandy_TaskProject.Models.Entities;
public class Project
{
   public int ProjectId { get; set; }
   public string Title { get; set; } = string.Empty;
   public string? Description { get; set; } = string.Empty;
   public DateTime CreationDate { get; set; } = DateTime.Now;
   public DateTime? DueDate { get; set; } = null;
}
