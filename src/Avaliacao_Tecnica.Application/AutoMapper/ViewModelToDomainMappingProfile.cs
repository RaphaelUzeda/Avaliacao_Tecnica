using AutoMapper;
using Avaliacao_Tecnica.Application.ViewModels;
using Avaliacao_Tecnica.Domain.Commands;

namespace Avaliacao_Tecnica.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClientViewModel, RegisterNewClientCommand>()
                 .ConstructUsing(c => new RegisterNewClientCommand(c.CompanyName, c.Size));
            CreateMap<ClientViewModel, UpdateClientCommand>()
                .ConstructUsing(c => new UpdateClientCommand(c.Id.Value, c.CompanyName, c.Size));
        }
    }
}
