using Exam5.Business.ViewModels.AuthVMs;

namespace Exam5.Business.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> Register(RegisterVM vm);
        public Task<bool> Login(LoginVM vm);
        public Task<bool> CreateInits();
        public Task Logout();
    }
}
