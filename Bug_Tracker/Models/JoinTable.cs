#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Bug_Tracker.Models;

public class JoinTable
{
    [Key]
    public int JoinTableId { get; set; }
    public int UserId { get; set; }
    public int ProjectId { get; set; }

    public User? User { get; set; }
    public Project? Project { get; set; }
}