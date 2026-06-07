using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class EducationRepository(PortafolioDbContext context, IMapper mapper) : IEducationRepository
    {
        public async Task<List<EducationDto>> GetByProfileIdAsync(Guid profileId)
        {
            return await context.Educations
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .ProjectTo<EducationDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
