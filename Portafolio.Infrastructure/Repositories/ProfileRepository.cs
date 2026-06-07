using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Portafolio.Application.Interfaces;
using Portafolio.Application.DTOs;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class ProfileRepository(PortafolioDbContext context, IMapper mapper) : IProfileRepository
    {
        public async Task<ProfileDto?> GetByIdAsync(Guid id)
        {
            return await context.Profiles
                .AsNoTracking()
                .Where(x => x.Id == id && x.IsActive)
                .ProjectTo<ProfileDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
