using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Avaliacao_Tecnica.Application.EventSourcedNormalizers;
using Avaliacao_Tecnica.Application.Interfaces;
using Avaliacao_Tecnica.Application.ViewModels;
using Avaliacao_Tecnica.Domain.Commands;
using Avaliacao_Tecnica.Domain.Interfaces;
using Avaliacao_Tecnica.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using NetDevPack.Mediator;

namespace Avaliacao_Tecnica.Application.Services
{
    public class ClientAppService : IClientAppService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _ClientRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public ClientAppService(IMapper mapper,
                                  IClientRepository ClientRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _ClientRepository = ClientRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<ClientViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ClientViewModel>>(await _ClientRepository.GetAll());
        }

        public async Task<ClientViewModel> GetById(Guid id)
        {
            return _mapper.Map<ClientViewModel>(await _ClientRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ClientViewModel ClientViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewClientCommand>(ClientViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(ClientViewModel ClientViewModel)
        {
            var updateCommand = _mapper.Map<UpdateClientCommand>(ClientViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveClientCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

      
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
