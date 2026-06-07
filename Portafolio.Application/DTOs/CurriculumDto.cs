namespace Portafolio.Application.DTOs
{
    public class CurriculumDto
    {
        public ProfileDto Profile { get; set; } = new();
        public List<string> Summary { get; set; } = [];
        public List<ContactDto> Contact { get; set; } = [];
        public List<EducationDto> Education { get; set; } = [];
        public List<SkillCategoryDto> Skill { get; set; } = [];
    }
}
