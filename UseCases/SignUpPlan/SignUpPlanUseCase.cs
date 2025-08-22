namespace dtaplace.UseCases.SignUpPlan;

public class SignUpPlanUseCase
{
    public async Task<Result<SignUpPlanResponse>> Do(SignUpPlanPayload payload)
    {
        return Result<SignUpPlanResponse>.Success(null);
    }
}