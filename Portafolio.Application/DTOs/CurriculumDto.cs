namespace Portafolio.Application.DTOs
{
    public class CurriculumDto
    {
        public ProfileDto Profile { get; set; } = new();
        public List<ContactDto> Contact { get; set; } = [];
        public List<EducationDto> Education { get; set; } = [];
        public List<CategorySkillDto> CategorySkill { get; set; } = [];
        public List<ExperienceDto> Experience { get; set; } = [];
        public List<ProjectSkillDto> ProjectSkill { get; set; } = [];
        public List<AdditionalSkillDto> AdditionalSkill { get; set; } = [];
        public List<OtherDto> Other { get; set; } = [];
    }
}
