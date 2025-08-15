using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dtaplace.UseCases.AcceptInvitation;

public record AcceptiInvitationPayload
{
    [Required]
    string RequestID { get; set; }

    [Required]
    string UserID { get; set; }
    


}