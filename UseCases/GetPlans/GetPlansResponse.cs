using dtaplace.Models;

namespace dtaplace.UseCases.Getplans;

public record GetPlansResponse (
    IEnumerable<Plan> Plans
);