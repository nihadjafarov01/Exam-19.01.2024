using Exam5.Business.Services.Implements;
using Exam5.Business.Services.Interfaces;
using Exam5.Business.ViewModels.AuthVMs;
using Microsoft.AspNetCore.Mvc;

namespace Exam5.Controllers
{
    public class AuthController : Controller
    {
        IAuthService _service { get; }

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _service.Login(vm);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            ModelState.AddModelError("","Email or password is wrong");
            return View(vm);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _service.Register(vm);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(vm);
        }

        public async Task<bool> CreateInits()
        {
            return await _service.CreateInits();
        }
        public async Task<IActionResult> Logout()
        {
            await _service.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
