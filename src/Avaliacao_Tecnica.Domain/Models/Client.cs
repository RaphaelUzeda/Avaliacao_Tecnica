using System;
using NetDevPack.Domain;

namespace Avaliacao_Tecnica.Domain.Models
{
    public class Client : Entity, IAggregateRoot
    {
        public Client(Guid a_id, string a_CompanyName, CompanySize a_Size)
        {
            Id = a_id;
            CompanyName = a_CompanyName;
            Size = a_Size;
        }

        // Construtor vazio para o  EF
        protected Client() { }

        public string CompanyName { get; private set; }

        public CompanySize Size { get; set; }
        public enum CompanySize
        {
            Small = 1,
            Medium = 2,
            Large = 3,
        }
    }
}