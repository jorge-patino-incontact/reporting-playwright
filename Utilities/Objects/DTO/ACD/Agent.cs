using System.Collections.Generic;

namespace Utilities.Objects.DTO.ACD
{
    public  class Agent: IDTO
    {
        public int agentId { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userId { get; set; }
        public bool isActive { get; set; }
        public int teamId { get; set; }
        public string teamName { get; set; }
        public int profileId { get; set; }
        public string profileName { get; set; }
        public string timeZone { get; set; }
        public string teamUuid { get; set; }
    }
    public class Agents : IDTO
    {
        public int businessUnitId { get; set; }
        public List<Agent> agents { get; set; }
    }
}
