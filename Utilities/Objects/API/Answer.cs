using System.Collections.Generic;

namespace Utilities.Objects.Query
{
    public class Answer
    {
        public string key { get; set; }
        public List<string> values { get; set; }
        public string useDefault { get; set; }
    }
}
