using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Persistence.Contexts;
using Portafolio.Infrastructure.Persistence.Entities;

namespace Portafolio.Infrastructure.Repositories
{
    public class CategorySkillRepository(PortafolioDbContext context) : ICategorySkillRepository
    {
        public async Task<List<CategorySkillDto>> GetByProfileIdAsync(Guid profileId)
        {
            var categories = await context.SkillsCategories
                .AsNoTracking()
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .Include(x => x.Skills.Where(s => s.IsActive))
                .ToListAsync();

            return categories
                .Select(x => new CategorySkillDto
                {
                    Category = x.Name,
                    Skills = BuildSkillTree(x.Skills, null)
                })
                .ToList();
        }

        private static List<SkillDto> BuildSkillTree(IEnumerable<Skill> skills, Guid? fatherId)
        {
            return skills
                .Where(s => s.FatherId == fatherId)
                .OrderBy(s => s.Name)
                .Select(s => new SkillDto
                {
                    Icon = s.Icon,
                    Name = s.Name,
                    Children = BuildSkillTree(skills, s.Id)
                })
                .ToList();
        }
    }
}
