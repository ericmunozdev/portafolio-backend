namespace Portafolio.Application.DTOs
{
    public class AdditionalSkillDto
    {
        public string Content { get; set; } = string.Empty;

        public List<SkillDto> Skills { get; set; } = [];
    }
}
