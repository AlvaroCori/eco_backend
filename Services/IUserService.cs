using ecoapp.DTOS;
using ecoapp.Response;

namespace ecoapp.Services
{
    public interface IUserService
    {
        public Task<ResponseObject<UserResponse>> Login(UserDTO user);
    }
}
