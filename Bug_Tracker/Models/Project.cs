#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Bug_Tracker.Models;

public class Project
{
    [Key]
    public int ProjectId { get; set; }

    [Required]
    public string ProjectName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public List<JoinTable> Users { get; set; } = new List<JoinTable>();
    public List<Bug> AllBugs { get; set; } = new List<Bug>();
}