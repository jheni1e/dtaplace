namespace dtaplace.UseCases.EditProfile;

public record EditProfilePayload
{
    public required string Login { get; set; }
    public required string Password { get; set; }

    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? ImageURL { get; set; }
    public string? Bio { get; set; }
}