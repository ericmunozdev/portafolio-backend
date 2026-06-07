using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class LanguageRepository(PortafolioDbContext context, IMapper mapper) : ILanguageRepository
    {
        public async Task<List<LanguageDto>> GetByProfileIdAsync(Guid profileId)
        {
            return await context.Languages
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .OrderBy(x => x.Name)
                .ProjectTo<LanguageDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
