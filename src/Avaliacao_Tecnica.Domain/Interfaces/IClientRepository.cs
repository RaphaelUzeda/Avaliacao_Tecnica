using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avaliacao_Tecnica.Domain.Models;
using NetDevPack.Data;

namespace Avaliacao_Tecnica.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetById(Guid id);
        Task<IEnumerable<Client>> GetAll();
        void Add(Client client);
        void Update(Client client);
        void Remove(Client client);
    }
}