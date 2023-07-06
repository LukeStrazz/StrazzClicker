using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CookieClicker.Models;

namespace CookieClicker.Controllers;

public class HomeController : Controller
{
    private const string CounterKey = "Counter";

    public IActionResult Index()
    {
        // Initialize the counter if it doesn't exist
        if (HttpContext.Session.GetInt32(CounterKey) == null)
        {
            HttpContext.Session.SetInt32(CounterKey, 0);
        }

        // Pass the counter to the view
        ViewBag.Counter = HttpContext.Session.GetInt32(CounterKey);

        return View();
    }

    [HttpPost]
    public IActionResult IncrementCounter()
    {
        int counter = HttpContext.Session.GetInt32(CounterKey) ?? 0;
        counter++;

        HttpContext.Session.SetInt32(CounterKey, counter);

        return Json(new { status = "success", counter = counter });
    }
}