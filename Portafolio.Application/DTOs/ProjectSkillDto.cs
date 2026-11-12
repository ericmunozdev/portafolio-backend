namespace Portafolio.Application.DTOs
{
    public class ProjectSkillDto
    {
        public string Project { get; set; } = string.Empty;
        public List<SkillDto> Skills { get; set; } = [];
    }
}
