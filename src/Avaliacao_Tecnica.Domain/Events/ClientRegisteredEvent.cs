using System;
using NetDevPack.Messaging;
using static Avaliacao_Tecnica.Domain.Models.Client;

namespace Avaliacao_Tecnica.Domain.Events
{
    public class ClientRegisteredEvent : Event
    {
        public ClientRegisteredEvent(Guid a_Id, string a_CompanyName, CompanySize a_Size)
        {
            Id = a_Id;
            CompanyName = a_CompanyName;
            Size = a_Size;
            AggregateId = a_Id;
        }
        public Guid Id { get; set; }

        public string CompanyName { get; set; }
        public CompanySize Size { get; set; }
    }
}