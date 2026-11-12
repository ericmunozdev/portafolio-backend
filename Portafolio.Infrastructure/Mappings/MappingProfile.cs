using Portafolio.Application.DTOs;

namespace Portafolio.Infrastructure.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Persistence.Entities.Profile, ProfileDto>();
            CreateMap<Persistence.Entities.Education, EducationDto>();
        }
    }
}
