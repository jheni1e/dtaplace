namespace dtaplace.UseCases.EditProfile;

public record EditProfilePayload
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? ImageURL { get; set; }
    public string? Bio { get; set; }
    public string OldUsername { get; set; }
    public string? Password { get; set; }
}