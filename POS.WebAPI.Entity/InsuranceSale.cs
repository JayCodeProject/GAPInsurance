namespace POS.WebAPI.Entity
{
    public class InsuranceSale
    {
        public int CustomerId { get; set; }
        public int InsuranceId { get; set; }
        public float Coverage { get; set; }
        public string CreatedUser { get; set; }
    }
}
