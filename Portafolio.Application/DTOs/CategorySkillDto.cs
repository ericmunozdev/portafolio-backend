namespace Portafolio.Application.DTOs
{
    public class CategorySkillDto
    {
        public string Category { get; set; } = string.Empty;
        public List<SkillDto> Skills { get; set; } = [];
    }
}
