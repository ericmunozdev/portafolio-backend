namespace Portafolio.Application.DTOs
{
    public class CurriculumDto
    {
        public ProfileDto Profile { get; set; } = new();
        public List<ContactDto> Contact { get; set; } = [];
        public List<EducationDto> Education { get; set; } = [];
        public List<CategorySkillDto> CategorySkill { get; set; } = [];
        //public List<ExperienceDto> Experience { get; set; } = [];
        //public List<AdditionalDto> Additional { get; set; } = [];
        //public List<LanguageDto> Language { get; set; } = [];
        //public List<ConditionDto> Condition { get; set; } = [];
    }
}
