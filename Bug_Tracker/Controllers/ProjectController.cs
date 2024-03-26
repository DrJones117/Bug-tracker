using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bug_Tracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http.Metadata;

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

    // Grabs one Project and displays it on the page
    [HttpGet("projects/{projectId}/display")]
    public IActionResult ViewProject(int projectId)
    {
        Console.WriteLine(projectId);

        Project? singleProject = _context.Projects
                                .Include(u => u.Users)
                                .Include(a => a.AllBugs)
                                .FirstOrDefault(p => p.ProjectId == projectId);

        if(singleProject != null)
        {
            return View(singleProject);
        }

        return RedirectToAction("Projects");
    }

    // Displays th Edit project form
    [HttpGet("projects/{projectId}/edit")]
    public IActionResult EditProjectForm(int projectId)
    {
        Console.WriteLine(projectId);

        Project? singleProject = _context.Projects.FirstOrDefault(p => p.ProjectId == projectId);

        if(singleProject != null)
        {
            return View(singleProject);
        }

        return RedirectToAction("Projects");
    }

    // Shoves the edited data to the database
    [HttpPost("porjects/{projectId}/update")]
    public IActionResult UpdateProject(Project newProject, int projectId)
    {
        Project? oldProject = _context.Projects.FirstOrDefault(i => i.ProjectId == projectId);

        if(ModelState.IsValid)
        {
            oldProject.ProjectName = newProject.ProjectName;
            oldProject.ProjectDescription = newProject.ProjectDescription;

            oldProject.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("MyProjects");
        } else {

            return View("EditProjectForm", oldProject);
        }
    }

    [HttpPost("projects/{projectId}/delete")]
    public IActionResult DeleteProject(int projectId)
    {
        Project? ProjectToDelete = _context.Projects.SingleOrDefault(i => i.ProjectId == projectId);
        Console.WriteLine("Project grabbed");

        if (ProjectToDelete != null)
        {
            Console.WriteLine(ProjectToDelete.ProjectName);
            _context.Projects.Remove(ProjectToDelete);
            _context.SaveChanges();
        }
        
        return RedirectToAction("MyProjects");
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
