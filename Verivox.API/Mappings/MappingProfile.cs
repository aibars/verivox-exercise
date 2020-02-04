using AutoMapper;
using Verivox.Domain.ApiModels.Request;
using Verivox.Domain.ApiModels.Response;
using Verivox.Domain.Models;

namespace Verivox.API.Mappings
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping settings
        /// </summary>
        public MappingProfile()
        {
            CreateMap<ApplicationUser, LoggedInUserDto>();

            CreateMap<Consumption, ConsumptionModel>();

            CreateMap<RegisterRequestDto, ApplicationUser>()
               .ForMember(x => x.PasswordHash, y => y.MapFrom(z => z.Password));
        }
    }
}
