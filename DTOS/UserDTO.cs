namespace ecoapp.DTOS
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string PasswordUser { get; set; }
    }
}
