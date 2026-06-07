using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface IAdditionalRepository
    {
        Task<List<AdditionalDto>> GetByProfileIdAsync(Guid profileId);
    }
}
