namespace ecoapp.Models
{
    public class UserModel
    {
        public required int Id { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string PasswordUser { get; set; }
        public double Balance { get; set; }
        public required ICollection<LogModel> Logs { get; set; }
    }
}
