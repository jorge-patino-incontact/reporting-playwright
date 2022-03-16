using System.Collections.Generic;

namespace Utilities.Objects.DTO.ACD
{
    public class Skill : IDTO
    {
        public int skillId { get; set; }
        public string skillName { get; set; }
        public bool isActive { get; set; }
    }
    public class Skills : IDTO
    {
        public int businessUnitId { get; set; }
        public List<Skill> skills { get; set; }
    }
}
