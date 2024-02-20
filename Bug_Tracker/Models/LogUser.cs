#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Bug_Tracker.Models;

public class LogUser
{
    [Required(ErrorMessage = "Invalid Email/Password")]
    [Display(Name = "Email")]
    [EmailAddress]
    public string LogEmail { get; set; }
}