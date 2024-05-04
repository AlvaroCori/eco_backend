using ecoapp.Models;

namespace ecoapp.Repositories
{
    public interface IAuthenticationRepository
    {
        public Task<UserModel?> Login(UserModel user);
    }
}
