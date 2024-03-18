using AutoMapper;
using Avaliacao_Tecnica.Application.ViewModels;
using Avaliacao_Tecnica.Domain.Models;

namespace Avaliacao_Tecnica.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Client, ClientViewModel>();
        }
    }
}
