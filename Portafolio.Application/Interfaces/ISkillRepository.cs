using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface ISkillRepository
    {
        Task<List<SkillCategoryDto>> GetByProfileIdAsync(Guid profileId);
    }
}
