using System.Collections.Generic;

namespace Utilities.Objects.DTO.ACD
{
    public class Team : IDTO
    {
        public int teamId { get; set; }
        public string teamName { get; set; }
        public string notes { get; set; }
        public string teamUuid { get; set; }
        public bool isActive { get; set; }
    }
    public class Teams : IDTO
    {
        public List<Team> teams { get; set; }
    }
}
