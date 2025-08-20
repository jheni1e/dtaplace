using System.Reflection.Metadata.Ecma335;
using dtaplace.Models;

namespace dtaplace.UseCases.GetInvitations;

public record GetInvitationsResponse (
    ICollection<Invitation> Invitations
);