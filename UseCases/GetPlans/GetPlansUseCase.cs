using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.Getplans;

public class GetPlansUseCase(DTAPlaceDbContext ctx)
{
    public async Task<Result<GetPlansResponse>> Do(GetPlansPayload? payload)
    {
        var plans = await ctx.Plans.ToListAsync();
        
        return Result<GetPlansResponse>.Success(new GetPlansResponse(plans));
    }
}