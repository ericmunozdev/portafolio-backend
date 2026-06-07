using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface IProfileRepository
    {
        Task<ProfileDto?> GetByIdAsync(Guid id);
    }
}
