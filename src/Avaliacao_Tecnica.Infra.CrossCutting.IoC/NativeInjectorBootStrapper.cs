using Avaliacao_Tecnica.Application.Interfaces;
using Avaliacao_Tecnica.Application.Services;
using Avaliacao_Tecnica.Domain.Commands;
using Avaliacao_Tecnica.Domain.Core.Events;
using Avaliacao_Tecnica.Domain.Events;
using Avaliacao_Tecnica.Domain.Interfaces;
using Avaliacao_Tecnica.Infra.CrossCutting.Bus;
using Avaliacao_Tecnica.Infra.Data.Context;
using Avaliacao_Tecnica.Infra.Data.EventSourcing;
using Avaliacao_Tecnica.Infra.Data.Repository;
using Avaliacao_Tecnica.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Avaliacao_Tecnica.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IClientAppService, ClientAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<ClientRegisteredEvent>, ClientEventHandler>();
            services.AddScoped<INotificationHandler<ClientUpdatedEvent>, ClientEventHandler>();
            services.AddScoped<INotificationHandler<ClientRemovedEvent>, ClientEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewClientCommand, ValidationResult>, ClientCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClientCommand, ValidationResult>, ClientCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveClientCommand, ValidationResult>, ClientCommandHandler>();

            // Infra - Data
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<BaseContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}