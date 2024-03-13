using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618s

public class JoinTable
{
    [Key]
    public int JoinTableId { get; set; }
    public int UserId { get; set; }
    public int ProjectId { get; set; }

    // nav props
    public User? User { get; set; }
    public Project? Project { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}