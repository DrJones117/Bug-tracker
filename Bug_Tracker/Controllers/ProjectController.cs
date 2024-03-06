using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bug_Tracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        return View(AllProjects);
    }

    // Displays the settings page
    [HttpGet("projects/settings")]
    public IActionResult Settings()
    {
        List<Project> AllProjects = _context.Projects.ToList();

        // Project singleProject = TempData["singleProject"] as Project;

        return View(AllProjects);
    }

    // Displays th Edit project form
    [HttpGet("projects/{projectId}/edit")]
    public IActionResult EditProject(int projectId)
    {
        if (projectId != null)
        {
            Project singleProject = _context.Projects.FirstOrDefault(p => p.ProjectId == projectId);

            return View(singleProject);
        }

        return RedirectToAction("Settings");
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
