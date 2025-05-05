using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NixonRandy_Project1.Models.Entities;

public class TaskProject
{
    [Key]
    public int TaskProjectId { get; set; }

    [ForeignKey(nameof(FTask))]
    public int TaskId { get; set; }

    [ForeignKey(nameof(FProject))]
    public int ProjectId { get; set; }

    public ProjectTask? FTask { get; set; }
    public Project? FProject { get; set; }
}
