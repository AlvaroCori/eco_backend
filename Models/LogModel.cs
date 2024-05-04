namespace ecoapp.Models
{
    public class LogModel
    {
        public required int Id { get; set; }
        public required int UserId { get; set; }
        public required string TableRegitered { get; set; }
        public required string Action { get; set; }
        public required string Detail { get; set; }
        public required DateTime DateRegistered { get; set; }
        public required UserModel User { get; set; }
    }
}
