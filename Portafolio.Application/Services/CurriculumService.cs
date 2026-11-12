using Portafolio.Application.Interfaces;
using Portafolio.Application.DTOs;

namespace Portafolio.Application.Services
{
    public class CurriculumService(
        IProfileRepository profileRepository,
        IContactRepository contactRepository,
        IEducationRepository educationRepository,
        ICategorySkillRepository categorySkillRepository,
        IExperienceRepository experienceRepository,
        IProjectSkillRepository projectSkillRepository,
        IAdditionalSkillRepository additionalSkillRepository,
        IOtherRepository otherRepository
        ) : ICurriculumService
    {

        public async Task<CurriculumDto?> GetByIdAsync(Guid id)
        {
            var profile = await profileRepository.GetByIdAsync(id);
            if (profile == null)
            {
                return null;
            }

            var contact = await contactRepository.GetByProfileIdAsync(id);
            var education = await educationRepository.GetByProfileIdAsync(id);
            var categorySkill = await categorySkillRepository.GetByProfileIdAsync(id);
            var experience = await experienceRepository.GetByProfileIdAsync(id);
            var projectSkill = await projectSkillRepository.GetByProfileIdAsync(id);
            var additionalSkill = await additionalSkillRepository.GetByProfileIdAsync(id);
            var other = await otherRepository.GetByProfileIdAsync(id);

            return new CurriculumDto
            {
                Profile = profile,
                Contact = contact,
                Education = education,
                CategorySkill = categorySkill,
                Experience = experience,
                ProjectSkill = projectSkill,
                AdditionalSkill = additionalSkill,
                Other = other
            };
        }
    }
}
