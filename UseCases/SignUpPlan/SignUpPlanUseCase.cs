using dtaplace.Models;
using dtaplace.Services.Profiles;
using dtaplace.Services.RolePlanService;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.SignUpPlan;

public class SignUpPlanUseCase(
    DTAPlaceDbContext ctx,
    IProfileService profileService,
    IRolesPlanService rolesPlanService)
{
    public async Task<Result<SignUpPlanResponse>> Do(SignUpPlanPayload payload)
    {
        var user = await profileService.GetProfile(payload.Login);
        if (user is null)
            return Result<SignUpPlanResponse>.Fail("User not found.");

        var giftcard = await ctx.GiftCards.FirstOrDefaultAsync(g => g.Code == payload.GiftCardCode);
        if (giftcard is null)
            return Result<SignUpPlanResponse>.Fail("Gift Card code is invalid.");

        var isPlanValid = user.Expiration > DateTime.Now;
        var free = ctx.Plans.SingleOrDefault(p => p.ID == 0);
        var plan = await rolesPlanService.GetPlan(user.PlanID);

        if (isPlanValid)
        {
            if ((int)plan < (int)await rolesPlanService.GetPlan(giftcard.ID))
                return Result<SignUpPlanResponse>.Fail("You can't downgrade your plan while it's still active!");

            user.Expiration = user.Expiration.Add(TimeSpan.FromDays(giftcard.Duration));
        }
        else
        {
            user.Plan = giftcard.Plan;
            user.PlanID = giftcard.PlanID;
            user.Expiration = DateTime.UtcNow.Add(TimeSpan.FromDays(giftcard.Duration));
        }

        ctx.Users.Update(user);
        await ctx.SaveChangesAsync();

        return Result<SignUpPlanResponse>.Success(null);
    }
}