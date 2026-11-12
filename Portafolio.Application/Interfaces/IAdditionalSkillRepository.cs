using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface IAdditionalSkillRepository
    {
        Task<List<AdditionalSkillDto>> GetByProfileIdAsync(Guid profileId);
    }
}
