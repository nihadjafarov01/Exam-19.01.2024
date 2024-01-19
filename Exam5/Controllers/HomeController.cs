using Exam5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam5.Controllers
{
    public class HomeController : Controller
    {
        IInstructorService _service {  get; }

        public HomeController(IInstructorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
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