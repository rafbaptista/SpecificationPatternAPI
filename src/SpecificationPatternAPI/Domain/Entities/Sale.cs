namespace SpecificationPatternAPI.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public decimal FinancialValue { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
    }
}
