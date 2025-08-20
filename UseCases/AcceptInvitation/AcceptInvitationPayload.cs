using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dtaplace.UseCases.AcceptInvitation;

public record AcceptInvitationPayload
(
    string UserID,
    string RequestID
);