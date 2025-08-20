using Azure;
using dtaplace.Models;

namespace dtaplace.UseCases.Getplans;

public record GetPlansResponse (
    ICollection<Plan> Plans
);
