using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Models.CustomValidationAttributes
{
    public class MoreThanThreeWords : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            if (fieldValue == null || fieldValue.Trim().Split(" ").Length < 3)
            {
                return new ValidationResult("Il campo deve contenere almeno tre parole");
            }

            return ValidationResult.Success;
        }
    }
}
