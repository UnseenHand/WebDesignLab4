using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebDesignLab4.Models
{
    public class Contacts
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is invalid")]
        //specifies that the phone number is Ukrainian
        [RegularExpression(@"^\+380(-|\s)?\d{2}(-|\s)?\d{3}(-|\s)?\d{4}$", ErrorMessage = "Phone number is invalid")]
        public string PhoneNumber { get; set; }
    }
}
