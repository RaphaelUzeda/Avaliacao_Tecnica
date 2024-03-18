using System;
using NetDevPack.Messaging;

namespace Avaliacao_Tecnica.Domain.Events
{
    public class ClientRemovedEvent : Event
    {
        public ClientRemovedEvent(Guid a_Id)
        {
            Id = a_Id;
            AggregateId = a_Id;
        }

        public Guid Id { get; set; }
    }
}