namespace dtaplace.UseCases.EditProfile;

public record EditProfilePayload(
    string Username,
    string Email,
    string ImageURL,
    string Bio
);
