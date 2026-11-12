using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Common;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class AdditionalSkillRepository(PortafolioDbContext context) : IAdditionalSkillRepository
    {
        public async Task<List<AdditionalSkillDto>> GetByProfileIdAsync(Guid profileId)
        {
            var additionalSkills = await context.AdditionalSkills
                .AsNoTracking()
                .Where(x => x.ProfileId == profileId && x.IsActive && x.Skill.IsActive)
                .ToListAsync();

            var skills = await context.Skills
                .AsNoTracking()
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .ToListAsync();

            return additionalSkills
                .Select(x => new AdditionalSkillDto
                {
                    Content = x.Content ?? string.Empty,
                    Skills = SkillTreeBuilder.BuildSubtree(skills, x.SkillId)
                })
                .ToList();
        }
    }
}
