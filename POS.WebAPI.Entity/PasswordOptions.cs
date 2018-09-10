namespace POS.WebAPI.Entity
{
    public class PasswordOptions
    {
        public int RequiredLength;
        public int RequiredUniqueChars;
        public bool RequireDigit;
        public bool RequireLowercase;
        public bool RequireNonAlphanumeric;
        public bool RequireUppercase;
    }
}
