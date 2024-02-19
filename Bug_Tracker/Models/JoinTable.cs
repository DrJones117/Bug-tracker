#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace products_and_categories.Models;

public class JoinTable
{
    [Key]
    public int JoinTableId { get; set; }
    public int UserId { get; set; }
    public int ProjectId { get; set; }

    public User? User { get; set; }
    public Project? Project { get; set; }
}