using System;
using Avaliacao_Tecnica.Domain.Commands.Validations;
using static Avaliacao_Tecnica.Domain.Models.Client;

namespace Avaliacao_Tecnica.Domain.Commands
{
    public class RegisterNewClientCommand : ClientCommand
    {
        public RegisterNewClientCommand(string a_CompanyName, CompanySize a_size)
        {
            CompanyName = a_CompanyName;
            Size = a_size;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}