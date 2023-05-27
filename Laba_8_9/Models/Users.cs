using System.ComponentModel.DataAnnotations;

namespace Laba_7.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime BithDate { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int FailedLoginAttempts { get; set; }

        public bool IsBlocked { get; set; }
    }
}
