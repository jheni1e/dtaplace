using System.ComponentModel.DataAnnotations;

namespace dtaplace.Validations;

public class NeedUpperAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
        => value is string text && text.Any(c => char.IsUpper(c));

    public override string FormatErrorMessage(string name)
        => $"The field '{name}' needs to contain upper letters.";
}