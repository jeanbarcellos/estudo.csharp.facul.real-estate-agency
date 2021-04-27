using AutoMapper;
using RealEstateAgency.Application.ViewModel;
using RealEstateAgency.Domain.Entities;

namespace RealEstateAgency.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClientViewModel, Client>();
        }
    }
}
