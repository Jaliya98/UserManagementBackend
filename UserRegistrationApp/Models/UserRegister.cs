namespace UserRegistrationApp.Models
{
    public class UserRegister
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? IMGURL { get; set; }
        public DateTime DOB { get; set; }
        public string NIC { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? OtpExTime { get; set; }
    }

}
