using Exam5.Business.Services.Interfaces;
using Exam5.Business.ViewModels.AuthVMs;
using Exam5.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Exam5.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AuthService(RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        public async Task<IdentityResult> Register(RegisterVM vm)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = vm.Username,
                Email = vm.Email,
            };
            var result = await _userManager.CreateAsync(user, vm.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Member.ToString());
            }
            return result;
        }

        public async Task<SignInResult> Login(LoginVM vm)
        {
            IdentityUser user;
            if(vm.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(vm.UsernameOrEmail);
            }
            if (user == null)
            {
                return new SignInResult();
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, false);
            return result;
        }

        public async Task<bool> CreateInits()
        {
            foreach (var item in Enum.GetNames(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(item))
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = item
                    });
                }
                else
                {
                    return false;
                }
            }
            IdentityUser user = new IdentityUser
            {
                UserName = "admin123",
                Email = "admin@gmail.com",
            };
            if (_userManager.FindByNameAsync(user.UserName) != null)
            {
                var result = await _userManager.CreateAsync(user, "Admin123");
            }
            else { return false; }
            var result2 = await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            if (!result2.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
