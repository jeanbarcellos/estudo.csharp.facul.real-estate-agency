using AutoMapper;
using RealEstateAgency.Application.ViewModel;
using RealEstateAgency.Domain.Entities;

namespace RealEstateAgency.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<House, HouseViewModel>();
            CreateMap<Apartment, ApartmentViewModel>();
            CreateMap<Land, LandViewModel>();
        }
    }
}
