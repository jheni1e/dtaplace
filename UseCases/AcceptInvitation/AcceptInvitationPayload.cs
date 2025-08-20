using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dtaplace.UseCases.AcceptInvitation;

public record AcceptiInvitationPayload
(
    string UserID,
    string RequestID
);
    
