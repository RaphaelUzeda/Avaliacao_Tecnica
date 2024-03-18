using NetDevPack.Messaging;

namespace Avaliacao_Tecnica.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}