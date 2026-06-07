using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class ExperienceRepository(PortafolioDbContext context) : IExperienceRepository
    {
        public async Task<List<ExperienceDto>> GetByProfileIdAsync(Guid profileId)
        {
            return await context.Experiences
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .OrderByDescending(x => x.StartDate)
                .Select(x => new ExperienceDto
                {
                    Company = x.Company,

                    Role = x.Role,

                    StartDate = x.StartDate.ToString("MMM yyyy"),

                    EndDate = x.EndDate.HasValue
                        ? x.EndDate.Value.ToString("MMM yyyy")
                        : "Actualidad",

                    Responsibilities = x.ExperienceResponsibilities
                        .Where(r => r.IsActive)
                        .OrderBy(r => r.Position)
                        .Select(r => r.Content)
                        .ToList(),

                    Skills = x.ExperienceTechnologies
                        .Where(t => t.IsActive)
                        .Select(t => t.Skill.Name)
                        .OrderBy(t => t)
                        .ToList()
                })
                .ToListAsync();
        }
    }
}
