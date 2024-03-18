using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Avaliacao_Tecnica.Domain.Core.Events;

namespace Avaliacao_Tecnica.Application.EventSourcedNormalizers
{
    public static class ClientHistory
    {
        public static IList<ClientHistoryData> HistoryData { get; set; }

        public static IList<ClientHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ClientHistoryData>();
            ClientHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<ClientHistoryData>();
            var last = new ClientHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ClientHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    CompanyName = string.IsNullOrWhiteSpace(change.CompanyName) || change.CompanyName == last.CompanyName
                        ? ""
                        : change.CompanyName,
                    Size = string.IsNullOrWhiteSpace(change.Size.ToString()) || change.Size == last.Size
                        ? ""
                        : change.Size,
                   
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void ClientHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonSerializer.Deserialize<ClientHistoryData>(e.Data);
                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "ClientRegisteredEvent":
                        historyData.Action = "Registered";
                        historyData.Who = e.User;
                        break;
                    case "ClientUpdatedEvent":
                        historyData.Action = "Updated";
                        historyData.Who = e.User;
                        break;
                    case "ClientRemovedEvent":
                        historyData.Action = "Removed";
                        historyData.Who = e.User;
                        break;
                    default:
                        historyData.Action = "Unrecognized";
                        historyData.Who = e.User ?? "Anonymous";
                        break;

                }
                HistoryData.Add(historyData);
            }
        }
    }
}