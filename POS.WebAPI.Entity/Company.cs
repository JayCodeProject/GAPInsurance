using System;

namespace POS.WebAPI.Entity
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int SubProductId { get; set; }
        public int Size { get; set; }
        public string Logo { get; set; }
        public DateTime FoundedDate { get; set; }
        public int Parking { get; set; }
        public int Smoke { get; set; }
        public int Wifi { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Email { get; set; }
        public int CountryCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Ext { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public string HaciendaAddress1Id { get; set; }
        public string HaciendaAddress2Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CatIdentId { get; set; }
        public int LegalId { get; set; }
        public string OtherAddress { get; set; }
        public string CreatedUser { get; set; }
    }
}
