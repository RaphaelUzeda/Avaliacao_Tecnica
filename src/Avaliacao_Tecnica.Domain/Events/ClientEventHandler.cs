using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Avaliacao_Tecnica.Domain.Events
{
    public class ClientEventHandler :
        INotificationHandler<ClientRegisteredEvent>,
        INotificationHandler<ClientUpdatedEvent>,
        INotificationHandler<ClientRemovedEvent>
    {
        public Task Handle(ClientUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ClientRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ClientRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}