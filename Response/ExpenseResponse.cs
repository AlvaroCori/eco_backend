namespace ecoapp.Response
{
    public class ExpenseResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Detail { get; set; }
        public double Egress { get; set; }
        public double Income { get; set; }
        public string? Observation { get; set; }
    }
}
