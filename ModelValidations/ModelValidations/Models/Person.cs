using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelValidations;
namespace ModelValidations.Models
{
    //Person Registration form
    public class Person
    {
        //Error message incase person name is empty
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between " +
            "{2} and {1} characters long ")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "{0} should have proper email")]
        [Required]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "{0} should have 10 digits")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage = "{0} should be between ${1} and ${2}")]
        public string? Price { get; set; }

        public override string ToString()
        {
            return $"Person object: Person Name: {PersonName}, Email:{Email}," +
                $"Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
        }
    }
}
