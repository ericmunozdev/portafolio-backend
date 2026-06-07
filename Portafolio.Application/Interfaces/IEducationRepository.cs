using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface IEducationRepository
    {
        Task<List<EducationDto>> GetByProfileIdAsync(Guid profileId);
    }
}
