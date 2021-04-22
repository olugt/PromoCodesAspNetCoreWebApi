namespace PromoCodesAspNetCoreWebApi.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string PasswordHashToBase64 { get; set; }
        public string EmailAddress { get; set; }
    }
}