using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using ModelValidationsExample.CustomValidators;

namespace ModelValidationsExample.Models
{
  public class Person: IValidatableObject
  {
    [Required(ErrorMessage = "{0} can't be empty or null")]
    [Display(Name = "Person Name")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
    public string? PersonName { get; set; }

    [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
    [Required(ErrorMessage = "{0} can't be blank")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "{0} should contain 10 digits")]
    //[ValidateNever]
    public string? Phone { get; set; }


    [Required(ErrorMessage = "{0} can't be blank")]
    public string? Password { get; set; }


    [Required(ErrorMessage = "{0} can't be blank")]
    [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
    [Display(Name = "Re-enter Password")]
    public string? ConfirmPassword { get; set; }


    [Range(0, 999.99, ErrorMessage = "{0} should be between ${1} and ${2}")]
    public double? Price { get; set; }

    [CustomValidAttribute(ErrorMessage ="Db should not >2000 Jan")]
    public DateTime? DateOfBirth {get; set;}

    public int? Age { get; set;}

    public override string ToString()
    {
      return $"Person object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext){
      if(DateOfBirth.HasValue == false && Age.HasValue == false){
          yield return new ValidationResult("Either of DoB or Age must be applied", new[] { nameof(Age) });
      }
    }
  }
}
