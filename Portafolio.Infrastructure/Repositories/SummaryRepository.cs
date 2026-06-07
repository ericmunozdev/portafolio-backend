using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class SummaryRepository(PortafolioDbContext context, IMapper mapper) : ISummaryRepository
    {
        public async Task<List<string>> GetByProfileIdAsync(Guid profileId)
        {
            return await context.Summaries
                .AsNoTracking()
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .OrderBy(x => x.Position)
                .Select(x => x.Content)
                .ToListAsync();
        }
    }
}
