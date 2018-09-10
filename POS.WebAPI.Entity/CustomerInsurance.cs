
namespace POS.WebAPI.Entity
{
    public class CustomerInsurance
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Insurance { get; set; }
        public int Coverage { get; set; }
        public string CreatedUser { get; set; }
    }
}
