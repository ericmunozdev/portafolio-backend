namespace Portafolio.Application.DTOs
{
    public class ExperienceDto
    {
        public string Company { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string StartDate { get; set; } = string.Empty;

        public string? EndDate { get; set; }

        public List<string> Responsibilities { get; set; } = [];

        public List<string> Skills { get; set; } = [];
    }
}
