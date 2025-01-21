using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IAuthenticationInterface
    {
        public Task<string> AuthenticateAsync(string userid ,string username);
    }
}
