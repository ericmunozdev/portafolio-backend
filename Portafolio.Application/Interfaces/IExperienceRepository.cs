using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface IExperienceRepository
    {
        Task<List<ExperienceDto>> GetByProfileIdAsync(Guid profileId);
    }
}
