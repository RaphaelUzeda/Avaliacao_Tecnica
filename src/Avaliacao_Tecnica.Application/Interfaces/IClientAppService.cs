using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avaliacao_Tecnica.Application.ViewModels;
using FluentValidation.Results;

namespace Avaliacao_Tecnica.Application.Interfaces
{
    public interface IClientAppService : IDisposable
    {
        Task<IEnumerable<ClientViewModel>> GetAll();
        Task<ClientViewModel> GetById(Guid id);
        
        Task<ValidationResult> Register(ClientViewModel ClientViewModel);
        Task<ValidationResult> Update(ClientViewModel ClientViewModel);
        Task<ValidationResult> Remove(Guid id);

    }
}
