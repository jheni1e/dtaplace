using System.ComponentModel.DataAnnotations;
namespace dtaplace.UseCases.EditProfile;

public class EditProfileUseCase
{
    public async Task<Result<EditProfileResponse>> Do(EditProfilePayload payload)
    {
        //podem editar tudo, menos a senha, para poder editar precisa passar a senha
        return Result<EditProfileResponse>.Success(null);
    }
}