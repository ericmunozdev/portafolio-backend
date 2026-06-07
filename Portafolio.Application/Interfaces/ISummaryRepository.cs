using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface ISummaryRepository
    {
        Task<List<string>> GetByProfileIdAsync(Guid profileId);
    }
}
