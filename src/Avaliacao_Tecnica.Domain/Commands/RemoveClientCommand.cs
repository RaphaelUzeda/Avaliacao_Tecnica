using System;
using Avaliacao_Tecnica.Domain.Commands.Validations;

namespace Avaliacao_Tecnica.Domain.Commands
{
    public class RemoveClientCommand : ClientCommand
    {
        public RemoveClientCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}