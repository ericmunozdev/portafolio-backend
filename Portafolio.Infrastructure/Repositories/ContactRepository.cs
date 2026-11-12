using Microsoft.EntityFrameworkCore;
using Portafolio.Application.DTOs;
using Portafolio.Application.Interfaces;
using Portafolio.Infrastructure.Persistence.Contexts;

namespace Portafolio.Infrastructure.Repositories
{
    public class ContactRepository(PortafolioDbContext context) : IContactRepository
    {
        public async Task<List<ContactDto>> GetByProfileIdAsync(Guid profileId)
        {
            return await context.Contacts
                .AsNoTracking()
                .Where(x => x.ProfileId == profileId && x.IsActive)
                .OrderBy(x => x.Position)
                .Select(x => new ContactDto
                {
                    TypeIcon = x.TypeContact.Icon,
                    TypeName = x.TypeContact.Name,
                    DisplayName = x.DisplayName,
                    Value = x.Value,
                    Position = x.Position
                })
                .ToListAsync();
        }
    }
}
