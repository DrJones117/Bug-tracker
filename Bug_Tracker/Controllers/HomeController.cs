using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bug_Tracker.Models;

namespace Bug_Tracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    // Displays the main Landing Page for the site.
    [HttpGet("bugs/landingPage")]
    public IActionResult Index()
    {
        return View();
    }


    // Displays the bug dashboard
    [HttpGet("bugs/dashboard")]
    public IActionResult BugDashBoard()
    {
        return View();
    }

    // Displays the the projects created by the user
    [HttpGet("bugs/myProjects")]
    public IActionResult MyProjects()
    {
        return View();
    }

    // Displays the settings page
    [HttpGet("bugs/settings")]
    public IActionResult Settings()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
