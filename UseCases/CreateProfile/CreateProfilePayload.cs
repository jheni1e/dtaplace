using System.ComponentModel.DataAnnotations;
using dtaplace.Validations;

namespace dtaplace.UseCases.CreateProfile;

public record CreateProfilePayload
{
    [Required]
    [MinLength(6)]
    public string Username { get; init; }

    [Required]
    [EmailAddress]
    public string Email { get; init; }

    [Required]
    [MinLength(8)]
    [NeedNumber]
    [NeedLower]
    [NeedUpper]
    [NeedSpecial]
    public string Password { get; init; }

    [Required]
    [Compare("Password")]
    public string RepeatPassword { get; init; }

    [Required]
    [MaxLength(200)]
    public string Bio { get; init; }

    public string ImageURL { get; init; }
}