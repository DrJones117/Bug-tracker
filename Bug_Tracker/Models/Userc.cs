using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618s

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Email { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Many to many with Projects through JoinTable.
    public List<JoinTable> Projects { get; set; } = new List<JoinTable>();
}