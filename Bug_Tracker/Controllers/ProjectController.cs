using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bug_Tracker.Models;

namespace Bug_Tracker.Controllers;

public class ProjectController : Controller
{
    private readonly ILogger<ProjectController> _logger;

    private MyContext _context;

    public ProjectController(ILogger<ProjectController> logger, MyContext context)
    {
        _logger = logger;

        _context = context;
    }


    // Displays the main Landing Page for the site.
    [HttpGet("projects/landingPage")]
    public IActionResult Index()
    {
        return View();
    }

    // Displays the the projects created by the user
    [HttpGet("projects/myProjects")]
    public IActionResult MyProjects()
    {
        List<Project> AllProjects = _context.Projects.ToList();
        ViewBag.AllProjects = new List<Project>();

        return View(AllProjects);
    }

    // Displays the settings page
    [HttpGet("projects/settings")]
    public IActionResult Settings()
    {
        return View();
    }

    // Displays the Project Form
    [HttpGet("projects/new")]
    public IActionResult ProjectForm()
    {
        return View();
    }

    // Handles the data from the Project Form
    [HttpPost("projects/create")]
    public IActionResult AddProject(Project newProject)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return View("ProjectForm");
        }
        else
        {
            _context.Add(newProject);
            _context.SaveChanges();

            return RedirectToAction("MyProjects");
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
