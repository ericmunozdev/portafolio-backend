using Portafolio.Application.DTOs;

namespace Portafolio.Application.Services
{
    public interface ICurriculumService
    {
        Task<CurriculumDto?> GetByIdAsync(Guid id);
    }
}
