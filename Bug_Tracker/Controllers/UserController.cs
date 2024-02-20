using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bug_Tracker.Models;
using System.Diagnostics.CodeAnalysis;

namespace Bug_Tracker.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public  IActionResult Login_and_Reg()
    {
        return View();
    }

    // Displays the account information for the user.
    [HttpGet("users/myAccount")]
    public IActionResult MyAccount()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
