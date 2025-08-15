using System.ComponentModel.DataAnnotations;
namespace dtaplace.UseCases.Getplans;

public record GetPlansPayload
{
    [Required]
    public string Plan;


};