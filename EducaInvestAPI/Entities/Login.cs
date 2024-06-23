using System.ComponentModel.DataAnnotations;

namespace EducaInvestAPI.Entities
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordString { get; set; } = string.Empty;
    }
}
