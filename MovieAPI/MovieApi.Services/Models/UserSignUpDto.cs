using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Services.Models
{
    public class UserSignUpDto : UserDto
    {
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
