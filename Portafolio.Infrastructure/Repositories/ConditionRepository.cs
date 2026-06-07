using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class ConditionRepository(PortafolioDbContext context, IMapper mapper) : IConditionRepository
    {
        public async Task<List<ConditionDto>> GetByProfileIdAsync(Guid profileId)
        {
            return await context.Conditions
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .OrderBy(x => x.Name)
                .ProjectTo<ConditionDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
