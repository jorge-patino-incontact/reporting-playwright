using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Objects.DTO.ACD
{
    public class UnavailableCode : IDTO
    {
        public int outStateId { get; set; }
        public string outStateName { get; set; }
        public bool isActive { get; set; }
        public bool isAcw { get; set; }
        public int agentTimeoutMins { get; set; }
    }
    public class UnavailableCodes : IDTO
    {
        public List<UnavailableCode> unavailableCodes { get; set; }
    }
}
