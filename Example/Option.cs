using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    [JsonObject]
    public class Option
    {
        [JsonProperty]
        public int OptionId { get; set; }

        [JsonProperty]
        public string OptionText { get; set; }

        [JsonProperty]
        public int QuestionId { get; set; }

        [JsonIgnore]
        public virtual Question Question { get; set; }

        [JsonProperty]
        public bool IsCorrect { get; set; }
    }
}
