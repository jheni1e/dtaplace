using System.ComponentModel.DataAnnotations;

namespace dtaplace.Validations;

public class NeedNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
        => value is string text && text.Any(c => c is <= '0' or >= '9');

    public override string FormatErrorMessage(string name)
        => $"The field '{name}' needs to contain numbers.";
}