using dtaplace.Models;
using dtaplace.Services.RolePlanService;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.SendInvitation;

public class SendInvitationUseCase(
    DTAPlaceDbContext ctx,
    RolesPlanService rolesPlanService)
{
    public async Task<Result<SendInvitationResponse>> Do(SendInvitationPayload payload)
    {
        var receiver = await ctx.Users.Include(u => u.Invitations).FirstOrDefaultAsync(u => u.Username == payload.ReceiverName);
        var role = await rolesPlanService.GetRole(payload.SenderID);

        if (receiver is null)
            return Result<SendInvitationResponse>.Fail("User not found.");

        if (role is not RoomRole.Admin && role is not RoomRole.Dono)
            return Result<SendInvitationResponse>.Fail("Somente o host e os administradores da sala podem enviar convites");

        var invitation = new Invitation
        {
            ReceiverID = receiver.ID,
            RoomID = payload.RoomID
        };

        ctx.Invitations.Add(invitation);

        receiver.Invitations.Add(invitation);
        await ctx.SaveChangesAsync();

        return Result<SendInvitationResponse>.Success(new ());

        // Donos e Administradores podem digitar o nome de um usuário e adicioná-lo na sala.
        // Convites são enviados e o usuário poderá aceitar ou recusar.
    }
}