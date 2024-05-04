namespace ecoapp.Models
{
    public class ExpenseModel
    {
        public required int Id { get; set; }
        public required DateTime DateRegister { get; set; }
        public string? Detail { get; set; }
        public double Egress { get; set; }
        public double Income { get; set; }
        public string? Observation { get; set; }
    }
}
