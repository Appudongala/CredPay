using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Payments.Models;

namespace Payments.Controllers
{
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
        public IActionResult Login(string username, string password)
        {
            try
            {
                if (username == "satya" && password == "123")
                {
                    return RedirectToAction("Payment", "Payments");
                }
                //else
                //{
                //    return RedirectToAction("Login","Home");
                //}
            }
            catch (Exception ex)
            {

            }
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
}
