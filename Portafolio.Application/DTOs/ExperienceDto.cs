namespace Portafolio.Application.DTOs
{
    public class ExperienceDto
    {
        public string Company { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string StartDate { get; set; } = string.Empty;

        public string EndDate { get; set; } = string.Empty;

        public string Responsibility { get; set; } = string.Empty;

        public bool Collapse { get; set; }

        public List<SkillDto> Skills { get; set; } = [];
    }
}
