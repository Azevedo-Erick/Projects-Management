using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProjectsManagement.validators;

public class HexadecimalAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            var valorHexadecimal = value.ToString();
            var hexadecimalRegex = new Regex("^[0-9a-fA-F]+$");
            if (!hexadecimalRegex.IsMatch(valorHexadecimal))
            {
                return new ValidationResult(ErrorMessage ?? "O valor deve ser hexadecimal.");
            }
        }
        return ValidationResult.Success;
    }
}
