using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class SkillRepository(PortafolioDbContext context) : ISkillRepository
    {
        public async Task<List<SkillCategoryDto>> GetByProfileIdAsync(Guid profileId)
        {
            return await context.SkillCategories
                .AsNoTracking()
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .Select(x => new SkillCategoryDto
                {
                    Category = x.Name,
                    Items = x.Skills
                        .Where(s => s.IsActive && s.IsVisibleGral)
                        .Select(s => s.Name)
                        .ToList()
                })
                .ToListAsync();
        }
    }
}
