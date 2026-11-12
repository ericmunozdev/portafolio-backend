using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class OtherRepository(PortafolioDbContext context) : IOtherRepository
    {
        public async Task<List<OtherDto>> GetByProfileIdAsync(Guid profileId)
        {
            return await context.Others
                .AsNoTracking()
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .OrderBy(x => x.Text)
                .Select(x => new OtherDto
                {
                    Text = x.Text,
                    Description = x.Description
                })
                .ToListAsync();
        }
    }
}
