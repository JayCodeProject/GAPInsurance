namespace POS.WebAPI.Entity
{
    public class HeadquarterStation
    {
        public int Id { get; set; }
        public int HeadquarterId { get; set; }
        public string Serial { get; set; }
        public string Name { get; set; }
        public bool Busy { get; set; }
        public string CreatedUser { get; set; }
    }
}
