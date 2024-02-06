using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Validations;

public class NameAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var patient = validationContext.ObjectInstance as Patient;
        if (patient != null)
        {
            if (patient.FirstName != null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("First name cannot be null");
        }

        return ValidationResult.Success;

    }
}
