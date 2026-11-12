using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface ICategorySkillRepository
    {
        Task<List<CategorySkillDto>> GetByProfileIdAsync(Guid profileId);
    }
}
