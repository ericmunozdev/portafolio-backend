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

        public static List<SkillDto> BuildSubtree(IEnumerable<Skill> skills, Guid rootId)
        {
            var skillList = skills.ToList();
            var root = skillList.FirstOrDefault(s => s.Id == rootId);
            return root is null ? [] : [BuildNode(skillList, root)];
        }

        private static List<SkillDto> Build(IReadOnlyCollection<Skill> skills, Guid? fatherId)
        {
            return skills
                .Where(s => s.FatherId == fatherId)
                .OrderBy(s => s.Name)
                .Select(s => BuildNode(skills, s))
                .ToList();
        }

        private static SkillDto BuildNode(IReadOnlyCollection<Skill> skills, Skill skill)
        {
            return new SkillDto
            {
                Icon = skill.Icon,
                Name = skill.Name,
                Children = Build(skills, skill.Id)
            };
        }
    }
}
