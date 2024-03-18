namespace Avaliacao_Tecnica.Domain.Commands.Validations
{
    public class UpdateClientCommandValidation : ClientValidation<UpdateClientCommand>
    {
        public UpdateClientCommandValidation()
        {
            ValidateId();
            ValidateCompanyName();
           ValidateSize();
        }
    }
}