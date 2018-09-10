namespace POS.WebAPI.Entity
{
    public class LoginEvent
    {
        public string company { get; set; }
        public string username { get; set; }
        public int loginMethod { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string browser { get; set; }
        public string ipAddress { get; set; }
        public string createdUser { get; set; }
    }
}