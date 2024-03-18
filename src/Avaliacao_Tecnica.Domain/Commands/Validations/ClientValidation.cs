using System;
using FluentValidation;
using static Avaliacao_Tecnica.Domain.Models.Client;

namespace Avaliacao_Tecnica.Domain.Commands.Validations
{
    public abstract class ClientValidation<T> : AbstractValidator<T> where T : ClientCommand
    {
        protected void ValidateCompanyName()
        {
            RuleFor(c => c.CompanyName)
                .NotEmpty().WithMessage("Certifique-se de ter digitado o Nome do cliente")
                .Length(2, 150).WithMessage("O Nome do cliente deve ter entre 2 e 150 caracteres");
        }
            

        protected void ValidateSize()
        {
            RuleFor(c => c.Size)
                .NotEmpty();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

    }
}