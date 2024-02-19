#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace products_and_categories.Models;

public class Project
{
    [Key]
    public string ProjectId { get; set; }

    [Required]
    public string ProjectName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public List<Bug> AllBugs { get; set; } = new List<Bug>();
    public List<JoinTable> Users { get; set; } = new List<JoinTable>();
}