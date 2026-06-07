namespace Portafolio.Application.DTOs
{
    public class ProfileDto
    {
        //public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
