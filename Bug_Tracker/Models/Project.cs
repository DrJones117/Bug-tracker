using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

public class Project
{
    [Key]
    public int ProjectId { get; set; }

    [Required]
    public string ProjectName { get; set; }

    [Required]
    public string ProjectDescription { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Many to many with Users through JoinTable.
    public List<JoinTable> Users { get; set; } = new List<JoinTable>();

    // One to many with Bugs.
    public List<Bug> AllBugs { get; set; } = new List<Bug>();
}