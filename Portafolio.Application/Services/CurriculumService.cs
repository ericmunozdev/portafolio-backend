using Portafolio.Application.Interfaces;
using Portafolio.Application.DTOs;

namespace Portafolio.Application.Services
{
    public class CurriculumService(
        IProfileRepository profileRepository,
        ISummaryRepository summaryRepository,
        IContactRepository contactRepository,
        IEducationRepository educationRepository,
        ISkillRepository skillRepository,
        IExperienceRepository experienceRepository,
        IAdditionalRepository additionalRepository
        ) : ICurriculumService
    {

        public async Task<CurriculumDto?> GetByIdAsync(Guid id)
        {
            var profile = await profileRepository.GetByIdAsync(id);
            if (profile == null)
            {
                return null;
            }

            var summary = await summaryRepository.GetByProfileIdAsync(id);
            var contact = await contactRepository.GetByProfileIdAsync(id);
            var education = await educationRepository.GetByProfileIdAsync(id);
            var skillCategory = await skillRepository.GetByProfileIdAsync(id);
            var experience = await experienceRepository.GetByProfileIdAsync(id);
            var additional = await additionalRepository.GetByProfileIdAsync(id);

            return new CurriculumDto
            {
                Profile = profile,
                Summary = summary,
                Contact = contact,
                Education = education,
                Skill = skillCategory,
                Experience = experience,
                Additional = additional
            };
        }
    }
}
