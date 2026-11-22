using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class EducationRepository(PortafolioDbContext context) : IEducationRepository
    {
        public async Task<List<EducationDto>> GetByProfileIdAsync(Guid profileId)
        {
            return await context.Educations
                .AsNoTracking()
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .OrderByDescending(x => x.GraduationYear)
                .Select(x => new EducationDto
                {
                    Title = x.Title,
                    Institution = x.Institution,
                    GraduationYear = x.GraduationYear
                })
                .ToListAsync();
        }
    }
}
