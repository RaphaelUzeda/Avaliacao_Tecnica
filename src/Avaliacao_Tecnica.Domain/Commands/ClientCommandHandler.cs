using System;
using System.Threading;
using System.Threading.Tasks;
using Avaliacao_Tecnica.Domain.Events;
using Avaliacao_Tecnica.Domain.Interfaces;
using Avaliacao_Tecnica.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace Avaliacao_Tecnica.Domain.Commands
{
    public class ClientCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewClientCommand, ValidationResult>,
        IRequestHandler<UpdateClientCommand, ValidationResult>,
        IRequestHandler<RemoveClientCommand, ValidationResult>
    {
        private readonly IClientRepository _clientRepository;

        public ClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var client = new Client(Guid.NewGuid(), message.CompanyName, message.Size);

            client.AddDomainEvent(new ClientRegisteredEvent(client.Id, client.CompanyName, client.Size));

            _clientRepository.Add(client);

            return await Commit(_clientRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var client = new Client(message.Id, message.CompanyName, message.Size);
            var existingClient = await _clientRepository.GetById(client.Id);

            if (existingClient != null && existingClient.Id != client.Id)
            {
                if (!existingClient.Equals(client))
                {
                    AddError("O Nome da empresa já existe nos registros.");
                    return ValidationResult;
                }
            }

            client.AddDomainEvent(new ClientUpdatedEvent(client.Id, client.CompanyName, client.Size));

            _clientRepository.Update(client);

            return await Commit(_clientRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var cliente = await _clientRepository.GetById(message.Id);

            if (cliente is null)
            {
                AddError("O Cliente não existe.");
                return ValidationResult;
            }

            cliente.AddDomainEvent(new ClientRemovedEvent(message.Id));

            _clientRepository.Remove(cliente);

            return await Commit(_clientRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }
    }
}