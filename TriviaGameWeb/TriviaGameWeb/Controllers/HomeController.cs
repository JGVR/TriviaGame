using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TriviaGameWeb.Models;

namespace TriviaGameWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    [BindProperty]
    public int id { get; set; }

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult StartGame()
    {
        return RedirectToAction("StartGame", "Game");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

