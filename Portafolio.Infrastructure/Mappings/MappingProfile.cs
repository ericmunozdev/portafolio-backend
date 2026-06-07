using AutoMapper;
using Portafolio.Application.DTOs;

namespace Portafolio.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persistence.Entities.Profile, ProfileDto>();
            // CreateMap<Experience, ExperienceDto>();
            // CreateMap<Skill, SkillDto>();
            // CreateMap<Education, EducationDto>();
        }
    }
}
