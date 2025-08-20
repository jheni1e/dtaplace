namespace dtaplace.UseCases.GetProfile;
public record GetProfileResponse(
    string Username,
    string Bio,
    string ImageURL,
    string PlanName
);