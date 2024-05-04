using ecoapp.DTOS;
using ecoapp.Models;
using ecoapp.Response;
using ecoapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ecoapp.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController
    {
        private IUserService Service;
        public UserController(IUserService service)
        {
            Service = service;
        }
        [HttpPost("login")]
        public async Task<ResponseObject<UserResponse>> Login([FromBody] UserDTO user)
        {
            try
            {
                return await Service.Login(user);
            }
            catch (Exception e)
            {
                var response = new ResponseObject<UserResponse>() { Code = 500, Data = null, Message = "error - " + e.Message};
                return response;
            }
        }
    }
}
