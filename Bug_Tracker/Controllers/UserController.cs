using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bug_Tracker.Models;
namespace Bug_Tracker.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    private MyContext _context;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;

        _context = context;
    }

    // Displays the Login and Register page
    [HttpGet("")]
    public IActionResult Login_and_Reg()
    {
        return View();
    }

    // Handles the Register data and redirects to the landing page upon successful validation.
    [HttpPost("users/create")]
    public IActionResult Create(User newUser)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return View("Login_and_Reg");
        }
        else
        {
            _context.Add(newUser);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }

    // Handles the Login data and redirects to the landing page upon successful validation.
    public IActionResult LogIn(LogUser user)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == user.LogEmail);

            if (userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email");
                return View("");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        return View("");
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
