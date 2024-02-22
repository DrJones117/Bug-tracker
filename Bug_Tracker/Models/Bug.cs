using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

public class Bug
{
    [Key]
    public int BugId { get; set; }

    [Required]
    public string BugName { get; set; }

    [Required]
    public string BugStatus { get; set; }

    [Required]
    public string BugDescription { get; set; }

    public int ProjectId { get; set; }

    // One to many with Bugs.
    public Project? BugHost { get; set; }
}