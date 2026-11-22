using Microsoft.EntityFrameworkCore;
using Portafolio.Application.Interfaces;
using Portafolio.Application.DTOs;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class ProfileRepository(PortafolioDbContext context) : IProfileRepository
    {
        public async Task<ProfileDto?> GetByIdAsync(Guid id)
        {
            return await context.Profiles
                .AsNoTracking()
                .Where(x => x.Id == id && x.IsActive)
                .Select(x => new ProfileDto
                {
                    Id = x.Id,
                    WebTitle = x.WebTitle,
                    FullName = x.FullName,
                    WorkPosition = x.WorkPosition,
                    Presentation = x.Presentation
                })
                .FirstOrDefaultAsync();
        }
    }
}
