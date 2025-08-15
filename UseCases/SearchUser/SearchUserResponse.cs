namespace dtaplace.UseCases.SearchUser;

public record SearchUserResponse(
    string Username,
    int ID,
    string Bio,
    string ImageURL,
    string PlanNam
);