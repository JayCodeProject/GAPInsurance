namespace POS.WebAPI.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public int IdType { get; set; }
        public string Identification { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CreatedUser { get; set; }
    }
}
