using Portafolio.Application.Interfaces;
using Portafolio.Application.DTOs;

namespace Portafolio.Application.Services
{
    public class CurriculumService(
        IProfileRepository profileRepository,
        //ISummaryRepository summaryRepository,
        IContactRepository contactRepository,
        IEducationRepository educationRepository,
        ICategorySkillRepository categorySkillRepository,
        IExperienceRepository experienceRepository
        //IAdditionalRepository additionalRepository,
        //ILanguageRepository languageRepository,
        //IConditionRepository conditionRepository
        ) : ICurriculumService
    {

        public async Task<CurriculumDto?> GetByIdAsync(Guid id)
        {
            var profile = await profileRepository.GetByIdAsync(id);
            if (profile == null)
            {
                return null;
            }

            //var summary = await summaryRepository.GetByProfileIdAsync(id);
            var contact = await contactRepository.GetByProfileIdAsync(id);
            var education = await educationRepository.GetByProfileIdAsync(id);
            var categorySkill = await categorySkillRepository.GetByProfileIdAsync(id);
            var experience = await experienceRepository.GetByProfileIdAsync(id);
            //var additional = await additionalRepository.GetByProfileIdAsync(id);
            //var language = await languageRepository.GetByProfileIdAsync(id);
            //var condition = await conditionRepository.GetByProfileIdAsync(id);

            return new CurriculumDto
            {
                Profile = profile,
                Contact = contact,
                Education = education,
                CategorySkill = categorySkill,
                Experience = experience,
                //Additional = additional,
                //Language = language,
                //Condition = condition
            };
        }
    }
}
