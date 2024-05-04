using ecoapp.Models;

namespace ecoapp.Response
{
    public class UserResponse
    {
        public required int Id { get; set; }
        public string? Descripcion { get; set; }
        public double Balance { get; set; }
        public string? Token { get; set; }


    }
}
