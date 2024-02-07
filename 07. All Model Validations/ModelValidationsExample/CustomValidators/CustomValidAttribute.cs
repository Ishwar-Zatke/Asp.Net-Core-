using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidators
{
    public class CustomValidAttribute : ValidationAttribute
    {
        // Custom Validation for MinYearValue
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is DateTime date)
            {
                if (date.Year >= 2000)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Minimum year should be 2000");
                }
            }

            // You may want to adjust this part based on your specific needs.
            return new ValidationResult("Invalid date value");
        }
    }
}
