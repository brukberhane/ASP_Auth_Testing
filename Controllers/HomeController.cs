using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AUTH2_TEST.Models;
using AUTH2_TEST.Repositories;
using AUTH2_TEST.Services;

namespace AUTH2_TEST.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

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

    public IActionResult Login()
    {
        User user = new User();
        return View(user);
    }

    [HttpPost]
    public IActionResult PerformLogin(User model)
    {
        var user = MochUserRepository.Get(model.Username, model.Password);

        if (user == null)
            return Redirect("/Home/Login");

        var token = TokenService.CreateToken(user);
        user.Password = "";

        HttpContext.Session.SetString("JWToken", token);
        return Ok(new { Token = token, Message = "Success"});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
