namespace Avaliacao_Tecnica.Domain.Commands.Validations
{
    public class RemoveClientCommandValidation : ClientValidation<RemoveClientCommand>
    {
        public RemoveClientCommandValidation()
        {
            ValidateId();
        }
    }
}