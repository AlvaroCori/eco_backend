namespace ecoapp.DTOS
{
    public class ExpenseDTO
    {
        public string? Detail { get; set; }
        public double Egress { get; set; }
        public double Income { get; set; }
        public string? Observation { get; set; }
    }
}
