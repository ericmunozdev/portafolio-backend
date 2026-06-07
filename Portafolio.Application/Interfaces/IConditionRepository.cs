using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface IConditionRepository
    {
        Task<List<ConditionDto>> GetByProfileIdAsync(Guid profileId);
    }
}
