using Portafolio.Application.DTOs;
using Portafolio.Infrastructure.Persistence.Entities;

namespace Portafolio.Infrastructure.Common
{
    public static class SkillTreeBuilder
    {
        public static List<SkillDto> Build(IEnumerable<Skill> skills)
        {
            var skillList = skills.ToList();
            return Build(skillList, null);
        }

        private static List<SkillDto> Build(IReadOnlyCollection<Skill> skills, Guid? fatherId)
        {
            return skills
                .Where(s => s.FatherId == fatherId)
                .OrderBy(s => s.Name)
                .Select(s => new SkillDto
                {
                    Icon = s.Icon,
                    Name = s.Name,
                    Children = Build(skills, s.Id)
                })
                .ToList();
        }
    }
}
