using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface IContactRepository
    {
        Task<List<ContactDto>> GetByProfileIdAsync(Guid profileId);
    }
}
