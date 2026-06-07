using Portafolio.Application.DTOs;

namespace Portafolio.Infrastructure.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Persistence.Entities.Profile, ProfileDto>();
            CreateMap<Persistence.Entities.Contact, ContactDto>();
            CreateMap<Persistence.Entities.Education, EducationDto>();
            CreateMap<Persistence.Entities.Language, LanguageDto>();
            CreateMap<Persistence.Entities.Condition, ConditionDto>();
        }
    }
}
