namespace MovieApi.Services.Models
{
    public class UserSignUpDto : UserDto
    {
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}