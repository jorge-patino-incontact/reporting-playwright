using System.Collections.Generic;
using Utilities.Objects.Query;

namespace Utilities.Objects.API
{
    public class Prompt
    {
        public string messageName { get; set; }
        public List<Answer> answers { get; set; }
    }
}
