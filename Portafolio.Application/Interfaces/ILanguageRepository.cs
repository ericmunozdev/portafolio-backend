using Portafolio.Application.DTOs;

namespace Portafolio.Application.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<LanguageDto>> GetByProfileIdAsync(Guid profileId);
    }
}
