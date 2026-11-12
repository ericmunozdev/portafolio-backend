namespace Portafolio.Application.DTOs
{
    public class ContactDto
    {
        public string? TypeIcon { get; set; }
        
        public string TypeName { get; set; } = string.Empty;
        
        public string DisplayName { get; set; } = string.Empty;
        
        public string Value { get; set; } = string.Empty;
        
        public short Position { get; set; }
    }
}
