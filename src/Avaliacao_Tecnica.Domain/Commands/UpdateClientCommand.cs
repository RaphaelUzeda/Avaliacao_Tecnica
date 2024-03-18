using System;
using Avaliacao_Tecnica.Domain.Commands.Validations;
using static Avaliacao_Tecnica.Domain.Models.Client;

namespace Avaliacao_Tecnica.Domain.Commands
{
    public class UpdateClientCommand : ClientCommand
    {
        public UpdateClientCommand(Guid a_Id, string a_CompanyName, CompanySize a_Size)
        {
            Id = a_Id;
            CompanyName = a_CompanyName;
            Size = a_Size;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}