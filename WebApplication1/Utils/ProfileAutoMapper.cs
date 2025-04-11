using WebApplication1.DataAccess.Entity;
using AutoMapper;
using WebApplication1.Services.Model;

namespace WebApplication1.Utils
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<InterventionEntity, InterventionReadModel>()
                .ForMember(dest => dest.ClientFullName, opt => opt.MapFrom(src => src.Client.UserName))
                .ForMember(dest => dest.TechnicianFullNames, opt => opt.MapFrom(src => src.Technicians.Select(t => t.UserName)))
                .ForMember(dest => dest.ServiceTypeName, opt => opt.MapFrom(src => src.ServiceType.Name));

            CreateMap<InterventionCreateModel, InterventionEntity>();

            CreateMap<ServiceTypeEntity, ServiceTypeReadModel>();
            CreateMap<ServiceTypeCreateModel, ServiceTypeEntity>();
        }
    }
}
