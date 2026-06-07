using Portafolio.Application.Interfaces;
using Portafolio.Application.DTOs;

namespace Portafolio.Application.Services
{
    public class CurriculumService : ICurriculumService
    {
        private readonly IProfileRepository profileRepository;

        public CurriculumService(
            IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        public async Task<CurriculumDto?> GetByIdAsync(Guid id)
        {
            var profile = await profileRepository.GetByIdAsync(id);

            if (profile is null)
            {
                return null;
            }

            return new CurriculumDto
            {
                Profile = profile
            };
        }
    }
}
