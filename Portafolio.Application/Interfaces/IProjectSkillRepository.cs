using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface IProjectSkillRepository
    {
        Task<List<ProjectSkillDto>> GetByProfileIdAsync(Guid profileId);
    }
}
