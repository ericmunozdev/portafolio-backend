namespace Portafolio.Application.DTOs
{
    public class ProfileDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string WebTitle { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string? WorkPosition { get; set; }

        public string Presentation { get; set; } = string.Empty;
    }
}
