using System.Collections.Generic;

namespace Utilities.Objects.DTO.ACD
{
    public class Campaign: IDTO
    {
        public int campaignId { get; set; }
        public string campaignName { get; set; }
        public string isActive { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
    }
    public class Campaigns : IDTO
    {
        public List<Campaign> campaigns { get; set; }
    }
}
