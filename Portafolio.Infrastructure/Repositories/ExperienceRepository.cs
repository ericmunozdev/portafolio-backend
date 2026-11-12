using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Common;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class ExperienceRepository(PortafolioDbContext context) : IExperienceRepository
    {
        public async Task<List<ExperienceDto>> GetByProfileIdAsync(Guid profileId)
        {
            var experiences = await context.Experiences
                .AsNoTracking()
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .OrderByDescending(x => x.StartDate)
                .Include(x => x.ExperienceSkills.Where(es => es.IsActive))
                .ThenInclude(es => es.Skill)
                .ToListAsync();

            return experiences
                .Select(x => new ExperienceDto
                {
                    Company = x.Company,
                    Role = x.Role,
                    StartDate = x.StartDate.ToString("MMM yyyy"),
                    EndDate = x.EndDate.HasValue ? x.EndDate.Value.ToString("MMM yyyy") : string.Empty,
                    Responsibility = x.Responsibility,
                    Collapse = x.Collapse,
                    Skills = SkillTreeBuilder.Build(
                        x.ExperienceSkills.Where(es => es.Skill.IsActive).Select(es => es.Skill)
                    )
                }).ToList();
        }
    }
}
