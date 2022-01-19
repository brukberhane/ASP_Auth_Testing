using System.Net;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AUTH2_TEST.Models;
using Microsoft.AspNetCore.Authorization;

namespace AUTH2_TEST.Controllers;

public class ProtectedController : Controller
{
    private readonly ILogger<ProtectedController> _logger;

    public ProtectedController(ILogger<ProtectedController> logger)
    {
        _logger = logger;
    }

    [Authorize(Roles = Constants.UserTypes.Student)]
    public IActionResult Index()
    {
        return View();
    }

    
   [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
