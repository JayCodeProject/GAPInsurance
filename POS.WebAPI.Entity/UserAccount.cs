using System;

namespace POS.WebAPI.Entity
{
    public class UserAccount
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public int ProfessionId { get; set; }
        public string Profession { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DateOfBirthLabel { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Identification { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public bool TmpPassword { get; set; }
        public string CellPhoneNumber { get; set; }
        public string FullCellPhoneNumber { get; set; }
        public string Ext { get; set; }
        public int CountryCode { get; set; }
        public string Country { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string FullAddress { get; set; }
        public string CreatedUser { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CompanyQty { get; set; }
        public int CompanyHeadquarter { get; set; }
        public int LoginMethod { get; set; }
        public string AgentBrowser { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int NotificationType { get; set; }
        public int Option { get; set; }
    }
}
