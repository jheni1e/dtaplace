namespace dtaplace.UseCases.CreateProfile;

public class CreateProfileUseCase(
    IProfileService profileService,
    IPasswordService passwordService
)
{
    public async Task<Result<CreateProfileResponse>> Do(CreateProfilePayload payload)
    {
<<<<<<< HEAD
         return Result<CreateProfileResponse>.Success(null);
=======
      
    
>>>>>>> 21426b348a03be0536b3acf73e0f8066043c7fea
    }
}