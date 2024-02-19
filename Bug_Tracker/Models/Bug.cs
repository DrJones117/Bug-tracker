#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace products_and_categories.Models;

public class Bug
{
    [Key]
    public string BugId { get; set;}

    [Required]
    public string BugName { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Project? Host { get; set; }
}