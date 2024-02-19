#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace products_and_categories.Models;

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

    public List<JoinTable> Projects { get; set; } = new List<JoinTable>();
}