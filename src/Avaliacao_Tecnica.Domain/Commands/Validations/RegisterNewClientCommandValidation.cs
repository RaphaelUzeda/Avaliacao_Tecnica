namespace Avaliacao_Tecnica.Domain.Commands.Validations
{
    public class RegisterNewClientCommandValidation : ClientValidation<RegisterNewClientCommand>
    {
        public RegisterNewClientCommandValidation()
        {
            ValidateCompanyName();
            ValidateSize();            
        }
    }
}