using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avaliacao_Tecnica.Domain.Core.Events;

namespace Avaliacao_Tecnica.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        Task<IList<StoredEvent>> All(Guid aggregateId);
    }
}