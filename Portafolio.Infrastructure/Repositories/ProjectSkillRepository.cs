using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Common;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class ProjectSkillRepository(PortafolioDbContext context) : IProjectSkillRepository
    {
        public async Task<List<ProjectSkillDto>> GetByProfileIdAsync(Guid profileId)
        {
            var projects = await context.Projects
                .AsNoTracking()
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .Include(x => x.ProjectSkills.Where(ps => ps.IsActive))
                .ThenInclude(ps => ps.Skill)
                .ToListAsync();

            return projects
                .Select(x => new ProjectSkillDto
                {
                    Project = x.Content,
                    Skills = SkillTreeBuilder.Build(
                        x.ProjectSkills.Where(ps => ps.Skill.IsActive).Select(ps => ps.Skill)
                    )
                }).ToList();
        }
    }
}
