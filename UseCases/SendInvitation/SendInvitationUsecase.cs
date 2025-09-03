using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.SendInvitation;

public class SendInvitationUseCase(DTAPlaceDbContext ctx)
{
    public async Task<Result<SendInvitationResponse>> Do(SendInvitationPayload payload)
    {
        var receiver = await ctx.Users.Include(u => u.Invitations).FirstOrDefaultAsync(u => u.ID == payload.ReceiverID);

        if (receiver is null)
            return Result<SendInvitationResponse>.Fail("User not found.");

        var invitation = new Invitation
        {
            ReceiverID = payload.ReceiverID,
            RoomID = payload.RoomID
        };

        ctx.Invitations.Add(invitation);

        receiver.Invitations.Add(invitation);
        await ctx.SaveChangesAsync();

        return Result<SendInvitationResponse>.Success(null);

        // Donos e Administradores podem digitar o nome de um usuário e adicioná-lo na sala.
        // Convites são enviados e o usuário poderá aceitar ou recusar.
    }
}