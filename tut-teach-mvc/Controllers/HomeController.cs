using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tut_teach_mvc.Models;

namespace tut_teach_mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public string Index()
    {
        return "This is my <b>default</b> action...";
    }

    public string Welcome()
    {
        return "This is my <b>default</b> action...";
    }
}
