namespace Portafolio.Application.DTOs
{
    public class SkillDto
    {
        public string? Icon { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<SkillDto> Children { get; set; } = [];
    }
}
