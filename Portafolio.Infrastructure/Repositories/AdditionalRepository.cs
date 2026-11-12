using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class AdditionalRepository(PortafolioDbContext context) : IAdditionalRepository
    {
        public async Task<List<AdditionalDto>> GetByProfileIdAsync(Guid profileId)
        {
            //return await context.Additionals
            //    .AsNoTracking()
            //    .Where(x => x.ProfileId == profileId && x.IsActive)
            //    .Select(x => new AdditionalDto
            //    {
            //        Description = x.Content,

            //        Skills = x.AdditionalTechnologies
            //            .Where(t => t.IsActive)
            //            .Select(t => t.Skill.Name)
            //            .OrderBy(t => t)
            //            .ToList()
            //    })
            //    .ToListAsync();
            return await Task.FromResult(new List<AdditionalDto>());
        }
    }
}
