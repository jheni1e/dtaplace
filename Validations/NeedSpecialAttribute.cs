using System.ComponentModel.DataAnnotations;

namespace dtaplace.Validations;

public class NeedSpecialAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
        => value is string text && text.Any(c => char.IsSymbol(c));

    public override string FormatErrorMessage(string name)
        => $"The field '{name}' needs to contain special characters.";
}