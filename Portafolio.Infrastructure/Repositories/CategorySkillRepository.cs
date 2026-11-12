using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Common;
using Portafolio.Infrastructure.Persistence.Contexts;

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
                    Skills = SkillTreeBuilder.Build(x.Skills)
                })
                .ToList();
        }
    }
}
