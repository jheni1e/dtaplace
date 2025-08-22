namespace dtaplace.Services.JWT;

public record ProfileAuth(
    int ID,
    string Username,
    int PlanID,
    DateTime ExpirationDate
);