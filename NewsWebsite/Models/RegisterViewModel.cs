using System.ComponentModel.DataAnnotations;

namespace NewsWebsite.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "The field cannpt be empty")]
        [StringLength(30, ErrorMessage = "The login cannot contain more than 30 charachters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(30, ErrorMessage = "The password must contain at least {2} characters and mustn't be longer than 30 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}