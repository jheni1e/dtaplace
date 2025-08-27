namespace dtaplace.UseCases.SignUpPlan;

public class SignUpPlanUseCase
{
    public async Task<Result<SignUpPlanResponse>> Do(SignUpPlanPayload payload)
    {
        return Result<SignUpPlanResponse>.Success(null);
        //Para aderir a um plano ele precisa de um código válido para esse plano.
        // No caso, a geração desses códigos será feita manualmente pelo desenvolvedor e colocados no banco de dados, ou seja,
        // não existe nada no sistema para criação de códigos, eles são criados manualmente e vendidos em Gift Cards.
        // Mas deve ser possível que o usuário entre com um código e atualize seu plano. Um código não pode ser usado mais de uma vez.
        // Cada código ainda tem um tempo associado com a duração do plano;
        // Isso é importante porque um usuário Gold pode comprar mais duração ao seu plano e estender sua validade.
        // É recomendado que o usuário e seu jwt tenham o último plano e sua data de expiração.
        // Caso o plano não seja mais válido, considera-se que o usuário é um usuário Gratuito.
    }
}