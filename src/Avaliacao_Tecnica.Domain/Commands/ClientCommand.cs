using System;
using NetDevPack.Messaging;
using static Avaliacao_Tecnica.Domain.Models.Client;

namespace Avaliacao_Tecnica.Domain.Commands
{
    public abstract class ClientCommand : Command
    {
        public Guid Id { get; protected set; }

        public string CompanyName { get; protected set; }

        public CompanySize Size { get; set; }

    }
}