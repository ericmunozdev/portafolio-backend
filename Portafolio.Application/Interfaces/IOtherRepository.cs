using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface IOtherRepository
    {
        Task<List<OtherDto>> GetByProfileIdAsync(Guid profileId);
    }
}
