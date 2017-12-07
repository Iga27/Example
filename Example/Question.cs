using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    [JsonObject]
    public class Question
    {
        [JsonProperty]
        public int QuestionId { get; set; }

        [JsonProperty]
        public string QuestionText { get; set; }

        [JsonProperty]
        public Option[] Options { get; set; }
    }
}
